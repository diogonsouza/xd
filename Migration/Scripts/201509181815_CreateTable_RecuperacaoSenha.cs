using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201509181815 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("RecuperacaoSenha")
                .WithPrimaryKeyColumn("RecuperacaoSenhaId", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("Token", DbType.String).OfSize(32).Unique("IX_RecuperacaoSenha_Token")
                .WithNotNullableColumn("OperadorId", DbType.Int32)
                .WithNotNullableColumn("DataCadastro", DbType.DateTime)
                .WithNotNullableColumn("Valido", DbType.Boolean);

            db.Tables["RecuperacaoSenha"]
                .AddForeignKeyTo("Operador", "FK_RecuperacaoSenha_Operador")
                .Through("OperadorId", "OperadorId");
        }

        public void Down(IDatabase db)
        {
            db.Tables["RecuperacaoSenha"].Drop();
        }
    }
}
