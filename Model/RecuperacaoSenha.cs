using System;

namespace Model
{
    public class RecuperacaoSenha
    {
        public int RecuperacaoSenhaId { get; set; }
        public string Token { get; set; }
        public int OperadorId { get; set; }
        public bool Valido { get; set; }
        public DateTime DataCadastro { get; set; }

        public Operador Operador { get; set; }
    }
}
