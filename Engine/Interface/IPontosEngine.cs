using Model;
using Business.Interface;

namespace Engine.Interface
{
    public interface IPontosEngine
    {
        int Cadastrar(RegrasPontuacao pontos);

        RegrasPontuacao ObterPorTipo(int tipo);
    }
}
