using Fbiz.Framework.Core;
using Fbiz.Framework.Core.Cryptography;
using FluentValidation.Results;
using Model;
using System;

namespace Admin.ViewModels
{
    public class OperadorEditViewModel
    {
        public int OperadorId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
        public bool Ativo { get; set; }
        public string DataCadastro { get; set; }
        public ValidationResult ValidationResult { get; set; }


        public OperadorEditViewModel()
        {
            this.Ativo = true;
            this.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
        }

        public OperadorEditViewModel(Operador operador)
            : this()
        {
            this.OperadorId = operador.OperadorId;
            this.Nome = operador.Nome;
            this.Login = operador.Login;
            this.Ativo = operador.Ativo;
            this.DataCadastro = operador.DataCadastro.ToString("dd/M/yyyy");
        }

        public void Parse(Operador model)
        {
            model.OperadorId = this.OperadorId;
            model.Nome = this.Nome;
            model.Login = this.Login;
            if (!string.IsNullOrEmpty(this.Senha))
                model.Senha = getByteArray(this.Senha);
            model.Ativo = this.Ativo;
            model.DataCadastro = DateTime.ParseExact(this.DataCadastro, "d/M/yyyy", null);
        }

        private byte[] getByteArray(string senha)
        {
            return IoCWrapper.Container.Resolve<Rijndael>().Encode(senha);
        }
    }
}