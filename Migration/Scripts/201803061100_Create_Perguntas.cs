using Fbiz.Framework.Core;
using Fbiz.Framework.Core.Cryptography;
using MigSharp;
using System.Data.SqlClient;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201803061100 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            var rijndael = IoCWrapper.Container.Resolve<Rijndael>();

            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_PERGUNTAS_QUIZ (CD_PERGUNTA,	DS_PERGUNTA, IN_PERGUNTA_PERFIL) 
                                            VALUES (1,'Já comprou bitcoin ?',1)";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_PERGUNTAS_QUIZ (CD_PERGUNTA,	DS_PERGUNTA, IN_PERGUNTA_PERFIL) 
                                            VALUES (2,'Já comprou outra criptomoeda ?',0)";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_PERGUNTAS_QUIZ (CD_PERGUNTA,	DS_PERGUNTA, IN_PERGUNTA_PERFIL) 
                                            VALUES (3,'Legal, qual delas ja comprou ?',0)";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_PERGUNTAS_QUIZ (CD_PERGUNTA,	DS_PERGUNTA, IN_PERGUNTA_PERFIL) 
                                            VALUES (4,'Por que investe quer investir em criptomoedas',0)";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_PERGUNTAS_QUIZ (CD_PERGUNTA,	DS_PERGUNTA, IN_PERGUNTA_PERFIL) 
                                            VALUES (5,'Por quanto tempo quer investir em criptomoedas ?',0)";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_PERGUNTAS_QUIZ (CD_PERGUNTA,	DS_PERGUNTA, IN_PERGUNTA_PERFIL) 
                                            VALUES (6,'Na sua opniao qual o ponto mais importante na escolha de uma corretora de criptomoedas ? ',0)";
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
