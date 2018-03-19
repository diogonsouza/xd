
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
    public class PontosBusiness : BusinessBase<RegrasPontuacao>, IPontosBusiness
    {
        private readonly SymmetricBase _symmetricBase;

        public PontosBusiness(SymmetricBase symmetricBase)
        {
            this._symmetricBase = symmetricBase;
        }

        public RegrasPontuacao ObterPorTipo(int tipo)
        {
            var pontosQuery = this.GetQuery().Where(x => x.Tipo == tipo).FirstOrDefault();
            var resultado = pontosQuery;
            return resultado; 
        }
    }
}
