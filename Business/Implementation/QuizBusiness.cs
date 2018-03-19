
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
    public class QuizBusiness : BusinessBase<GabaritoQuiz>, IQuizBusiness
    {
        private readonly SymmetricBase _symmetricBase;

        public QuizBusiness(SymmetricBase symmetricBase)
        {
            this._symmetricBase = symmetricBase;
        }

        public GabaritoQuiz ObterPorUsuario(int usuarioId)
        {
            return this.GetQuery().Where(x => x.UsuarioId == usuarioId).FirstOrDefault();
        }
    }
}
