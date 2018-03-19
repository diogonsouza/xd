using FluentValidation.Results;
using System.Collections.Generic;

namespace Admin.ViewModels
{
    public class RecuperacaoSenhaViewModel
    {
        public string Login { get; set; }
        public bool OperadorValido { get; set; }
        public string Token { get; set; }
        public string Mensagem { get; set; }
        public bool EmailEnviado { get; set; }
        public IEnumerable<ValidationFailure> Erros { get; set; }

        public RecuperacaoSenhaViewModel()
        {
            this.Erros = new ValidationFailure[0];
        }  
    }
}