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
    public class CompartilhamentoBusiness : BusinessBase<Compartilhamento>, ICompartilhamentoBusiness
    {
        private readonly SymmetricBase _symmetricBase;

        public CompartilhamentoBusiness(SymmetricBase symmetricBase)
        {
            this._symmetricBase = symmetricBase;
        }

        public Compartilhamento ObterPorUsuario(int usuarioId)
        {
            return this.GetQuery().Where(x => x.UsuarioId == usuarioId).FirstOrDefault();
        }

        public Compartilhamento[] ListarCompartilhamento()
        {
            var pontuacaoQuery = this.GetQuery();
            var resultado = pontuacaoQuery.ToArray();
            return resultado;
        }
    }
}
