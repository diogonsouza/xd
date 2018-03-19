using Model;
using PagedList;
using System.Linq;

namespace Admin.ViewModels
{
    public class OperadorListagemViewModel
    {
        public IPagedList<OperadorViewModel> Operador { get; set; }


        public OperadorListagemViewModel(IPagedList<Operador> operador)
        {
            this.Operador = new StaticPagedList<OperadorViewModel>(operador.Select(x => new OperadorViewModel(x)), operador);
        }
    }
}