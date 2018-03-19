using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class PontuacaoMapper : BaseMapping<Pontuacao>
    {

        public PontuacaoMapper()
        {
            this.ToTable("TB_SITE_PONTUACAO");
            this.HasKey(x => x.PontuacaoId);
            this.Property(x => x.PontuacaoId).HasColumnName("ID_PONTUACAO");
            this.Property(x => x.UsuarioId).HasColumnName("ID_USUARIO");
            this.Property(x => x.TotalPontos).HasColumnName("QT_PONTOS");
        }
    }
}
