using System.Web.Mvc;

namespace WWW.Helpers.Extensions
{
    public static class ButtonsExtensions
    {
        public static MvcHtmlString LinkButton(this BootstrapHelper helper, string url, string text, ButtonType type = ButtonType.Normal, ButtonSize size = ButtonSize.Normal)
        {
            TagBuilder builder = new TagBuilder("a").SetAttribute("href", url)
                                                    .SetCssClass("btn")
                                                    .SetCssClass(getCssType(type))
                                                    .SetCssClass(getCssSize(size))
                                                    .WithInnerText(text);
            return builder.ToHtmlString();
            
        }
        public static MvcHtmlString Submit(this BootstrapHelper helper, string text, ButtonType type = ButtonType.Normal, ButtonSize size = ButtonSize.Normal)
        {
            TagBuilder builder = new TagBuilder("input").SetAttribute("type", "submit")
                                                        .SetCssClass("btn")
                                                        .SetCssClass(getCssType(type))
                                                        .SetCssClass(getCssSize(size))
                                                        .SetAttribute("value", text);
            return builder.ToHtmlString();
        }
        public static MvcHtmlString Button(this BootstrapHelper helper, string text, ButtonType type = ButtonType.Normal, ButtonSize size = ButtonSize.Normal)
        {
            TagBuilder builder = new TagBuilder("button").SetCssClass("btn")
                                                         .SetCssClass(getCssType(type))
                                                         .SetCssClass(getCssSize(size))
                                                         .SetAttribute("value", text);
            return builder.ToHtmlString();
        }

        private static string getCssType(ButtonType type)
        {
            switch (type)
            {
                case ButtonType.Primary:
                    return "btn-primary";
                case ButtonType.Info:
                    return "btn-info";
                case ButtonType.Success:
                    return "btn-success";
                case ButtonType.Warning:
                    return "btn-warning";
                case ButtonType.Danger:
                    return "btn-danger";
                case ButtonType.Inverse:
                    return "btn-inverse";
                default:
                    return string.Empty;
            }
            
        }
        private static string getCssSize(ButtonSize size)
        {
            switch (size)
            {
                case ButtonSize.Large:
                    return "btn-large";
                case ButtonSize.Mini:
                    return "btn-mini";
                default:
                    return string.Empty;
            }

        }
    }
}