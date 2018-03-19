using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Fbiz.Framework.DataAccess;
using Mapping;

namespace IoC
{
    public class ModelMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IModelMapper>()
                                        .ImplementedBy<ModelMapper>());
        }
    }
}
