using FluentValidation;

namespace Admin.ViewModels.Validators
{
    public class RecuperacaoSenhaEditViewModelValidator : AbstractValidator<RecuperacaoSenhaEditViewModel>
    {
        public RecuperacaoSenhaEditViewModelValidator()
        {
            this.RuleFor(x => x.Senha).NotEmpty();
            this.RuleFor(x => x.ConfirmaSenha).NotEmpty();
            this.RuleFor(x => x.ConfirmaSenha).Equal(x => x.Senha).WithMessage("Senha e Confirmação divergentes");  
        }
    }
}