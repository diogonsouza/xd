using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Admin.WebCommon
{
    public class RouteHttpHandler : IRouteHandler
    {
        private IHttpHandler _handler;

        public RouteHttpHandler(IHttpHandler handler)
        {
            this._handler = handler;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return _handler;
        }
    }
}