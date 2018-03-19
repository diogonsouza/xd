using CsvHelper.Configuration;
using Model;
using System;

namespace Admin.ViewModels
{
    public class RelatorioExportViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Profissao { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Pontuacao { get; set; }


        public RelatorioExportViewModel(Pontuacao model)
        {
            this.Nome = model.Usuario.Nome;
            this.CPF = model.Usuario.Cpf;
            this.Email = model.Usuario.Email;
            this.DataCriacao = model.Usuario.DataCriacao;
            this.Pontuacao = model.TotalPontos;
            this.Profissao = model.Usuario.Profissao;
            this.Estado = model.Usuario.Estado;
            this.DataNascimento = model.Usuario.DataNascimento;
        }
    }

    public sealed class RelatorioExportViewModelMap: ClassMap<RelatorioExportViewModel>
    {
        public RelatorioExportViewModelMap()
        {
            AutoMap();
            Map(m => m.Email).Name("E-Mail");
            Map(m => m.DataCriacao).Name("Data Criacao");
        }
    }
}