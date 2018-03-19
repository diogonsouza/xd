using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Fbiz.Framework.DataAccess;
using Mapping;
using Castle.MicroKernel.SubSystems.Configuration;
using Migration;

namespace IoC
{
    public class MigratorDatabaseInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDatabaseInitializer>()
                                                  .ImplementedBy<MigrationDatabaseInitializer>()
                                                  .LifestyleTransient());
        }
    }
}
