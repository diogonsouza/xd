using System;

namespace Model
{
    public class Operador
    {
        public int OperadorId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public byte[] Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
