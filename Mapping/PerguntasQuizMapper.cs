using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class PerguntasQuizMapper : BaseMapping<PerguntasQuiz>
    {

        public PerguntasQuizMapper()
        {
            this.ToTable("TB_SITE_PERGUNTAS_QUIZ");
            this.HasKey(x => x.PerguntasQuizId);
            this.Property(x => x.PerguntasQuizId).HasColumnName("ID_PERGUNTAS_QUIZ");
            this.Property(x => x.CodigoPergunta).HasColumnName("CD_PERGUNTA");
            this.Property(x => x.DescricaoPergunta).HasColumnName("DS_PERGUNTA");
            this.Property(x => x.PerguntaPerfil).HasColumnName("IN_PERGUNTA_PERFIL");

        }
    }
}
