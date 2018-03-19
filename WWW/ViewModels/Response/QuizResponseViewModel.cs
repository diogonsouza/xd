using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Response
{
    public class QuizResponseViewModel
    {
        [JsonProperty("token")]
        public string token { get; set; }
        [JsonProperty("posicao")]
        public int posicao { get; set; }
    }
}
