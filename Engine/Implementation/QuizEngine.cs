using System;
using Business.Interface;
using Engine.Interface;
using Fbiz.Framework.Core.Cryptography;
using Model;

namespace Engine.Implementation
{
    public class QuizEngine : IQuizEngine
    {
        private readonly IQuizBusiness _quizBusiness;

        public QuizEngine(IQuizBusiness quizBusiness)
        {
            this._quizBusiness = quizBusiness;
        }

        public GabaritoQuiz Cadastrar(GabaritoQuiz quiz)
        {
            quiz = atualizarBase(quiz);
            return quiz;
        }

        private GabaritoQuiz atualizarBase(GabaritoQuiz quiz)
        {
            GabaritoQuiz quizResult = cadastrarQuiz(quiz);
            return quizResult;
        }

        private GabaritoQuiz cadastrarQuiz(GabaritoQuiz quiz)
        {

            this._quizBusiness.Add(quiz);
            try
            {
                this._quizBusiness.Save();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string message = (ex.InnerException?.InnerException?.Message) ?? string.Empty;
                if (message.ToLower().Contains("IX_TB_SITE_USUARIO_NR_CPF".ToLower()))
                    throw new CPFJaCadastradoException();
                else if (message.ToLower().Contains("IX_TB_SITE_USUARIO_EN_EMAI".ToLower()))
                    throw new EmailJaCadastradoException();
                else throw;
            }

            return quiz;
        }

        public GabaritoQuiz ObterPorUsuario(int usuarioId) {

            GabaritoQuiz respostas = this._quizBusiness.ObterPorUsuario(usuarioId);

            return respostas;
        }
    }
}
