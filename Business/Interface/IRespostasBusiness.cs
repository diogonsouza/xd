using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fbiz.Framework.Business;
using Model;
using PagedList;

namespace Business.Interface
{
    public interface IRespostasBusiness : IBusiness<RespostasQuiz>
    {
        List<RespostasQuiz> ObterRespostas(int codigoPergunta);
    }
}
