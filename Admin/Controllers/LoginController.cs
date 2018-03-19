using Admin.ViewModels;
using Business.Interface;
using FluentValidation.Results;
using System.Web.Mvc;
using System.Web.Security;

namespace Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IOperadorBusiness _operadorBusiness;


        public LoginController(IOperadorBusiness operadorBusiness)
        {
            this._operadorBusiness = operadorBusiness;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            var validationResult = this.Validate(model);
            if (validationResult.IsValid)
            {
                if (Membership.ValidateUser(model.Usuario, model.Senha))
                {
                    var operador = this._operadorBusiness.Obter(model.Usuario);

                    FormsAuthentication.SetAuthCookie(operador.OperadorId.ToString(), false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model.Erros = new FluentValidation.Results.ValidationFailure[]
                                    {
                                        new ValidationFailure("Usuario", "Usuário ou senha inválidos.")
                                    };
                }
            }
            else
            {
                model.Erros = validationResult.Errors;
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
