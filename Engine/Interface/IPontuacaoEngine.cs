using Model;
using Business.Interface;

namespace Engine.Interface
{
    public interface IPontuacaoEngine
    {
        decimal Cadastrar(Pontuacao pontuacao);
        Pontuacao ObterPorId(int usuarioId);
        Pontuacao Atualizar(Pontuacao pontuacao);
        Pontuacao PontuarCompartilhamento(Compartilhamento compartilhamento);
        Pontuacao PontuarPorTempo(Usuario usuario);
        Pontuacao PontuarQuiz(Usuario usuario);
        int ObterPosicao(Pontuacao pontuacao, Usuario usuario);
    }
}
