using Model;
using Business.Interface;

namespace Engine.Interface
{
    public interface ICompartilhamentoEngine
    {
        int Cadastrar(Compartilhamento compartilhamento);
        Compartilhamento ObterPorId(int usuarioId);
        Compartilhamento Atualizar(Compartilhamento compartilhamento);
    }
}
