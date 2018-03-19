using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class RespostasQuiz
    {

        public int RespostasQuizId { get; set; }
        public int CodigoPergunta { get; set; }
        public int CodigoResposta { get; set; }
        public string DescricaoResposta { get; set; }
        public int? PerfilId { get; set; }
    }
}
