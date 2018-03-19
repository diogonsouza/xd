using FluentValidation;

namespace Admin.ViewModels.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            this.RuleFor(x => x.Usuario).NotEmpty();
            this.RuleFor(x => x.Senha).NotEmpty();
        }
    }
}