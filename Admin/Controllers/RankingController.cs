using Admin.ViewModels;
using Business.Interface;
using Engine.Interface;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class RankingController : Controller
    {
        private readonly IPontuacaoBusiness _pontuacaoBusiness;
        private readonly IRecrutamentoEngine _recrutamentoEngine;

        public RankingController(IPontuacaoBusiness pontuacaoBusiness, IRecrutamentoEngine recrutamentoEngine)
        {
            this._pontuacaoBusiness = pontuacaoBusiness;
            this._recrutamentoEngine = recrutamentoEngine;
        }

        public ActionResult Index(int pageNumber = 1, int pageSize = 20)
        {
            var viewModel = obterLista(pageNumber, pageSize);

            return View(viewModel);
        }

        private RelatorioListagemViewModel obterLista(int pageNumber, int pageSize)
        {
            var lista = _pontuacaoBusiness.ListarPaginado(pageNumber, pageSize);
            var viewModel = new RelatorioListagemViewModel(lista);

            return viewModel;
        }
    }
}