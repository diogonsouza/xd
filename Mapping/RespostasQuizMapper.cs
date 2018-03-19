using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class RespostasQuizMapper : BaseMapping<RespostasQuiz>
    {

        public RespostasQuizMapper()
        {
            this.ToTable("TB_SITE_RESPOSTA_QUIZ");
            this.HasKey(x => x.RespostasQuizId);
            this.Property(x => x.RespostasQuizId).HasColumnName("ID_RESPOSTA_QUIZ");
            this.Property(x => x.CodigoPergunta).HasColumnName("CD_PERGUNTA");
            this.Property(x => x.CodigoResposta).HasColumnName("CD_RESPOSTA");
            this.Property(x => x.DescricaoResposta).HasColumnName("DS_RESPOSTA");
            this.Property(x => x.PerfilId).HasColumnName("CD_PERFIL");
        }
    }
}
