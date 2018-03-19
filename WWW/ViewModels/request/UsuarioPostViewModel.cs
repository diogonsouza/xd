using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Request
{
    public class UsuarioPostViewModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("cpf")]
        public string CPF { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }


        public Usuario ConverterUsuario()
        {
            var usuario = new Usuario()
            {
                Nome = this.Nome,
                Email = this.Email.ToLower(),
                Cpf = this.CPF.Replace(".", string.Empty).Replace("-", string.Empty),
                DataCriacao = new DateTime()
            };
            return usuario;
        }
    }
}
