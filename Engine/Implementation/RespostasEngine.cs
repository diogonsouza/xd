using System;
using System.Collections.Generic;
using Business.Interface;
using Engine.Interface;
using Fbiz.Framework.Core.Cryptography;
using Model;

namespace Engine.Implementation
{
    public class RespostasEngine : IRespostasEngine
    {
        private readonly IRespostasBusiness _respostasBusiness;

        public RespostasEngine(IRespostasBusiness respostasBusiness)
        {
            this._respostasBusiness = respostasBusiness;
        }

       
        public List<RespostasQuiz> ObterRespostas(int codigoPergunta) {

            List<RespostasQuiz> respostas = this._respostasBusiness.ObterRespostas(codigoPergunta);

            return respostas;
        }
    }
}
