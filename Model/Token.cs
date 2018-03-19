using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class Token
    {

        public int Tokenid { get; set; }
        public int TipoToken { get; set; }
        public string CodigoToken { get; set; }
        public int Id_usuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
