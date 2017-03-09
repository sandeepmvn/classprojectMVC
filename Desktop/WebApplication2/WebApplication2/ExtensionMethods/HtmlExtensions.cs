using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2
{
    public static class HtmlExtensions
    {
        public static string FormatToCurrency(this HtmlHelper helper, decimal amount)
        {
            return string.Format("{0:c}", amount);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            TagBuilder bulder = new TagBuilder("img");
            bulder.MergeAttribute("src", src);
            bulder.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(bulder.ToString(TagRenderMode.SelfClosing));
        }
    }
}