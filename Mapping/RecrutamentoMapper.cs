using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class RecrutamentoMapper : BaseMapping<Recrutamento>
    {

        public RecrutamentoMapper()
        {
            this.ToTable("TB_SITE_RECRUTAMENTO");
            this.HasKey(x => x.RecrutamentoId);
            this.Property(x => x.RecrutamentoId).HasColumnName("ID_RECRUTAMENTO");
            this.Property(x => x.DataCriacao).HasColumnName("TS_CRIACAO");
        }
    }
}
