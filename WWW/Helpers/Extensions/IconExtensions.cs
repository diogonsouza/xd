using System.Web.Mvc;

namespace WWW.Helpers.Extensions
{
    public static class IconExtensions
    {
        public static MvcHtmlString Icon(this BootstrapHelper helper, Icon icon)
        {
            string cssClassName = string.Concat("icon-", icon.ToString().ToLower().Replace('_', '-'));

            return new TagBuilder("i").SetCssClass(cssClassName).ToHtmlString(TagRenderMode.Normal);
        }
    }
}