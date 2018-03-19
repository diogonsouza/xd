using FluentValidation;

namespace Admin.ViewModels.Validators
{
    public class RecuperacaoSenhaViewModelValidator : AbstractValidator<RecuperacaoSenhaViewModel>
    {
        public RecuperacaoSenhaViewModelValidator()
        {
            this.RuleFor(x => x.Login).NotEmpty();
            this.RuleFor(x => x.OperadorValido).Equal(true).WithMessage("Usuário não cadatrado.");
        }
    }
}