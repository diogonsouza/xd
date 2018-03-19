using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201802241601 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_TOKEN")

                .WithPrimaryKeyColumn("ID_TOKEN", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("CD_TOKEN", DbType.Int32)
                .WithNotNullableColumn("DS_TOKEN", DbType.String).OfSize(50).Unique()
                .WithNotNullableColumn("TS_CRIACAO", DbType.DateTime)
                .WithNotNullableColumn("ID_USUARIO", DbType.Int32);

            db.Tables["TB_SITE_TOKEN"].AddForeignKeyTo("TB_SITE_USUARIO", "FK_ID_USUARIO_TOKEN").Through("ID_USUARIO", "ID_USUARIO");
        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_USUARIO"].Drop();
        }
    }
}
