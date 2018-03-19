using Fbiz.Framework.Core;
using Fbiz.Framework.Core.Cryptography;
using MigSharp;
using System.Data.SqlClient;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201802281450 : IReversibleMigration
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
                    command.CommandText = @"INSERT INTO tb_site_regras_pontuacao (cd_tipo, nr_valor, nr_recorrencia, cd_tipo_recorrencia, ts_data_inicio) 
                                            VALUES (1, 2.0, 0, 0, getdate())";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.Parameters.Add(new SqlParameter("senha", rijndael.Encode("159753")));
                    command.CommandText = @"INSERT INTO tb_site_regras_pontuacao (cd_tipo, nr_valor, nr_recorrencia, cd_tipo_recorrencia, ts_data_inicio) 
                                            VALUES (2, 8.0, 7, 1, getdate())";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.Parameters.Add(new SqlParameter("senha", rijndael.Encode("159753")));
                    command.CommandText = @"INSERT INTO tb_site_regras_pontuacao (cd_tipo, nr_valor, nr_recorrencia, cd_tipo_recorrencia, ts_data_inicio) 
                                            VALUES (3, 2.0, 0, 0, getdate())";
                    command.ExecuteNonQuery();
                };
            });
        }

        public void Down(IDatabase db)
        {
            db.Execute("DELETE FROM tb_site_regras_pontuacao");
        }
    }
}
