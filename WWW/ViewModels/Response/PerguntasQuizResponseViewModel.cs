using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Response
{
    public class PerguntasQuizResponseViewModel
    {
        [JsonProperty("perguntas")]
        public List< PerguntasVsRespostasQuizResponseViewModel> perguntas { get; set; }
    }
}
