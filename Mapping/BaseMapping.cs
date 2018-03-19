using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Mapping
{
    internal class BaseMapping<T> : EntityTypeConfiguration<T> where T : class
    {
        public BaseMapping()
        {
            this.ToTable(typeof(T).Name);
        }
    }
}
