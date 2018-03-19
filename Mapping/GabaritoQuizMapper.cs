using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class GabaritoQuizMapper : BaseMapping<GabaritoQuiz>
    {

        public GabaritoQuizMapper()
        {
            this.ToTable("TB_SITE_GABARITO_QUIZ");
            this.HasKey(x => x.GabaritoId);
            this.Property(x => x.GabaritoId).HasColumnName("ID_GABARITO_QUIZ");
            this.Property(x => x.CodigoPergunta).HasColumnName("CD_PERGUNTA");
            this.Property(x => x.UsuarioId).HasColumnName("ID_USUARIO");
            this.Property(x => x.RespostaId).HasColumnName("CD_RESPOSTA");
            this.Property(x => x.Resposta).HasColumnName("DS_RESPOSTA");
        }
    }
}
