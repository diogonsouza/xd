using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class GabaritoQuiz
    {

        public int GabaritoId { get; set; }
        public int CodigoPergunta { get; set; }
        public int UsuarioId { get; set; }
        public int RespostaId { get; set; }
        public string Resposta { get; set; }
    }
}
