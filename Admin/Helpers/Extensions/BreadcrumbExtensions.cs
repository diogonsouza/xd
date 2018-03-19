using System.Web.Mvc;

namespace Admin.Helpers.Extensions
{
    public static class BreadcrumbExtensions
    {
        public static MvcHtmlString Breadcrumb(this BootstrapHelper helper, params BreadcrumbItem[] itens)
        {
            TagBuilder builder = new TagBuilder("div").WithId("breadcrumb");
            for (int i = 0; i < itens.Length; i++)
            {
                var item = itens[i];
                var innerElement = new TagBuilder("a").SetAttribute("href", item.Url)
                                                      .SetAttribute("title", item.Tooltip)
                                                      .SetCssClass("tip-botton");
                if(item.Icon != Icon.None)
                    innerElement.WithInnerElement(helper.Icon(item.Icon));
                innerElement.WithInnerElement(new MvcHtmlString(item.Title));
                if((i + 1) == itens.Length)
                {
                    innerElement.SetCssClass("current");
                }
                builder.WithInnerElement(innerElement);
            }
            return builder.ToHtmlString();
        }
    }
}