using Common.Configuration;
using Fbiz.Framework.Core;
using FluentValidation;
using FluentValidation.Results;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public abstract class Controller : global::System.Web.Mvc.Controller
    {
        public dynamic Settings { get; private set; }
        public Section Config { get; private set; }
        private System.Web.Routing.RequestContext requestContext;

        public Controller() : base()
        {
            //Config
            this.Config = global::Common.Config.GetConfiguration();

            //Settings Proxy
            this.Settings = new global::Common.DynamicSettings();
        }

        protected ValidationResult Validate<T>(T model)
        {
            var validator = IoCWrapper.Container.Resolve<IValidator<T>>();
            var result = validator.Validate(model);
            return result;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

        }
        protected override System.Web.Mvc.JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new WebCommon.JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result != null && filterContext.Result is ViewResult)
                filterContext.RequestContext.HttpContext.Response.AddHeader("X-UA-Compatible", "IE=edge,chrome=1");
        }

        public void FeedbackSuccess(string message)
        {
            appendFeedback("success", message);
        }

        private void appendFeedback(string kind, string message)
        {
            HttpCookie cookie = new HttpCookie("feedback");
            cookie.HttpOnly = true;
            cookie.Values.Add("kind", kind);
            cookie.Values.Add("message", message);
            Response.SetCookie(cookie);
        }

    }
}
