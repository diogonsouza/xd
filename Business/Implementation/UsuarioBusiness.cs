using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Interface;
using Model;
using Fbiz.Framework.Business;
using PagedList;
using System.Data.Entity;
using Business.Extensions;
using Fbiz.Framework.Core.Cryptography;

namespace Business.Implementation
{
    public class UsuarioBusiness : BusinessBase<Usuario>, IUsuarioBusiness
    {
        private readonly SymmetricBase _symmetricBase;

        public UsuarioBusiness(SymmetricBase symmetricBase)
        {
            this._symmetricBase = symmetricBase;
        }


        public Usuario ObterPorEmail(string email)
        {
            return this.GetQuery().Where(x => x.Email == email).FirstOrDefault();
        }


        public IPagedList<Usuario> Listar(int pageNumber, int pageSize, string cpf = null, string email = null)
        {
            var query = this.GetQuery();

            if (!string.IsNullOrEmpty(cpf))
            {
                var hash = cpf;
                query = query.Where(x => x.Cpf == hash);
            }
            if (!string.IsNullOrEmpty(email))
            {
                var hash = email;
                query = query.Where(x => x.Email == hash);
            }
            return query.OrderByDescending(x => x.UsuarioId)
                        .ToPagedList(pageNumber, pageSize);

        }
        public Usuario[] ListarUsuariosReceberamAmostras()
        {
            var usuarioQuery = this.GetQuery();
            var resultado = usuarioQuery.ToArray();
            return resultado;
        }
        public Usuario[] ListarUsuariosReceberamNaoResponderam()
        {
           
            
            var usuarioQuery = this.GetQuery();
            var resultado = usuarioQuery.ToArray();
            return resultado;
        }

        public Usuario[] ListarUsuariosReceberamResponderamPesquisaIncompleta()
        {
            var usuarioQuery = this.GetQuery();
            var resultado = usuarioQuery.ToArray();
            
            return resultado;
        }

        public Usuario[] ListarUsuariosReceberamResponderamPesquisaCompleta()
        {
            var usuarioQuery = this.GetQuery();
            var resultado = usuarioQuery.ToArray();
            return resultado;
        }

        public Usuario ObterPorId(int usuarioId)
        {

            return this.GetQuery().Where(x => x.UsuarioId == usuarioId).FirstOrDefault();
          
        }
        public Usuario[] ListarUsuarioAtivos()
        {
            var usuarioQuery = this.GetQuery().Where(x => x.Ativo);
            var resultado = usuarioQuery.ToArray();
            return resultado;
        }

        public int UsuariosDisponiveisRecrutamento()
        {
            return GetQuery().Where(x => x.Ativo)
                .Count(x => !x.RecrutamentoId.HasValue);
        }

        public int QuantidadeRecrutados()
        {
            return GetQuery().Where(x => x.Ativo)
                .Count(x => x.RecrutamentoId.HasValue);
        }
    }
}
