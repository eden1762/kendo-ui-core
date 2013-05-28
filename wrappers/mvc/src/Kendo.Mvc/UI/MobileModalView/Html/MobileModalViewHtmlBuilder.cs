namespace Kendo.Mvc.UI
{
    using System;
    using System.Collections.Generic;
    using Kendo.Mvc.Extensions;

    public class MobileModalViewHtmlBuilder
    {
        private readonly MobileModalView component;

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileModalViewHtmlBuilder" /> class.
        /// </summary>
        /// <param name="component">The MobileModalView component.</param>
        public MobileModalViewHtmlBuilder(MobileModalView component)
        {
            this.component = component;
        }

        /// <summary>
        /// Builds the MobileModalView markup.
        /// </summary>
        /// <returns></returns>
        public IHtmlNode Build()
        {
            var html = CreateElement();
            html.Attribute("data-role", "modalview")
                .Attribute("id", component.Id);

            html.Children.Add(CreateHeaderElement());
            html.Children.Add(CreateContentElement());
            html.Children.Add(CreateFooterElement());

            AddEventAttributes(html, component.Events);

            if (component.Title.HasValue())
            {
                html.Attribute("data-title", component.Title);
            }

            if (component.Height.HasValue())
            {
                html.Attribute("data-height", component.Height);
            }

            if (component.Width.HasValue())
            {
                html.Attribute("data-width", component.Width);
            }

            html.Attribute("data-modal", component.Modal ? "true" : "false");
            html.Attribute("data-use-native-scrolling", component.UseNativeScrolling ? "true" : "false");
            html.Attribute("data-stretch", component.Stretch ? "true" : "false");
            html.Attribute("data-zoom", component.Zoom ? "true" : "false");

            html.Attributes(component.HtmlAttributes);

            return html;
        }

        protected virtual IHtmlNode CreateElement()
        {
            return new HtmlElement("div");
        }

        
        protected virtual void AddEventAttributes(IHtmlNode html, IDictionary<string, object> events)
        {
            foreach (var keyValuePair in events)
            {
                var value = keyValuePair.Value as ClientHandlerDescriptor;
                var key = "data-" + keyValuePair.Key;

                if (value.HandlerName.HasValue())
                {
                    html.Attribute(key, value.HandlerName);
                }

            }
        }

        protected virtual IHtmlNode CreateHeaderElement()
        {
            var dom = new HtmlElement("header")
                        .Attribute("data-role", "header");

            if (component.Header.HasValue())
            {
                component.Header.Apply(dom);
            }

            return dom;
        }

        protected virtual IHtmlNode CreateContentElement()
        {
            var dom = new HtmlElement("div")
                        .Attribute("data-role", "content");

            if (component.Content.HasValue())
            {
                component.Content.Apply(dom);
            }

            return dom;
        }

        protected virtual IHtmlNode CreateFooterElement()
        {
            var dom = new HtmlElement("footer")
                        .Attribute("data-role", "footer");

            if (component.Footer.HasValue())
            {
                component.Footer.Apply(dom);
            }

            return dom;
        }
    }
}

