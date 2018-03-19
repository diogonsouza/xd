using FluentValidation;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WWW.ViewModels.Request;

namespace WWW.ViewModels.Validation
{
    public class UsuarioPostValidator : AbstractValidator<UsuarioPostViewModel>
    {
        public UsuarioPostValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            this.RuleFor(x => x.Nome).NotEmpty()
                                     .Length(1, 255);


            this.RuleFor(x => x.Email).NotEmpty()
                                      .EmailAddress()
                                      .Length(1, 254);
            this.RuleFor(x => x.CPF).NotEmpty()
                                  .Matches(@"^\d{3}(?:\.?\d{3}){2}-?\d{2}$")
                                  .Must(cpfValido);
        }

        private bool enumValido<T>(string value) where T : struct, IConvertible
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("T must be an Enum");
            var values = Enum.GetValues(typeof(T));
            value = value?.ToLowerInvariant().Trim();
            foreach (var enumValue in values)
                if (enumValue.ToString().ToLowerInvariant().Equals(value))
                    return true;
            return false;
        }
        private bool cpfValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

    }
}
