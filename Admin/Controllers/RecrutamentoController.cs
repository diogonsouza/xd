using Admin.ViewModels;
using Business.Interface;
using CsvHelper;
using Engine.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class RecrutamentoController : Controller
    {
        private readonly IPontuacaoBusiness _pontuacaoBusiness;
        private readonly IRecrutamentoEngine _recrutamentoEngine;
        private readonly IUsuarioBusiness _usuarioBusiness;

        public RecrutamentoController(IPontuacaoBusiness pontuacaoBusiness, IRecrutamentoEngine recrutamentoEngine,
            IUsuarioBusiness usuarioBusiness)
        {
            this._pontuacaoBusiness = pontuacaoBusiness;
            this._recrutamentoEngine = recrutamentoEngine;
            this._usuarioBusiness = usuarioBusiness;
        }

        public ActionResult Index()
        {
            ViewBag.Disponiveis = _usuarioBusiness.UsuariosDisponiveisRecrutamento();
            ViewBag.Recrutados = _usuarioBusiness.QuantidadeRecrutados(); 
            return View();
        }

        public ActionResult Export(int? size)
        {
            var disponiveis = _usuarioBusiness.UsuariosDisponiveisRecrutamento();
            var recrutados = _usuarioBusiness.QuantidadeRecrutados(); 

            if (size == null || size <= 0)
            {
                ViewBag.ValidationResult = "Informe a quantidade de registros.";
                ViewBag.Disponiveis = disponiveis;
                ViewBag.Recrutados = recrutados;
                return View("Index");
            }

            if (disponiveis == 0)
            {
                ViewBag.ValidationResult = "Nenhum registro encontrado.";
                ViewBag.Disponiveis = disponiveis;
                ViewBag.Recrutados = recrutados;
                return View("Index");
            }

            var lista = _recrutamentoEngine.Recrutar(size.Value);

            var viewModel = lista.Select(x => new RelatorioExportViewModel(x));

            return downloadFile(viewModel);
           
        }

        private ActionResult downloadFile(IEnumerable<RelatorioExportViewModel> viewModel)
        {
            byte[] result;

            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(streamWriter))
            {
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.RegisterClassMap<RelatorioExportViewModelMap>();
                csvWriter.WriteRecords(viewModel);
                streamWriter.Flush();
                result = memoryStream.ToArray();
            }

            return new FileStreamResult(new MemoryStream(result), "text/csv") { FileDownloadName = string.Format("{0}_{1}.csv", "Recrutamento", DateTime.Now.ToString("yyyy_MM_dd")) };
        }

        private RelatorioListagemViewModel obterLista(int pageNumber, int pageSize)
        {
            var lista = _pontuacaoBusiness.ListarPaginado(pageNumber, pageSize);
            var viewModel = new RelatorioListagemViewModel(lista);

            return viewModel;
        }
    }
}