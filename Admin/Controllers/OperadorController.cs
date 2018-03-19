using Admin.ViewModels;
using Business.Interface;
using Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class OperadorController : Controller
    {
        private readonly IOperadorBusiness _operadorBusiness;


        public OperadorController(IOperadorBusiness operadorBusiness)
        {
            this._operadorBusiness = operadorBusiness;
        }


        [HttpGet]
        public ActionResult Index(int pageNumber = 1, int pageSize = 20)
        {
            var operadores = this._operadorBusiness.ListarTodos(pageNumber, pageSize);
            var viewModel = new OperadorListagemViewModel(operadores);
            return View(viewModel);
        }


        [HttpGet]
        public ActionResult Adicionar()
        {
            return View("Edit", new OperadorEditViewModel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Adicionar(OperadorEditViewModel viewModel)
        {
            return processarPost(viewModel);
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            var operador = this._operadorBusiness.Obter(id);
            if (operador != null)
            {
                return View("Edit", new OperadorEditViewModel(operador));
            }
            else
                throw new HttpException(404, "Not found");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Editar(OperadorEditViewModel viewModel)
        {
            return processarPost(viewModel);
        }


        private ActionResult processarPost(OperadorEditViewModel viewModel)
        {
            var validationResult = this.Validate(viewModel);

            if (validationResult.IsValid)
            {
                salvar(viewModel);
                this.FeedbackSuccess("O registro foi atualizado na base de dados.");
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.ValidationResult = validationResult;
                return View("Edit", viewModel);
            }
        }

        private void salvar(OperadorEditViewModel viewModel)
        {
            var model = viewModel.OperadorId == 0 ? new Operador() : this._operadorBusiness.Obter(viewModel.OperadorId);

            viewModel.Parse(model);

            if (model.OperadorId == 0)
                this._operadorBusiness.Add(model);
            else
                this._operadorBusiness.Update(model);

            this._operadorBusiness.Save();
        }
    }
}