﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Response
{
    public class UsuarioResponseViewModel
    {
        [JsonProperty("token")]
        public string token { get; set; }
    }
}
