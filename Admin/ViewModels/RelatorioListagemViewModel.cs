using FluentValidation.Results;
using Model;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace Admin.ViewModels
{
    public class RelatorioListagemViewModel
    {
        public StaticPagedList<RelatorioViewModel> Itens { get; internal set; }
        public int PageNumber { get; set; }
        public int PageSize { get; internal set; }
        public IEnumerable<ValidationFailure> Erros { get; set; }

        public RelatorioListagemViewModel(IPagedList<Pontuacao> itens)
        {
            this.Itens = new StaticPagedList<RelatorioViewModel>(itens.Select(x => new RelatorioViewModel(x)), itens);
        }
    }
}