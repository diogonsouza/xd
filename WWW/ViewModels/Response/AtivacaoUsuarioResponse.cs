using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Response
{
    public class AtivacaoUsuarioResponse
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("posicao")]
        public int Posicao { get; set; }
        [JsonProperty("mostrarQuiz")]
        public Boolean Quiz { get; set; }
    }
}