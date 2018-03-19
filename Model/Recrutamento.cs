using System;

namespace Model
{
    public class Recrutamento
    {   
        public int RecrutamentoId { get; set; }
        public DateTime DataCriacao { get; set; }

        public Recrutamento()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
