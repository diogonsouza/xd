using System;
using Business.Interface;
using Engine.Interface;
using Fbiz.Framework.Core.Cryptography;
using Model;

namespace Engine.Implementation
{
    public class TokenEngine : ITokenEngine
    {
        private readonly ITokenBusiness _tokenBusiness;

        public TokenEngine(SymmetricBase crypto,
                             ITokenBusiness tokenBusiness)
        {
            this._tokenBusiness = tokenBusiness;
        }

        public string Cadastrar(Token token)
        {
            token.CodigoToken = atualizarBase(token);
            return token.CodigoToken;
        }

        private string atualizarBase(Token token)
        {
            Token tokenResult = cadastrarToken(token);
            return tokenResult.CodigoToken;
        }

        private Token cadastrarToken(Token token)
        {
            var now = DateTime.Now;
            token.DataCriacao = now;

            this._tokenBusiness.Add(token);
            try
            {
                this._tokenBusiness.Save();
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

            return token;
        }

        public Token TokenAtivacao(string token) {
            
            Token t = this._tokenBusiness.ObterPorToken(token);

            return t;
        }

        public Token ListarToken(string token)
        {

            Token t = this._tokenBusiness.ListarToken(token);

            return t;
        }

        public Token ObterPorId(int tokenId)
        {

            Token t = this._tokenBusiness.OberterPorId(tokenId);

            return t;
        }

    }
}
