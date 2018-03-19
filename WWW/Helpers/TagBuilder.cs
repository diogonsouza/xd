using System.Collections.Generic;
using System.Web.Mvc;

namespace WWW.Helpers
{
    public class TagBuilder
    {
        private System.Web.Mvc.TagBuilder _tagBuilder;

        // Summary:
        //     Gets the collection of attributes.
        //
        // Returns:
        //     The collection of attributes.
        public IDictionary<string, string> Attributes { get { return this._tagBuilder.Attributes; } }

        //
        // Summary:
        //     Gets or sets the inner HTML value for the element.
        //
        // Returns:
        //     The inner HTML value for the element.
        public string InnerHtml
        {
            get
            {
                return this._tagBuilder.InnerHtml;
            }
            set
            {
                this._tagBuilder.InnerHtml = value;
            }
        }

        //
        // Summary:
        //     Gets the tag name for this tag.
        //
        // Returns:
        //     The name.
        public string TagName { get { return this._tagBuilder.TagName; } }

        public TagBuilder(string tagName)
        {
            this._tagBuilder = new System.Web.Mvc.TagBuilder(tagName);
        }


        // Summary:
        //     Adds a CSS class to the list of CSS classes in the tag.
        //
        // Parameters:
        //   value:
        //     The CSS class to add.
        public TagBuilder SetCssClass(string value)
        {
            if (!string.IsNullOrEmpty(value))
                this._tagBuilder.AddCssClass(value);
            return this;
        }

        //
        // Summary:
        //     Generates a sanitized ID attribute for the tag by using the specified name.
        //
        // Parameters:
        //   name:
        //     The name to use to generate an ID attribute.
        public TagBuilder WithId(string name)
        {
            this._tagBuilder.GenerateId(name);
            return this;
        }
        public TagBuilder WithName(string name)
        {
            this.SetAttribute("name", name);
            return this;
        }
        //
        // Summary:
        //     Adds a new attribute to the tag.
        //
        // Parameters:
        //   key:
        //     The key for the attribute.
        //
        //   value:
        //     The value of the attribute.
        public TagBuilder SetAttribute(string key, string value)
        {
            return this.SetAttribute(key, value, false);
        }

        //
        // Summary:
        //     Adds a new attribute or optionally replaces an existing attribute in the
        //     opening tag.
        //
        // Parameters:
        //   key:
        //     The key for the attribute.
        //
        //   value:
        //     The value of the attribute.
        //
        //   keepExisting:
        //     true to keep an existing attribute if an attribute exists that has the
        //     specified key value, or false to replace the original attribute.
        public TagBuilder SetAttribute(string key, string value, bool keepExisting)
        {
            this._tagBuilder.MergeAttribute(key, value, !keepExisting);
            return this;
        }
        //
        // Summary:
        //     Adds new attributes to the tag.
        //
        // Parameters:
        //   attributes:
        //     The collection of attributes to add.
        //
        // Type parameters:
        //   TKey:
        //     The type of the key object.
        //
        //   TValue:
        //     The type of the value object.
        public TagBuilder SetAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes)
        {
            this.SetAttributes(attributes, false);
            return this;
        }
        //
        // Summary:
        //     Adds new attributes or optionally replaces existing attributes in the tag.
        //
        // Parameters:
        //   attributes:
        //     The collection of attributes to add or replace.
        //
        //   keepExisting:
        //     For each attribute in attributes, false to replace the attribute if an attribute
        //     already exists that has the same key, or true to leave the original attribute
        //     unchanged.
        //
        // Type parameters:
        //   TKey:
        //     The type of the key object.
        //
        //   TValue:
        //     The type of the value object.
        public TagBuilder SetAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool keepExisting)
        {
            this._tagBuilder.MergeAttributes<TKey, TValue>(attributes, !keepExisting);
            return this;
        }
        //
        // Summary:
        //     Sets the System.Web.Mvc.TagBuilder.InnerHtml property of the element to an
        //     HTML-encoded version of the specified string.
        //
        // Parameters:
        //   innerText:
        //     The string to HTML-encode.
        public TagBuilder WithInnerText(string innerText)
        {
            this._tagBuilder.SetInnerText(innerText);
            return this;
        }

        public TagBuilder WithInnerElement(TagBuilder innerElement)
        {
            this._tagBuilder.InnerHtml += innerElement.ToHtmlString().ToString();
            return this;
        }

        public TagBuilder WithInnerElement(MvcHtmlString innerElement)
        {
            this._tagBuilder.InnerHtml += innerElement.ToString();
            return this;
        }

        public string SelfClosing()
        {
            return this.ToString(System.Web.Mvc.TagRenderMode.SelfClosing);
        }
        //
        // Summary:
        //     Renders the element as a System.Web.Mvc.TagRenderMode.Normal element.
        public override string ToString()
        {
            return this._tagBuilder.ToString();
        }
        //
        // Summary:
        //     Renders the HTML tag by using the specified render mode.
        //
        // Parameters:
        //   renderMode:
        //     The render mode.
        //
        // Returns:
        //     The rendered HTML tag.
        public string ToString(System.Web.Mvc.TagRenderMode renderMode)
        {
            return this._tagBuilder.ToString(renderMode);
        }

        public MvcHtmlString ToHtmlString()
        {
            return new MvcHtmlString(this.ToString());
        }
        public MvcHtmlString ToHtmlString(System.Web.Mvc.TagRenderMode renderMode)
        {
            return new MvcHtmlString(this._tagBuilder.ToString(renderMode));
        }


    }
}