using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Mapping
{
    class UsuarioMapper : BaseMapping<Usuario>
    {

        public UsuarioMapper()
        {
            this.ToTable("TB_SITE_USUARIO");
            this.HasKey(x => x.UsuarioId);
            this.Property(x => x.UsuarioId).HasColumnName("ID_USUARIO");
            this.Property(x => x.Email).HasColumnName("EN_EMAIL");
            this.Property(x => x.Nome).HasColumnName("NM_CLIENTE");
            this.Property(x => x.Cpf).HasColumnName("NR_CPF");
            this.Property(x => x.DataCriacao).HasColumnName("TS_CRIACAO");
            this.Property(x => x.Ativo).HasColumnName("IN_ATIVO");
            this.Property(x => x.RecrutamentoId).HasColumnName("ID_RECRUTAMENTO");
            this.Property(x => x.Profissao).HasColumnName("NM_PROFISSAO");
            this.Property(x => x.Estado).HasColumnName("NM_ESTADO");
            this.Property(x => x.Cidade).HasColumnName("NM_CIDADE");
            this.Property(x => x.DataNascimento).HasColumnName("TS_DATA_NASCIMENTO");
        }
    }
}
