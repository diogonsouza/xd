[assembly: System.Web.PreApplicationStartMethod(typeof(WWW.App_Start.ModulesInitializer), "Start")]
namespace WWW.App_Start
{
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Common.Modules.Redirect;
	public static class ModulesInitializer
	{
		public static void Start()
		{
			Common.Modules.DynamicModule.RegisterModules();
			DynamicModuleUtility.RegisterModule(typeof(Fbiz.Framework.Core.HttpModule));
		}
	}
}
