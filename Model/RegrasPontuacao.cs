using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class RegrasPontuacao
    {
        public int RegrasPontuacaoId { get; set; }
        public int Tipo { get; set; }
        public Decimal Valor { get; set; }
        public int Recorrencia { get; set; }
        public int TipoRecorrencia { get; set; }
        public DateTime DataInicio { get; set; }
    }
}
