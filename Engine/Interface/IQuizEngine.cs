using Model;
using Business.Interface;

namespace Engine.Interface
{
    public interface IQuizEngine
    {
        GabaritoQuiz Cadastrar(GabaritoQuiz quiz);
        GabaritoQuiz ObterPorUsuario(int usuarioId);
    }
}
