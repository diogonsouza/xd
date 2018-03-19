using System;
using Business.Interface;
using Engine.Interface;
using Fbiz.Framework.Core.Cryptography;
using Model;

namespace Engine.Implementation
{
    public class PerguntaEngine : IPerguntaEngine
    {
        private readonly IPerguntaBusiness _perguntaBusiness;

        public PerguntaEngine(IPerguntaBusiness perguntaBusiness)
        {
            this._perguntaBusiness = perguntaBusiness;
        }

       
        public PerguntasQuiz[] ObterPerguntas() {

            PerguntasQuiz[] respostas = this._perguntaBusiness.ObterPerguntas();

            return respostas;
        }
    }
}
