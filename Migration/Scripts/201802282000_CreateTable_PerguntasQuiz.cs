using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201802282000: IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_PERGUNTAS_QUIZ")
                .WithPrimaryKeyColumn("ID_PERGUNTAS_QUIZ", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("CD_PERGUNTA", DbType.Int32).Unique()
                .WithNotNullableColumn("DS_PERGUNTA", DbType.String).OfSize(255)
                .WithNotNullableColumn("IN_PERGUNTA_PERFIL", DbType.Boolean);
        } 

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_PERGUNTAS_QUIZ"].Drop();
        }
    }
}
