using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class Pontuacao
    {
        public int PontuacaoId { get; set; }
        public int UsuarioId { get; set; }
        public Decimal TotalPontos { get; set; }

        public Usuario Usuario { get; set; }

    }
}
