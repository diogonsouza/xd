[assembly: System.Web.PreApplicationStartMethod(typeof(Admin.App_Start.ModulesInitializer), "Start")]
namespace Admin.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Common.Modules.Redirect;
    using System.Configuration;
    using Business;
    using Migration;
    public static class ModulesInitializer
    {
        public static void Start()
        {
            Common.Modules.DynamicModule.RegisterModules();
            DynamicModuleUtility.RegisterModule(typeof(Fbiz.Framework.Core.HttpModule));
        }
    }
}