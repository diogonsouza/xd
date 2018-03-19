using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW.Filters
{
    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        private const string authToken = "YWRtaW5AZmJpei5jb20uYnI6MTU5NzUzMzU3OTUx";

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                if (actionContext.Request.Headers.Authorization.Scheme == null)
                {

                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
                else
                {
                    if (!actionContext.Request.Headers.Authorization.Scheme.Equals(authToken))
                        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }



            }
        }
    }
}