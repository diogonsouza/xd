using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.ViewModels.Response
{
    public class PerguntasVsRespostasQuizResponseViewModel
    {
        [JsonProperty("pergunta")]
        public PerguntasQuiz pergunta { get; set; }

        [JsonProperty("resposta")]
        public List<RespostasQuiz> respostas { get; set; }


    }
}
