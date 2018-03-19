using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WWW.Helpers.Extensions
{
    public static class TextBoxesExtensions
    {
        public static MvcHtmlString TextBox(this BootstrapHelper helper, string name, object value = null, TextBoxType type = TextBoxType.Normal, string format = null, string placeholder = null, object htmlAttributes = null)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes ?? new object());
            if(!string.IsNullOrEmpty(placeholder))
                attributes.Add("placeholder", placeholder);
            return TextBox(helper, name, value, type, format, attributes);
        }
        //
        // Summary:
        //     Returns a text input element by using the specified HTML helper and the name
        //     of the form field.
        //
        // Parameters:
        //   helper:
        //     The HTML helper instance that this method extends.
        //
        //   name:
        //     The name of the form field and the System.Web.Mvc.ViewDataDictionary key
        //     that is used to look up the value.
        //
        // Returns:
        //     An input element whose type attribute is set to "text".
        public static MvcHtmlString TextBox(this BootstrapHelper helper, string name)
        {
            return TextBox(helper, name, null);
        }
        //
        // Summary:
        //     Returns a text input element by using the specified HTML helper, the name
        //     of the form field, and the value.
        //
        // Parameters:
        //   helper:
        //     The HTML helper instance that this method extends.
        //
        //   name:
        //     The name of the form field and the System.Web.Mvc.ViewDataDictionary key
        //     that is used to look up the value.
        //
        //   value:
        //     The value of the text input element. If this value is null, the value of
        //     the element is retrieved from the System.Web.Mvc.ViewDataDictionary object.
        //     If no value exists there, the value is retrieved from the System.Web.Mvc.ModelStateDictionary
        //     object.
        //
        // Returns:
        //     An input element whose type attribute is set to "text".

        //
        // Summary:
        //     Returns a text input element by using the specified HTML helper, the name
        //     of the form field, the value, and the HTML attributes.
        //
        // Parameters:
        //   helper:
        //     The HTML helper instance that this method extends.
        //
        //   name:
        //     The name of the form field and the System.Web.Mvc.ViewDataDictionary key
        //     that is used to look up the value.
        //
        //   value:
        //     The value of the text input element.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An input element whose type attribute is set to "text".
        //public static MvcHtmlString TextBox(this BootstrapHelper helper, string name, object value, IDictionary<string, object> htmlAttributes);
        //
        // Summary:
        //     Returns a text input element by using the specified HTML helper, the name
        //     of the form field, the value, and the HTML attributes.
        //
        // Parameters:
        //   helper:
        //     The HTML helper instance that this method extends.
        //
        //   name:
        //     The name of the form field
        //
        //   value:
        //     The value of the text input element. 
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An input element whose type attribute is set to "text".
        //public static MvcHtmlString TextBox(this BootstrapHelper helper, string name, object value, object htmlAttributes);
        //
        // Summary:
        //     Returns a text input element.
        //
        // Parameters:
        //   helper:
        //     The HTML helper instance that this method extends.
        //
        //   name:
        //     The name of the form field.
        //
        //   value:
        //     The value of the text input element.
        //
        //   format:
        //     A string that is used to format the input.
        //
        // Returns:
        //     An input element whose type attribute is set to "text".
        //public static MvcHtmlString TextBox(this BootstrapHelper helper, string name, object value, string format);
        //
        // Summary:
        //     Returns a text input element.
        //
        // Parameters:
        //   helper:
        //     The HTML helper instance that this method extends.
        //
        //   name:
        //     The name of the form field
        //
        //   value:
        //     The value of the text input element.
        //
        //   format:
        //     A string that is used to format the input.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An input element whose type attribute is set to "text".
        public static MvcHtmlString TextBox(this BootstrapHelper helper, string name, object value, TextBoxType type, string format, IDictionary<string, object> htmlAttributes)
        {
            object textValue = value == null ? string.Empty : value;
            var tagBuilder = new TagBuilder("input").SetAttribute("type", getTextBoxType(type))
                                                    .WithName(name)
                                                    .SetAttribute("value", string.IsNullOrEmpty(format) ? textValue.ToString() : string.Format(format, textValue))
                                                    .SetAttributes(htmlAttributes);
            return tagBuilder.ToHtmlString();
        }

        private static string getTextBoxType(TextBoxType type)
        {
            switch (type)
            {
                case TextBoxType.Normal:
                    return "text";
                case TextBoxType.Password:
                    return "password";
                default:
                    throw new NotSupportedException(string.Concat("TextBoxType not supported: ", type));
            }
        }
        //
        // Summary:
        //     Returns a text input element.
        //
        // Parameters:
        //   helper:
        //     The HTML helper instance that this method extends.
        //
        //   name:
        //     The name of the form field
        //
        //   value:
        //     The value of the text input element. 
        //
        //   format:
        //     A string that is used to format the input.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An input element whose type attribute is set to "text".
        public static MvcHtmlString TextBox(this BootstrapHelper helper, string name, object value, TextBoxType type, string format, object htmlAttributes)
        {
            return TextBox(helper, name, value, type, format, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
    }
}