using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fbiz.Framework.Business;
using Model;
using PagedList;

namespace Business.Interface
{
    public interface ITokenBusiness : IBusiness<Token>
    {
        Token ObterPorUsuario(int usuarioId);
        Token ObterPorToken(string token);
        Token[] ListarTokens();
        Token ListarToken(string token);
        Token OberterPorId(int tokenId);
    }
}
