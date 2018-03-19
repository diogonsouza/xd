using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class CompartilhamentoMapper : BaseMapping<Compartilhamento>
    {

        public CompartilhamentoMapper()
        {
            this.ToTable("TB_SITE_COMPARTILHAMENTO");
            this.HasKey(x => x.CompartilhamentoId);
            this.Property(x => x.CompartilhamentoId).HasColumnName("ID_COMPARTILHAMENTO");
            this.Property(x => x.TokenId).HasColumnName("ID_TOKEN");
            this.Property(x => x.UsuarioId).HasColumnName("ID_USUARIO");
            this.Property(x => x.DataCriacao).HasColumnName("TS_CRIACAO");
            this.Property(x => x.Ativo).HasColumnName("CD_ATIVO");
        }
    }
}
