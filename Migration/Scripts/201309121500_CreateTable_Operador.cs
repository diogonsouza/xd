using MigSharp;
using System.Data;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201309051450 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            db.CreateTable("Operador")
                .WithPrimaryKeyColumn("OperadorId", DbType.Int32).AsIdentity()
                .WithNotNullableColumn("Nome", DbType.String).OfSize(255)
                .WithNotNullableColumn("Login", DbType.String).OfSize(255).Unique("IX_Operador_Login")
                .WithNotNullableColumn("Senha", DbType.Binary)
                .Ativo()
                .DataCadastro();
        }

        public void Down(IDatabase db)
        {
            db.Tables["Operador"].Drop();
        }
    }
}
