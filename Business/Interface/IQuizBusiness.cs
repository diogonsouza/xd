﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fbiz.Framework.Business;
using Model;
using PagedList;

namespace Business.Interface
{
    public interface IQuizBusiness : IBusiness<GabaritoQuiz>
    {
        GabaritoQuiz ObterPorUsuario(int usuarioId);
    }
}