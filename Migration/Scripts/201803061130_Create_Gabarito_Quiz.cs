using Fbiz.Framework.Core;
using Fbiz.Framework.Core.Cryptography;
using MigSharp;
using System.Data.SqlClient;

namespace Migration.Scripts
{
    [MigrationExport]
    public class Migration_201803061130  : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
            var rijndael = IoCWrapper.Container.Resolve<Rijndael>();

            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA,	CD_PERFIL) 
                                            VALUES (1, 1,'Sim',1)";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA,	CD_PERFIL) 
                                            VALUES (1, 2,'Não',2)";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (2, 1,'Sim')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (2, 2,'Não')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (3, 1,'etc')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (3, 2,'ltc')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (3, 3,'xrp')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (3, 4,'outra')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (4, 1,'quero testar ativo')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (4, 2,'quero juntar dinheiro rapidamente')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (4, 3,'quero ampliar leque de investimentos')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (4, 4,'sou entusiasta de novas tecnologias')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (5, 1,'ate atingir meu objetivo financeiro')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (5, 2,'curto prazo, menos que um ano')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (5, 3,'long prazo, mais que un ano')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (5, 4,'não sei')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (6, 1,'preço da criptomoeda')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (6, 2,'liquidez')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (6, 3,'segurança')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (6, 4,'facilidade')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (6, 5,'taxas de depósito/ corretagem/resgate')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (6, 6,'estabilidade da plataforma')";
                    command.ExecuteNonQuery();
                };
            });
            db.Execute(context =>
            {
                using (var command = context.Connection.CreateCommand())
                {
                    command.Transaction = context.Transaction;
                    command.CommandText = @"INSERT INTO TB_SITE_RESPOSTA_QUIZ (CD_PERGUNTA,	CD_RESPOSTA,	DS_RESPOSTA) 
                                            VALUES (6, 7,'solidez da plataforma')";
                    command.ExecuteNonQuery();
                };
            });

        }

        public void Down(IDatabase db)
        {
            db.Execute("DELETE FROM TB_SITE_RESPOSTA_QUIZ");
        }
    }
}
