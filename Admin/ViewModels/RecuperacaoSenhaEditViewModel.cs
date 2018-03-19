using FluentValidation.Results;
using System.Collections.Generic;

namespace Admin.ViewModels
{
    public class RecuperacaoSenhaEditViewModel
    {
        public int OperadorId { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public IEnumerable<ValidationFailure> Erros { get; set; }

        public RecuperacaoSenhaEditViewModel()
        {
            this.Erros = new ValidationFailure[0];
        }  
    }
}