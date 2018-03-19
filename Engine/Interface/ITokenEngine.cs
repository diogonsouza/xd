using Model;
using Business.Interface;

namespace Engine.Interface
{
    public interface ITokenEngine
    {
        string Cadastrar(Token token);

        Token TokenAtivacao(string token);

        Token ListarToken(string token);

        Token ObterPorId(int tokenId);
    }
}
