using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201802261302 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("TB_SITE_REGRAS_PONTUACAO")

                .WithPrimaryKeyColumn("ID_REGRAS_PONTUACAO", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("CD_TIPO", DbType.Int32)
                .WithNotNullableColumn("NR_VALOR", DbType.Decimal).OfSize(10, 2)
                .WithNotNullableColumn("NR_RECORRENCIA", DbType.Int32)
                .WithNotNullableColumn("CD_TIPO_RECORRENCIA", DbType.Int32)
                .WithNotNullableColumn("TS_DATA_INICIO", DbType.DateTime);
        }

        public void Down(IDatabase db)
        {
            db.Tables["TB_SITE_PONTO"].Drop();
        }
    }
}
