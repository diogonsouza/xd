using Business.Interface;
using Engine.Interface;
using Model;
using System.Linq;

namespace Engine.Implementation
{
    public class RecrutamentoEngine : IRecrutamentoEngine
    {
        private readonly IRecrutamentoBusiness _recrutamentoBusiness;
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IPontuacaoBusiness _pontuacaoBusiness;

        public RecrutamentoEngine(IRecrutamentoBusiness recrutamentoBusiness, IUsuarioBusiness usuarioBusiness,
            IPontuacaoBusiness pontuacaoBusiness)
        {
            this._recrutamentoBusiness = recrutamentoBusiness;
            this._usuarioBusiness = usuarioBusiness;
            this._pontuacaoBusiness = pontuacaoBusiness;
        }

        public Pontuacao[] Recrutar(int size)
        {
            var recrutados = _pontuacaoBusiness.ListarRecrutamento(size);
            if (!recrutados.Any())
                return default(Pontuacao[]);

            var recrutamento = obterNovoRecrutamento();
            definirRecrutados(recrutados.Select(x => x.Usuario).ToArray(), recrutamento.RecrutamentoId);

            return recrutados;
        }

        private Recrutamento obterNovoRecrutamento()
        {
            var recrutamento = new Recrutamento();
            _recrutamentoBusiness.Add(recrutamento);
            _recrutamentoBusiness.Save();

            return recrutamento;
        }

        private void definirRecrutados(Usuario[] usuarios, int idRecrutamento)
        {
            foreach (var usuario in usuarios)
            {
                usuario.RecrutamentoId = idRecrutamento;
                _usuarioBusiness.Update(usuario);
            }

            _usuarioBusiness.Save();
        }

    }
}
