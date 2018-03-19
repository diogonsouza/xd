using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201802181701 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_USUARIO")
                .WithPrimaryKeyColumn("ID_USUARIO", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("NM_CLIENTE", DbType.String).OfSize(255)
                .WithNotNullableColumn("NR_CPF", DbType.String).OfSize(15).Unique()
                .WithNotNullableColumn("EN_EMAIL", DbType.String).OfSize(100).Unique()
                .WithNullableColumn("NM_PROFISSAO", DbType.String).OfSize(255)
                .WithNullableColumn("NM_ESTADO", DbType.String).OfSize(255)
                .WithNullableColumn("NM_CIDADE", DbType.String).OfSize(255)
                .WithNullableColumn("TS_DATA_NASCIMENTO", DbType.DateTime)
                .WithNotNullableColumn("TS_CRIACAO", DbType.DateTime)
                .WithNotNullableColumn("IN_ATIVO",DbType.Boolean)
                .WithNullableColumn("ID_RECRUTAMENTO",DbType.Int32);

            db.Tables["TB_SITE_USUARIO"].AddForeignKeyTo("TB_SITE_RECRUTAMENTO", "FK_ID_USUARIO_RECRUTAMENTO").Through("ID_RECRUTAMENTO", "ID_RECRUTAMENTO");
        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_USUARIO"].Drop();
        }
    }
}
