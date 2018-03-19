using Fbiz.Framework.Business;
using Model;
using PagedList;

namespace Business.Interface
{
    public interface IPontuacaoBusiness : IBusiness<Pontuacao>
    {
        Pontuacao ObterPorUsuario(int usuarioId);
        Pontuacao[] ListarPontuacao();
        Pontuacao[] ListarPontuacaoAtiva();
        int ObterPosicao(Pontuacao pontuacao, Usuario usuario);
        int ObterRepetidos(Pontuacao pontuacao, Usuario usuario);
        int ObterPorDataDesenpate(Pontuacao pontuacao, Usuario usuario);
        Pontuacao[] ListarRecrutamento(int size);
        IPagedList<Pontuacao> ListarPaginado(int pageNumber, int pageSize);
    }
}
