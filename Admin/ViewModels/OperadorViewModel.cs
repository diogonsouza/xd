using Model;

namespace Admin.ViewModels
{
    public class OperadorViewModel
    {
        public int OperadorId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public OperadorViewModel()
        {

        }

        public OperadorViewModel(Operador operador)
        {
            this.OperadorId = operador.OperadorId;
            this.Nome = operador.Nome;
            this.Ativo = operador.Ativo;
        }
    }
}