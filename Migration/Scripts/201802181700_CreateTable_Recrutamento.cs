using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201802181700: IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_RECRUTAMENTO")
                .WithPrimaryKeyColumn("ID_RECRUTAMENTO", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("TS_CRIACAO", DbType.DateTime);

        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_RECRUTAMENTO"].Drop();
        }
    }
}
