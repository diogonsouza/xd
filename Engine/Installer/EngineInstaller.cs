using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Engine.Implementation;
using Engine.Interface;

namespace Engine.Installer
{
    public class EngineInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Types.FromAssembly(typeof(IUsuarioEngine).Assembly)
                                    .InSameNamespaceAs<UsuarioEngine>()

                                    .WithService.DefaultInterfaces()
                                    .LifestyleTransient()
                                    );
            container.Register(Types.FromAssembly(typeof(ITokenEngine).Assembly)
                                   .InSameNamespaceAs<ITokenEngine>()

                                   .WithService.DefaultInterfaces()
                                   .LifestyleTransient()
                                   );
        }
    }
}