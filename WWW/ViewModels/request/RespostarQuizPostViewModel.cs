using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Request
{
    public class RespostasQuizPostViewModel
    {

        [JsonProperty("Respostas")]
        public RespostasQuizViewModel[] RespostasQuizArray { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("profissao")]
        public string Profissao { get; set; }
        [JsonProperty("estado")]
        public string Estado { get; set; }
        [JsonProperty("cidade")]
        public string Cidade { get; set; }
        [JsonProperty("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        public RespostasQuizObjeto ConverterRespostaQuizObj()
        {
            var respostasQuizObjeto = new RespostasQuizObjeto()
            {
                Token = this.Token,
                Profissao = this.Profissao,
                Estado = this.Estado,
                Cidade = this.Cidade,
                DataNascimento = this.DataNascimento
            };
            return respostasQuizObjeto;
        }
    }
}
