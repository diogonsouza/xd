using Model;
using System;

namespace Admin.ViewModels
{
    public class RelatorioViewModel
    {
        public string NomeCliente { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Pontuacao { get; set; }
        public bool Recrutado { get; set; }



        public RelatorioViewModel(Pontuacao model)
        {
            this.NomeCliente = model.Usuario.Nome;
            this.Email = model.Usuario.Email;
            this.DataCriacao = model.Usuario.DataCriacao;
            this.Pontuacao = model.TotalPontos;
            this.Recrutado = model.Usuario.RecrutamentoId.HasValue;
        }
    }
}