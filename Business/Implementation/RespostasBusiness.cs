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
    public class RespostasBusiness : BusinessBase<RespostasQuiz>, IRespostasBusiness
    {
        private readonly SymmetricBase _symmetricBase;

        public RespostasBusiness(SymmetricBase symmetricBase)
        {
            this._symmetricBase = symmetricBase;
        }

        public List<RespostasQuiz> ObterRespostas(int codigoPergunta)
        {
            List<RespostasQuiz> resposta = this.GetQuery().Where(x => x.CodigoPergunta == codigoPergunta).OrderByDescending(x => x.CodigoResposta).ToList();

            return resposta;
        }
    }
}