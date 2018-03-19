using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201802261202 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_COMPARTILHAMENTO")

                .WithPrimaryKeyColumn("ID_COMPARTILHAMENTO", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("ID_USUARIO", DbType.Int32)
                .WithNotNullableColumn("ID_TOKEN", DbType.Int32)
                .WithNotNullableColumn("TS_CRIACAO", DbType.DateTime)
                .WithNotNullableColumn("CD_ATIVO", DbType.Int32).HavingDefault(0);

            db.Tables["TB_SITE_COMPARTILHAMENTO"].AddForeignKeyTo("TB_SITE_USUARIO", "FK_ID_USUARIO_COMPARTILHAMENTO").Through("ID_USUARIO", "ID_USUARIO");
            db.Tables["TB_SITE_COMPARTILHAMENTO"].AddForeignKeyTo("TB_SITE_TOKEN", "FK_ID_TOKEN_COMPARTILHAMENTO").Through("ID_TOKEN", "ID_TOKEN");
        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_COMPARTILHAMENTO"].Drop();
        }
    }
}
