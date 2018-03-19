using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201803061000: IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_GABARITO_QUIZ")
                .WithPrimaryKeyColumn("ID_GABARITO_QUIZ", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("CD_PERGUNTA", DbType.Int32)
                .WithNotNullableColumn("ID_USUARIO", DbType.Int32)
                .WithNullableColumn("CD_RESPOSTA", DbType.Int32)
                .WithNullableColumn("DS_RESPOSTA", DbType.String).OfSize(255);

                 db.Tables["TB_SITE_GABARITO_QUIZ"].AddForeignKeyTo("TB_SITE_USUARIO", "FK_ID_USUARIO_RESPOSTAS").Through("ID_USUARIO", "ID_USUARIO");
                 db.Tables["TB_SITE_GABARITO_QUIZ"].AddForeignKeyTo("TB_SITE_PERGUNTAS_QUIZ", "FK_ID_PERGUNTAS_RESPOSTAS").Through("CD_PERGUNTA", "CD_PERGUNTA");
                

        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_RESPOSTAS_QUIZ"].Drop();
        }
    }
}
