using Model;
using Business.Interface;
using System.Collections.Generic;

namespace Engine.Interface
{
    public interface IRespostasEngine
    {

       List<RespostasQuiz> ObterRespostas(int codigoPergunta);
    }
}
