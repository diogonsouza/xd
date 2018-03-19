using Fbiz.Framework.Core;
using Fbiz.Framework.Core.Cryptography;
using MigSharp;
using System.Data.SqlClient;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201803051802 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            var rijndael = IoCWrapper.Container.Resolve<Rijndael>();

            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_PERFIL (CD_PERFIL,	NM_PERFIL) 
                                            VALUES (1,'Avançado')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_PERFIL (CD_PERFIL,	NM_PERFIL) 
                                            VALUES (2,'Novato')";
                    command.ExecuteNonQuery();
                };
            });
           
        }

        public void Down(IDatabase db)
        {
            db.Execute("DELETE FROM TB_SITE_PERGUNTAS_QUIZ");
        }
    }
}
