using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201802261201 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_PONTUACAO")

                .WithPrimaryKeyColumn("ID_PONTUACAO", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("ID_USUARIO", DbType.Int32)
                .WithNotNullableColumn("QT_PONTOS", DbType.Decimal).OfSize(10, 2);

            db.Tables["TB_SITE_PONTUACAO"].AddForeignKeyTo("TB_SITE_USUARIO", "FK_ID_USUARIO_PONTUACAO").Through("ID_USUARIO", "ID_USUARIO");
        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_PONTUACAO"].Drop();
        }
    }
}
