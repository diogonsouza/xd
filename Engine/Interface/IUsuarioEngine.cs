using Business.Interface;
using Model;

namespace Engine.Interface
{
    public interface IUsuarioEngine
    {
        string Cadastrar(Usuario usuario);

        Usuario Atualizar(Usuario usuario);

        Usuario ObterPorId(int usuarioId);
    }
}
