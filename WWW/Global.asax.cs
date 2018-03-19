using System;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WWW.App_Start;
using WWW.WebCommon;

namespace WWW
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WebApiFactory());
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());


            MvcHandler.DisableMvcResponseHeader = true;
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var https = ConfigurationManager.AppSettings["https"];
            if (!string.IsNullOrEmpty(https)
                && https.ToLower().Equals(true.ToString().ToLower())
                && System.Web.HttpContext.Current != null
                && !System.Web.HttpContext.Current.Request.IsSecureConnection)
            {
                var path = string.Concat("https://", Request.Url.Host, Request.Url.PathAndQuery);
                Response.Status = "301 Moved Permanently";
                Response.AddHeader("Location", path);
                Response.Flush();
                Response.End();
            }
        }
    }
}
