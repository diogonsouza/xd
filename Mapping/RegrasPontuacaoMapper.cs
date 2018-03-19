using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class RegrasPontuacaoMapper : BaseMapping<RegrasPontuacao>
    {

        public RegrasPontuacaoMapper()
        {
            this.ToTable("TB_SITE_REGRAS_PONTUACAO");
            this.HasKey(x => x.RegrasPontuacaoId);
            this.Property(x => x.RegrasPontuacaoId).HasColumnName("ID_REGRAS_PONTUACAO");
            this.Property(x => x.Tipo).HasColumnName("CD_TIPO");
            this.Property(x => x.Valor).HasColumnName("NR_VALOR");
            this.Property(x => x.Recorrencia).HasColumnName("NR_RECORRENCIA");
            this.Property(x => x.TipoRecorrencia).HasColumnName("CD_TIPO_RECORRENCIA");
            this.Property(x => x.DataInicio).HasColumnName("TS_DATA_INICIO");
        }
    }
}
