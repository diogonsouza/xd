using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigSharp;

namespace Migration
{
    public static class Extensions
    {
        public static ICreatedTableWithAddedColumn Ativo(this ICreatedTableWithAddedColumn db)
        {
            return db.WithNotNullableColumn("Ativo", System.Data.DbType.Boolean);
        }

        public static ICreatedTableWithAddedColumn DataCadastro(this ICreatedTableWithAddedColumn db)
        {
            return db.WithNotNullableColumn("DataCadastro", System.Data.DbType.DateTime);
        }
    }
}
