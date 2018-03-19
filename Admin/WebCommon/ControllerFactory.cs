using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text.RegularExpressions;
using Fbiz.Framework.Core;
using System.Web.Routing;

namespace Admin.WebCommon
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var type = base.GetControllerType(requestContext, controllerName);
            if (type == null)
            {
                if (!Regex.IsMatch(controllerName.ToLower(), @".*?\.[a-z0-9]{2,3}") && Directory.Exists(requestContext.HttpContext.Server.MapPath(string.Concat("~/Views/", controllerName))))
                    return typeof(ControllerFactory.DefaultController);
                else
                    return null;
            }
            return type;
        }
        public override void ReleaseController(IController controller)
        {
            if (controller.GetType() != typeof(DefaultController))
                IoCWrapper.Container.Release(controller);
            else
                base.ReleaseController(controller);
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null || controllerType.Equals(typeof(DefaultController)))
                return base.GetControllerInstance(requestContext, controllerType);
            else
                return (IController)IoCWrapper.Container.Resolve(controllerType);
        }

        public class DefaultController : Controllers.Controller
        {
            public ActionResult Index()
            {
                return View();
            }

            protected override IActionInvoker CreateActionInvoker()
            {
                return new CustomActionInvoker();
            }
            private class CustomActionInvoker : ControllerActionInvoker
            {
                public override bool InvokeAction(ControllerContext controllerContext, string actionName)
                {
                    string controllerName = controllerContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
                    string fileName = string.Concat(actionName, ".cshtml");
                    if (System.IO.File.Exists(controllerContext.HttpContext.Server.MapPath(string.Format("~/Views/{0}/{1}", controllerName, fileName)))
                        || System.IO.File.Exists(controllerContext.HttpContext.Server.MapPath(string.Format("~/Views/Shared/{0}", fileName))))
                        return base.InvokeAction(controllerContext, "Index");
                    else
                        return base.InvokeAction(controllerContext, actionName);
                }
            }


        }

    }
}