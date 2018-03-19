using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;
using System.Web.Mvc;

namespace Admin.WebCommon
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMailSender>()
                                        .ImplementedBy<Controllers.MailController>()
                                        .LifestyleTransient()
                                        .IsFallback());

            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());

            container.Register(Classes.FromThisAssembly()
                                      .BasedOn(typeof(IValidator<>))
                                      .WithService.Base()
                                      .LifestyleTransient());
        }
    }
}