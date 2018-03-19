using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class Compartilhamento
    {

        public int CompartilhamentoId { get; set; }
        public int TokenId { get; set; }
        public int UsuarioId { get; set; }
        public int Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        
    }
}
