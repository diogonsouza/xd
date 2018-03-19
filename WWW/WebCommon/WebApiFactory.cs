using Fbiz.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;


namespace WWW.WebCommon
{
    public class WebApiFactory : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = IoCWrapper.Container.Resolve(controllerType);
            request.RegisterForDispose(new Release(controller));
            return (IHttpController)controller;
        }
        class Release : IDisposable
        {
            private readonly object _controller;
            public Release(object controller)
            {
                this._controller = controller;
            }

            public void Dispose()
            {
                IoCWrapper.Container.Release(this._controller);
            }
        }
    }
}