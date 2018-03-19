using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.request
{
    public class AtivarUsuarioViewModel
    {

        [JsonProperty("token")]
        public string token { get; set; }
    }
}