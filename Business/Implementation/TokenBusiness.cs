using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Interface;
using Model;
using Fbiz.Framework.Business;
using PagedList;
using System.Data.Entity;
using Business.Extensions;
using Fbiz.Framework.Core.Cryptography;

namespace Business.Implementation
{
    public class TokenBusiness : BusinessBase<Token>, ITokenBusiness
    {
        private readonly SymmetricBase _symmetricBase;

        public TokenBusiness(SymmetricBase symmetricBase)
        {
            this._symmetricBase = symmetricBase;
        }

        public Token ObterPorUsuario(int usuarioId)
        {
            return this.GetQuery().Where(x => x.Id_usuario == usuarioId).FirstOrDefault();
        }

        public Token[] ListarTokens()
        {
            var tokenQuery = this.GetQuery();
            var resultado = tokenQuery.ToArray();
            return resultado;
        }

        public Token ObterPorToken(string token)
        {
            var tokenQuery = this.GetQuery().Where(x => x.CodigoToken == token).Where(x=> x.TipoToken==0).FirstOrDefault(); 
            var resultado = tokenQuery;
            return resultado;
        }

        public Token ListarToken(string token)
        {
            var tokenQuery = this.GetQuery().Where(x => x.CodigoToken == token).Where(x => x.TipoToken == 1).FirstOrDefault(); 
            var resultado = tokenQuery;
            return resultado;
        }

        public Token OberterPorId(int tokenId)
        {
            var tokenQuery = this.GetQuery().Where(x => x.Tokenid == tokenId).FirstOrDefault(); 
            var resultado = tokenQuery;
            return resultado;
        }
        
    }
}
