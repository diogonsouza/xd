using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201803051830: IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_RESPOSTA_QUIZ")
                .WithPrimaryKeyColumn("ID_RESPOSTA_QUIZ", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("CD_PERGUNTA", DbType.Int32)
                .WithNotNullableColumn("CD_RESPOSTA", DbType.Int32)
                .WithNotNullableColumn("DS_RESPOSTA", DbType.String).OfSize(255)
                .WithNullableColumn("CD_PERFIL", DbType.Int32);

            db.Tables["TB_SITE_RESPOSTA_QUIZ"].AddForeignKeyTo("TB_SITE_PERGUNTAS_QUIZ", "FK_GABARITO_PERGUNTAS").Through("CD_PERGUNTA", "CD_PERGUNTA");
            db.Tables["TB_SITE_RESPOSTA_QUIZ"].AddForeignKeyTo("TB_SITE_PERFIL", "FK_GABARITO_PERFIL").Through("CD_PERFIL", "CD_PERFIL");

        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_GABARITO_QUIZ"].Drop();
        }
    }
}
