using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public int? RecrutamentoId { get; set; }
        public string Profissao { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public DateTime DataNascimento { get; set; }
        
    }
}
