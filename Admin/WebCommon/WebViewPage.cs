using Admin.Helpers;
using Business.Interface;
using Common.Configuration;
using Common.Minify.Mvc;
using Fbiz.Framework.Core;
using System;
using System.Web;
using System.Web.Mvc;

namespace Admin.WebCommon
{
    public abstract class WebViewPage : global::System.Web.Mvc.WebViewPage
	{
		
		public Section Config { get; private set; }
		public new global::Common.UrlHelper Url { get; set; }
		public global::Common.Seo.Page Seo { get; private set; }
		public dynamic Settings { get; private set; }
        public BootstrapHelper Bootstrap { get; set; }
        private Model.Operador _operador;

        public Model.Operador Operador
        {
            get
            {
                if (this._operador == null && this.User.Identity.IsAuthenticated)
                    this._operador = IoCWrapper.Container.Resolve<IOperadorBusiness>().Obter(Int32.Parse(this.User.Identity.Name));
                return this._operador;
            }
        }

        public string CurrentAction
		{
			get
			{
				return this.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
			}
		}
		public string CurrentController
		{
			get
			{
				return this.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
			}
		}
	
		public global::Common.Minify.Mvc.MinifyHelper Minify { get; private set;}

		public override void InitHelpers()
		{
			//Default helpers
			this.Ajax = new AjaxHelper<object>(this.ViewContext, (IViewDataContainer)this);
			this.Html = new HtmlHelper<object>(this.ViewContext, (IViewDataContainer)this);

			//Modified helper
			this.Url = new global::Common.UrlHelper(this.ViewContext.RequestContext);
			
			//Config
			this.Config = global::Common.Config.GetConfiguration();

			//SEO
			this.Seo = new global::Common.Seo.SeoReader().CurrentPage();

			//Settings Proxy
			this.Settings = new global::Common.DynamicSettings();

			//Minify helper
			HttpContext.Current.Items["Minify"] = this.Minify = (HttpContext.Current.Items["Minify"] as MinifyHelper) == null ?
				                                                              new MinifyHelper(Common.Minify.Minify.Initialize())
																			  : (HttpContext.Current.Items["Minify"] as Common.Minify.Mvc.MinifyHelper);

            
            this.Bootstrap = new BootstrapHelper();

		}

		public bool IsAction(string action)
		{
			return this.CurrentAction.ToLower().Equals((action ?? string.Empty).ToLower());
		}
		public bool IsController(string controller)
		{
			return this.CurrentController.ToLower().Equals((controller ?? string.Empty).ToLower());
		}
	}
	public abstract class WebViewPage<TModel> : WebViewPage
	{
		private ViewDataDictionary<TModel> _viewData;

		public new AjaxHelper<TModel> Ajax { get; set; }
        public new HtmlHelper<TModel> Html { get; set; }
        public new TModel Model
		{
			get
			{
				return this.ViewData.Model;
			}
		}
        public new ViewDataDictionary<TModel> ViewData
		{
			get
			{
				if (this._viewData == null)
					this.SetViewData((ViewDataDictionary)new ViewDataDictionary<TModel>());
				return this._viewData;
			}
			set
			{
				this.SetViewData((ViewDataDictionary)value);
			}
		}
		

		public override void InitHelpers()
		{
			base.InitHelpers();
			//Default helpers
			this.Ajax = new AjaxHelper<TModel>(this.ViewContext, (IViewDataContainer)this);
			this.Html = new HtmlHelper<TModel>(this.ViewContext, (IViewDataContainer)this);
		}

		protected override void SetViewData(ViewDataDictionary viewData)
		{
			this._viewData = new ViewDataDictionary<TModel>(viewData);
			base.SetViewData((ViewDataDictionary)this._viewData);
		}
	}

}