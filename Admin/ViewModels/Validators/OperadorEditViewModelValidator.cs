using Business.Interface;
using Fbiz.Framework.Core;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Admin.ViewModels.Validators
{
    public class OperadorEditViewModelValidator : AbstractValidator<OperadorEditViewModel>
    {
        public OperadorEditViewModelValidator()
        {
            this.RuleFor(x => x.Nome).NotEmpty();
            this.RuleFor(x => x.Login).NotEmpty();
            this.RuleFor(x => x.Login).Must(alreadyUsed).WithMessage("E-mail já está sendo utilizado por outro operador");
            this.RuleFor(x => x.Login).Must(isValidEmail).WithMessage("E-mail em formato inválido");
            this.When(x => !string.IsNullOrEmpty(x.Senha) || x.OperadorId == 0 || !string.IsNullOrEmpty(x.ConfirmacaoSenha),
                                    () =>
                                    {
                                        RuleFor(x => x.Senha).NotEmpty();
                                        RuleFor(x => x.ConfirmacaoSenha).Equal(x => x.Senha)
                                        .WithMessage("Senha não confirmada");
                                    });
        }

        private static bool isValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private static bool alreadyUsed(OperadorEditViewModel viewModel, string email)
        {
            var operador = IoCWrapper.Container.Resolve<IOperadorBusiness>().Obter(email);

            return (operador == null || (operador.OperadorId == viewModel.OperadorId));
        }
    }
}