using Admin.ViewModels;
using Admin.WebCommon;
using Business.Interface;
using Fbiz.Framework.Core.Cryptography;
using System;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class RecuperacaoSenhaController : Controller
    {
        private readonly IRecuperacaoSenhaBusiness _recuperacaoSenhaBusiness;
        private readonly IOperadorBusiness _operadorBusiness;
        private readonly Rijndael _rijndael;
        private readonly IMailSender _mailSender;

        private const string MENSAGEM_SUCESSO = @"Um email foi enviado para o endereço registrado em seu cadastro, onde será possível alterar sua senha de acesso";


        public RecuperacaoSenhaController(IRecuperacaoSenhaBusiness recuperacaoSenhaBusiness,
                                          IOperadorBusiness operadorBusiness,
                                          Rijndael rijndael,
                                          IMailSender mailSender)
        {
            this._recuperacaoSenhaBusiness = recuperacaoSenhaBusiness;
            this._operadorBusiness = operadorBusiness;
            this._rijndael = rijndael;
            this._mailSender = mailSender;
        }


        public ActionResult Index(string token)
        {
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Index", "Login");
            else
            {
                var model = _recuperacaoSenhaBusiness.Obter(token);
                if (model != null)
                {
                    var viewModel = new RecuperacaoSenhaEditViewModel()
                    {
                        OperadorId = model.OperadorId
                    };
                    return View(viewModel);
                }
                else
                {
                    return View("TokenExpirado");
                }
            }
        }

        [HttpPost]
        public ActionResult Index(RecuperacaoSenhaEditViewModel viewModel)
        {
            var validationResult = this.Validate(viewModel);
            if (validationResult.IsValid)
            {
                var operador = this._operadorBusiness.GetByKey(viewModel.OperadorId);
                operador.Senha = this._rijndael.Encode(viewModel.Senha);

                this._operadorBusiness.Update(operador);
                this._operadorBusiness.Save();

                this._recuperacaoSenhaBusiness.InativarRegistrosAntigos(operador.OperadorId);

                return View("Sucesso", (object)"Senha alterada com sucesso");
            }
            else
            {
                viewModel.Erros = validationResult.Errors;
            }

            return View(viewModel);
        }

        public ActionResult Vizualizar()
        {
            return View("SolicitarNovaSenha", new RecuperacaoSenhaViewModel());
        }

        public ActionResult SolicitarNovaSenha()
        {
            return View(new RecuperacaoSenhaViewModel());
        }

        [HttpPost]
        public ActionResult SolicitarNovaSenha(RecuperacaoSenhaViewModel viewModel)
        {
            var operador = this._operadorBusiness.Obter(viewModel.Login);
            viewModel.OperadorValido = operador != null;

            var validationResult = this.Validate(viewModel);
            if (validationResult.IsValid)
            {
                this._recuperacaoSenhaBusiness.InativarRegistrosAntigos(operador.OperadorId);
                var model = this._recuperacaoSenhaBusiness.Criar(operador.OperadorId);

                viewModel.Token = model.Token;

                try
                {
                    this._mailSender.Enviar(new EmailEnviadoViewModel() { Email = operador.Login, Nome = operador.Nome, Token = model.Token });
                    viewModel.Mensagem = MENSAGEM_SUCESSO;
                    viewModel.EmailEnviado = true;
                }
                catch (Exception ex)
                {
                    viewModel.EmailEnviado = false;
                    viewModel.Mensagem = ex.ToString();
                }

                return View("Sucesso", (object)viewModel.Mensagem);
            }
            else
            {
                viewModel.Erros = validationResult.Errors;
            }

            return View(viewModel);
        }
    }
}