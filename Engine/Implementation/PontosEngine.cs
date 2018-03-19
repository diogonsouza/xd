using System;
using Business.Interface;
using Engine.Interface;
using Fbiz.Framework.Core.Cryptography;
using Model;

namespace Engine.Implementation
{
    public class PontosEngine : IPontosEngine
    {
        private readonly IPontosBusiness _pontosBusiness;

        public PontosEngine(SymmetricBase crypto,
                             IPontosBusiness pontosBusiness)
        {
            this._pontosBusiness = pontosBusiness;
        }

        public int Cadastrar(RegrasPontuacao pontos)
        {
            pontos.RegrasPontuacaoId = atualizarBase(pontos);
            return pontos.RegrasPontuacaoId;
        }

        private int atualizarBase(RegrasPontuacao pontos)
        {
            RegrasPontuacao pontosResult = cadastrarToken(pontos);
            return pontosResult.RegrasPontuacaoId;
        }

        private RegrasPontuacao cadastrarToken(RegrasPontuacao pontos)
        {
            this._pontosBusiness.Add(pontos);
            try
            {
                this._pontosBusiness.Save();
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

            return pontos;
        }



        public RegrasPontuacao ObterPorTipo(int tipo)
        {

            RegrasPontuacao t = this._pontosBusiness.ObterPorTipo(tipo);

            return t;
        }

    }
}
