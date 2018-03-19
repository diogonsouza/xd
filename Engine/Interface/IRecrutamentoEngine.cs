using Model;
using Business.Interface;

namespace Engine.Interface
{
    public interface IRecrutamentoEngine
    {
        Pontuacao[] Recrutar(int size);
    }
}
