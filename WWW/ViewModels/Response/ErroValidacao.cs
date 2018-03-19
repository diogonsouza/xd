using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Response
{
    public class ErroValidacao
    {
        [JsonProperty("camposInvalidos")]
        public CampoInvalido[] CamposInvalidos { get; set; }

        public ErroValidacao()
        {

        }

        public ErroValidacao(ValidationResult validation)
        {
            this.CamposInvalidos =
                           validation.Errors.Select(x => new CampoInvalido()
                           {
                               Campo = x.PropertyName,
                               Mensagem = x.ErrorMessage
                           }).ToArray();
        }
        public ErroValidacao(ValidationResult validation, string campoAdicional, string mensagem)
        {
            var camposInvalidos = validation.Errors.Select(x => new CampoInvalido()
            {
                Campo = x.PropertyName,
                Mensagem = x.ErrorMessage
            }).ToList();
            camposInvalidos.Add(new CampoInvalido()
            {
                Campo = campoAdicional,
                Mensagem = mensagem
            });
            this.CamposInvalidos = camposInvalidos.ToArray();


        }
    }
}