
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
    public class PerguntaBusiness : BusinessBase<PerguntasQuiz>, IPerguntaBusiness
    {
        private readonly SymmetricBase _symmetricBase;

        public PerguntaBusiness(SymmetricBase symmetricBase)
        {
            this._symmetricBase = symmetricBase;
        }

        public PerguntasQuiz[] ObterPerguntas()
        {
            return this.GetQuery().OrderBy(x => x.CodigoPergunta).ToArray();
        }
    }
}
