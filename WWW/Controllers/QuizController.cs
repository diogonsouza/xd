using Engine.Interface;
using Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WWW.Filters;
using WWW.ViewModels.Request;
using WWW.ViewModels.Response;

namespace WWW.Controllers
{
    public class QuizController : ApiController
    {
        private readonly IUsuarioEngine _usuarioEngine;
        private readonly ITokenEngine _tokenEngine;
        private readonly IPontuacaoEngine _pontuacaoEngine;
        private readonly IQuizEngine _quizEngine;
        private readonly IPerguntaEngine _perguntaEngine;
        private readonly IRespostasEngine _respostaEngine;

        public QuizController(IUsuarioEngine usuarioEngine, ITokenEngine tokenEngine, IPontuacaoEngine pontuacaoEngine,
            IQuizEngine quizengine, IPerguntaEngine perguntaEngine, IRespostasEngine respostaEngine)
        {
            this._tokenEngine = tokenEngine;
            this._usuarioEngine = usuarioEngine;
            this._pontuacaoEngine = pontuacaoEngine;
            this._quizEngine = quizengine;
            this._perguntaEngine = perguntaEngine;
            this._respostaEngine = respostaEngine;
        }

        [BasicAuthentication]
        public HttpResponseMessage Post(RespostasQuizPostViewModel respostaQuiz)
        {
            var error = new CampoInvalido()
            {
                Campo = "Token",
                Mensagem = "Token invalido"
            };

            var  respostaQuizObj = respostaQuiz.ConverterRespostaQuizObj();

            Token token = this._tokenEngine.TokenAtivacao(respostaQuizObj.Token);

            if (token != null)
            {
                try
                {
                   
                    GabaritoQuiz quizExists = _quizEngine.ObterPorUsuario(token.Id_usuario);
                    if (quizExists == null)
                    {
                        Usuario usuario = AtualizaUsuario(respostaQuizObj, token.Id_usuario);

                        if ((!usuario.RecrutamentoId.HasValue) && usuario.Ativo==true)
                        {
                            Char delimiter = ',';
                            foreach (RespostasQuizViewModel resposta in respostaQuiz.RespostasQuizArray)
                            {
                                string[] respostas = resposta.RespostaId.Split(delimiter);
                                foreach (string r in respostas)
                                {
                                    if (r.Trim() != "") { 
                                        var respostaCadastro = new GabaritoQuiz()
                                        {
                                            CodigoPergunta = resposta.CodigoPergunta,
                                            UsuarioId = token.Id_usuario,
                                            RespostaId = int.Parse(r),
                                            Resposta = resposta.Resposta
                                        };

                                        GabaritoQuiz resp = this._quizEngine.Cadastrar(respostaCadastro);
                                    }
                                }
                            }

                            string codToken = CadastraToken(token.Id_usuario, 1);

                            Pontuacao pontuacao = this._pontuacaoEngine.PontuarQuiz(usuario);

                            int posicao = this._pontuacaoEngine.ObterPosicao(pontuacao, usuario);

                            return Request.CreateResponse(HttpStatusCode.Created, new QuizResponseViewModel()
                            {
                                token = codToken,
                                posicao = posicao
                            });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, error);
                        }
                    }
                    else
                    {
                        error.Campo = "Quiz";
                        error.Mensagem = "Quiz já cadastrado";
                        return Request.CreateResponse(HttpStatusCode.NotFound, error);
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

        [BasicAuthentication]
        public HttpResponseMessage Get()
        {

            PerguntasQuiz[] perguntas = this._perguntaEngine.ObterPerguntas();

            PerguntasQuizResponseViewModel response = new PerguntasQuizResponseViewModel();
            response.perguntas = new List<PerguntasVsRespostasQuizResponseViewModel>();
            foreach (PerguntasQuiz p in perguntas) {
                
                PerguntasVsRespostasQuizResponseViewModel perguntasVsRespostas = new PerguntasVsRespostasQuizResponseViewModel();
                perguntasVsRespostas.pergunta = p;
                List<RespostasQuiz> respostas = this._respostaEngine.ObterRespostas(p.CodigoPergunta);
                perguntasVsRespostas.respostas = respostas;

                response.perguntas.Add(perguntasVsRespostas);
            }


            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

            public Usuario AtualizaUsuario(RespostasQuizObjeto respostaQuizObj,int usuarioId) {
            Usuario usuario = _usuarioEngine.ObterPorId(usuarioId);

            usuario.Profissao = respostaQuizObj.Profissao;
            usuario.Estado = respostaQuizObj.Estado;
            usuario.Cidade = respostaQuizObj.Cidade;
            usuario.DataNascimento = respostaQuizObj.DataNascimento;
            usuario = this._usuarioEngine.Atualizar(usuario);

            return usuario;
        }

        public string CadastraToken(int usuarioId, int tipo)
        {
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
    }
}