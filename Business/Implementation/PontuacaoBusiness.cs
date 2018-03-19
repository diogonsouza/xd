using System.Linq;
using Business.Interface;
using Model;
using Fbiz.Framework.Business;
using Fbiz.Framework.Core.Cryptography;
using System.Data.Entity;
using PagedList;

namespace Business.Implementation
{
    public class PontuacaoBusiness : BusinessBase<Pontuacao>, IPontuacaoBusiness
    {
        private readonly SymmetricBase _symmetricBase;

        public PontuacaoBusiness(SymmetricBase symmetricBase)
        {
            this._symmetricBase = symmetricBase;
        }

        public Pontuacao ObterPorUsuario(int usuarioId)
        {
            return this.GetQuery().Where(x => x.UsuarioId == usuarioId).FirstOrDefault();
        }

        public Pontuacao[] ListarPontuacao()
        {
            var pontuacaoQuery = this.GetQuery();
            var resultado = pontuacaoQuery.ToArray();
            return resultado;
        }

        public Pontuacao[] ListarPontuacaoAtiva()
        {
            var pontuacaoQuery = this.GetQuery()
                .Include(x => x.Usuario)
                .Where(x=> !x.Usuario.RecrutamentoId.HasValue)
                .OrderByDescending(x =>x.TotalPontos);

            var resultado = pontuacaoQuery.ToArray();
            return resultado;
        }

        public int ObterPosicao(Pontuacao pontuacao,Usuario usuario)
        {
            var pontuacaoQuery = this.GetQuery()
                .Include(x => x.Usuario)
                .Where(x => x.TotalPontos >= pontuacao.TotalPontos)
                .Where(x => !x.Usuario.RecrutamentoId.HasValue)
                .OrderByDescending(x => x.TotalPontos)
                .ThenBy(x => x.Usuario.DataCriacao)
                .Count();
            
            //var resultado = pontuacaoQuery.Count();

            return pontuacaoQuery;
        }

        public int ObterRepetidos(Pontuacao pontuacao, Usuario usuario)
        {
            var pontuacaoQuery = this.GetQuery()
                .Include(x => x.Usuario)
                .Where(x => x.TotalPontos == pontuacao.TotalPontos && x.Usuario.UsuarioId != usuario.UsuarioId)
                .Where(x => !x.Usuario.RecrutamentoId.HasValue)
                .OrderByDescending(x => x.TotalPontos)
                .ThenBy(x => x.Usuario.DataCriacao)
                .Count();

            return pontuacaoQuery;
        }

        public int ObterPorDataDesenpate(Pontuacao pontuacao, Usuario usuario)
        {
            var pontuacaoQuery = this.GetQuery()
                .Include(x => x.Usuario)
                .Where(x => x.TotalPontos == pontuacao.TotalPontos && x.Usuario.DataCriacao <= usuario.DataCriacao)
                .Where(x => !x.Usuario.RecrutamentoId.HasValue && x.Usuario.UsuarioId != usuario.UsuarioId)
                .OrderByDescending(x => x.TotalPontos)
                .ThenBy(x => x.Usuario.DataCriacao)
                .Count();

            return pontuacaoQuery;
        }

        public Pontuacao[] ListarRecrutamento(int size)
        {
            return GetQuery()
                .Where(x => x.Usuario.Ativo)
                .Where(x => !x.Usuario.RecrutamentoId.HasValue)
                .Include(x => x.Usuario)
                .OrderByDescending(x => x.TotalPontos)
                .ThenBy(x => x.Usuario.DataCriacao)
                .Take(size)
                .ToArray();
        }

        public IPagedList<Pontuacao> ListarPaginado(int pageNumber, int pageSize)
        {
            return GetQuery()
                .Include(x => x.Usuario)
                .OrderByDescending(x => x.TotalPontos)
                .ThenBy(x => x.Usuario.DataCriacao)
                .ToPagedList(pageNumber, pageSize);
        }
    }
}
