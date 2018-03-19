using FluentValidation.Results;
using System.Collections.Generic;

namespace Admin.ViewModels
{
    public class LoginViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public IEnumerable<ValidationFailure> Erros { get; set; }

        public LoginViewModel()
        {
            this.Erros = new ValidationFailure[0];
        }
    }
}