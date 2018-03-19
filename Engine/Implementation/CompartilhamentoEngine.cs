using System;
using Business.Interface;
using Engine.Interface;
using Fbiz.Framework.Core.Cryptography;
using Model;

namespace Engine.Implementation
{
    public class CompartilhamentoEngine : ICompartilhamentoEngine
    {
        private readonly ICompartilhamentoBusiness _compartilhamentoBusiness;

        public CompartilhamentoEngine(SymmetricBase crypto,
                             ICompartilhamentoBusiness compartilhamentoBusiness)
        {
            this._compartilhamentoBusiness = compartilhamentoBusiness;
        }

        public int Cadastrar(Compartilhamento compartilhamento)
        {
            compartilhamento.CompartilhamentoId = atualizarBase(compartilhamento);
            return compartilhamento.CompartilhamentoId;
        }

        private int atualizarBase(Compartilhamento compartilhamento)
        {
            Compartilhamento compartilhamentoResult = cadastrarCompartilhamento(compartilhamento);
            return compartilhamentoResult.CompartilhamentoId;
        }

        private Compartilhamento cadastrarCompartilhamento(Compartilhamento compartilhamento)
        {
            this._compartilhamentoBusiness.Add(compartilhamento);
            try
            {
                this._compartilhamentoBusiness.Save();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string message = (ex.InnerException?.InnerException?.Message) ?? string.Empty;
                if (message.ToLower().Contains("IX_TB_SITE_USUARIO_NR_CPF".ToLower()))
                    throw new CPFJaCadastradoException();
                else if (message.ToLower().Contains("IX_TB_SITE_USUARIO_EN_EMAI".ToLower()))
                    throw new EmailJaCadastradoException();
                else throw;
            }

            return compartilhamento;
        }

        public Compartilhamento Atualizar(Compartilhamento compartilhamento)
        {
            this._compartilhamentoBusiness.Update(compartilhamento);
            this._compartilhamentoBusiness.Save();
            return compartilhamento;
        }

        public Compartilhamento ObterPorId(int usuarioId)
        {
            return this._compartilhamentoBusiness.ObterPorUsuario(usuarioId);
        }
    }
}
