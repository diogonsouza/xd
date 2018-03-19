using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201803051800: IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_PERFIL")
                .WithPrimaryKeyColumn("ID_PERFIL", DbType.Int32).AsIdentity()
                .WithPrimaryKeyColumn("CD_PERFIL", DbType.Int32).Unique()
                .WithNotNullableColumn("NM_PERFIL", DbType.String).OfSize(255);
        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_PERFIL"].Drop();
        }
    }
}
