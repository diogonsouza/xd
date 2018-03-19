using Business.Implementation;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace IoC
{
    public class BusinessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Types.FromAssembly(typeof(OperadorBusiness).Assembly)
                                    .InSameNamespaceAs<OperadorBusiness>()
                                    .WithService.DefaultInterfaces()
                                    .LifestyleTransient());
        }
    }
}
