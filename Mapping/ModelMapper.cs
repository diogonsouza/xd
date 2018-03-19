using Fbiz.Framework.DataAccess;
using System.Data.Entity;

namespace Mapping
{
    public class ModelMapper : IModelMapper
    {
        public void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
        }
    }
}
