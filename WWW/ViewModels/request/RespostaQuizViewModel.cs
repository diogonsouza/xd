using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Request
{
    public class RespostasQuizViewModel
    {
        [JsonProperty("codigoPergunta")]
        public int CodigoPergunta { get; set; }
        [JsonProperty("codigoResposta")]
        public string RespostaId { get; set; }
        [JsonProperty("Resposta")]
        public string Resposta { get; set; }
    }
}
