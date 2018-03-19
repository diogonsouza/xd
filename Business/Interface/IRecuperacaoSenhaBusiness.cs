using Fbiz.Framework.Business;
using Model;

namespace Business.Interface
{
    public interface IRecuperacaoSenhaBusiness : IBusiness<RecuperacaoSenha>
    {
        RecuperacaoSenha Obter(string token);

        void InativarRegistrosAntigos(int operadorId);
        RecuperacaoSenha Criar(int operadorId);
    }
}
