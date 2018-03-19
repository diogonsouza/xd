using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fbiz.Framework.Business;
using Model;
using PagedList;

namespace Business.Interface
{
    public interface IUsuarioBusiness : IBusiness<Usuario>
    {
        Usuario ObterPorEmail(string email);
        Usuario ObterPorId(int usuarioId);
        IPagedList<Usuario> Listar(int pageNumber, int pageSize, string cpf = null, string email = null);
        Usuario[] ListarUsuariosReceberamAmostras();
        Usuario[] ListarUsuariosReceberamNaoResponderam();
        Usuario[] ListarUsuariosReceberamResponderamPesquisaIncompleta();
        Usuario[] ListarUsuariosReceberamResponderamPesquisaCompleta();
        int UsuariosDisponiveisRecrutamento();
        int QuantidadeRecrutados();
    }
}
