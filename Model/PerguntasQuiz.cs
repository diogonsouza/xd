using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class PerguntasQuiz
    {

        public int PerguntasQuizId { get; set; }
        public int CodigoPergunta { get; set; }
        public string DescricaoPergunta { get; set; }
        public Boolean PerguntaPerfil { get; set; }
    }
}
