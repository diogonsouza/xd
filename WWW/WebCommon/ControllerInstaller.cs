using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Castle.MicroKernel.SubSystems.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Web.Mvc;
using FluentValidation;
using System.Web.Http.Controllers;
using WWW.ViewModels.Validation;

namespace WWW.WebCommon
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
                    .BasedOn<IHttpController>()
                    .LifestyleTransient());


            container.Register(Classes.FromThisAssembly()
                                      .BasedOn(typeof(IValidator<>))
                                      .WithService.Base()
                                      .LifestyleTransient());


        }
    }
}