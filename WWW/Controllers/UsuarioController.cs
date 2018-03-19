using Business;
using Business.Interface;
using Engine;
using Engine.Interface;
using FluentValidation;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WWW.ViewModels.Validation;
using WWW.ViewModels.Request;
using WWW.ViewModels.Response;
using WWW.Filters;

namespace WWW.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IValidator<UsuarioPostViewModel> _validator;
        private readonly IUsuarioEngine _usuarioEngine;
        private readonly ITokenEngine _tokenEngine;
        private readonly IPontuacaoEngine _pontuacaoEngine;
        private readonly ICompartilhamentoEngine _compartilhamentoEngine;
        private readonly IQuizEngine _quizEngine;
        private readonly IMailSender _mailSender;

        public UsuarioController(IValidator<UsuarioPostViewModel> validator,
                                 IUsuarioEngine usuarioEngine,ITokenEngine tokenEngine,IPontuacaoEngine pontuacaoEngine,
                                 ICompartilhamentoEngine compartilhamentoEngine,IMailSender mailSender, IQuizEngine quizEngine)
        {
            this._validator = validator;
            this._usuarioEngine = usuarioEngine;
            this._tokenEngine = tokenEngine;
            this._pontuacaoEngine = pontuacaoEngine;
            this._compartilhamentoEngine = compartilhamentoEngine;
            this._mailSender = mailSender;
            this._quizEngine = quizEngine;
        }

        [BasicAuthentication]
        public HttpResponseMessage Post(UsuarioPostViewModel usuario)
        {
            var validation = this._validator.Validate(usuario);
            if (validation.IsValid)
            {
                var usuarioModel = usuario.ConverterUsuario();

                try
                {
                    string usuarioId = this._usuarioEngine.Cadastrar(usuarioModel);

                    var now = DateTime.Now;

                    string codToken = CadastraToken(int.Parse(usuarioId),1);

                    CadastrarPosicao(int.Parse(usuarioId));

                    CadastrarCompartilhamento(usuario.Token, int.Parse(usuarioId));

                    string linkToken = CadastraToken(int.Parse(usuarioId),0);

                    this._mailSender.Enviar(new EmailEnviadoViewModel() { Email = usuarioModel.Email, Nome = usuarioModel.Nome, Token = linkToken });

                    return Request.CreateResponse(HttpStatusCode.Created, new UsuarioResponseViewModel()
                    {
                        token = codToken
                    });
                }
                catch (CPFJaCadastradoException)
                {
                    return Request.CreateResponse((HttpStatusCode)422, new ErroValidacao(validation, "CPF", "CPF já cadastrado"));
                }
                catch (EmailJaCadastradoException)
                {
                    return Request.CreateResponse((HttpStatusCode)422, new ErroValidacao(validation, "Email", "Email já cadastrado"));
                }
            }
            else
            {
                return Request.CreateResponse((HttpStatusCode)422, new ErroValidacao(validation));
            }
        }

        [BasicAuthentication]
        public HttpResponseMessage Get(string token)
        {

            Token usuarioToken = this._tokenEngine.TokenAtivacao(token);

            var error = new CampoInvalido()
                {
                    Campo = "Token",
                    Mensagem = "Token invalido"
                };

            if (usuarioToken != null)
            {

                try
                {
                    Usuario usuario = this._usuarioEngine.ObterPorId(usuarioToken.Id_usuario);
                   
                    string codToken = CadastraToken(usuario.UsuarioId,1);

                    if (!usuario.Ativo)
                    {
                        usuario.Ativo = true;
                        usuario = this._usuarioEngine.Atualizar(usuario);

                        //decimal posicao = AtualizarPosicao(usuario.UsuarioId);

                        PontuacaoCompartilhamento(usuario.UsuarioId);
                        Pontuacao pontuacao = this._pontuacaoEngine.PontuarPorTempo(usuario);
                        int posicao = this._pontuacaoEngine.ObterPosicao(pontuacao,usuario);
                        return Request.CreateResponse(HttpStatusCode.OK, new AtivacaoUsuarioResponse()
                        {
                            Token = codToken,
                            Nome = usuario.Nome,
                            Posicao = posicao,
                            Quiz = true
                        });
                    }
                    else
                    {
                        if (!usuario.RecrutamentoId.HasValue)
                        {
                            Boolean quiz = true;
                            GabaritoQuiz quizExists = this._quizEngine.ObterPorUsuario(usuario.UsuarioId);
                            if (quizExists != null)
                            {
                                quiz = false;
                            }

                            Pontuacao pontuacao = this._pontuacaoEngine.ObterPorId(usuario.UsuarioId);
                            int posicao = this._pontuacaoEngine.ObterPosicao(pontuacao, usuario);
                            return Request.CreateResponse(HttpStatusCode.OK, new AtivacaoUsuarioResponse()
                            {
                                Token = codToken,
                                Nome = usuario.Nome,
                                Posicao = posicao,
                                Quiz = quiz
                            });
                        }
                        else {
                            return Request.CreateResponse(HttpStatusCode.NotFound, error);
                        }
                    }
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, error);
                }
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        public string CadastraToken(int usuarioId,int tipo) {
            var now = DateTime.Now;

            var token = new Token()
            {
                CodigoToken = Guid.NewGuid().ToString().Replace("-", ""),
                TipoToken = tipo,
                DataCriacao = now,
                Id_usuario = usuarioId
            };
            string codToken = this._tokenEngine.Cadastrar(token);

            return codToken;
        }
        

        public void CadastrarPosicao(int usuarioId)
        {
            var pontuacao = new Pontuacao()
            {
                UsuarioId = usuarioId,
                TotalPontos = 0
            };

            decimal pontuacaoResult = this._pontuacaoEngine.Cadastrar(pontuacao);
        }

        public void CadastrarCompartilhamento(string token,int usuarioId) {
            if (token != null) {
                Token tokenResult = this._tokenEngine.ListarToken(token);
                if (tokenResult != null) {
                    var compartilhamento = new Compartilhamento()
                    {
                        TokenId = tokenResult.Tokenid,
                        UsuarioId = usuarioId,
                        DataCriacao = DateTime.Now,
                        Ativo = 0,
                    };

                    int compartilhamentoResult = this._compartilhamentoEngine.Cadastrar(compartilhamento);
                }
            }
        }

        public void PontuacaoCompartilhamento(int usuarioId)
        {
            Compartilhamento compartilhamento = this._compartilhamentoEngine.ObterPorId(usuarioId);
            if (compartilhamento != null) {
                compartilhamento.Ativo = 1;
                Compartilhamento CompartilhamentoResult = this._compartilhamentoEngine.Atualizar(compartilhamento);

                Pontuacao pontuacao = this._pontuacaoEngine.PontuarCompartilhamento(CompartilhamentoResult);
            }
        }
    }
}
