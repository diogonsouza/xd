using System;
using System.Web;
using System.Web.Mvc;

namespace Admin.WebCommon
{
    public class JsonResult : System.Web.Mvc.JsonResult
	{
		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
				String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
				base.ExecuteResult(context);

			HttpResponseBase response = context.HttpContext.Response;

			if (!String.IsNullOrEmpty(ContentType))
				response.ContentType = ContentType;
			else
					response.ContentType = "application/json";
			if (ContentEncoding != null)
				response.ContentEncoding = ContentEncoding;
			if (Data != null)
			{
				string output = Newtonsoft.Json.JsonConvert.SerializeObject(this.Data, new Newtonsoft.Json.JsonSerializerSettings()
																					   {
																						   ContractResolver = new ContractResolver()
																					   });
				response.Write(output);
			}
		}
	}
}