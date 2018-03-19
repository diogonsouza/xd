using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class TokenMapper : BaseMapping<Token>
    {

        public TokenMapper()
        {
            this.ToTable("TB_SITE_TOKEN");
            this.HasKey(x => x.Tokenid);
            this.Property(x => x.Tokenid).HasColumnName("ID_TOKEN");
            this.Property(x => x.TipoToken).HasColumnName("CD_TOKEN");
            this.Property(x => x.CodigoToken).HasColumnName("DS_TOKEN");
            this.Property(x => x.Id_usuario).HasColumnName("ID_USUARIO");
            this.Property(x => x.DataCriacao).HasColumnName("TS_CRIACAO");

        }
    }
}
