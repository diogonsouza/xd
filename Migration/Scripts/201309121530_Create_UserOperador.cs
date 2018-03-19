using Fbiz.Framework.Core;
using Fbiz.Framework.Core.Cryptography;
using MigSharp;
using System.Data.SqlClient;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201309121530 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            var rijndael = IoCWrapper.Container.Resolve<Rijndael>();

            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.Parameters.Add(new SqlParameter("senha", rijndael.Encode("159753")));
                    command.CommandText = @"INSERT INTO Operador (Nome, Login, Senha, Ativo, DataCadastro) VALUES ('Admin', 'admin@fbiz.com.br', @senha, 1, getdate())";
                    command.ExecuteNonQuery();
                };
            });
        }

        public void Down(IDatabase db)
        {
            db.Execute("DELETE FROM Operador");
        }
    }
}
