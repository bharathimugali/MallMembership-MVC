using MallMembership.BusinessLayer;
using MallMemebership.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebGrease.Extensions;

namespace MallMembership.CustomHtmlHepler
{
    public static class CustomHelper
    {
        public static IHtmlString MallWorkFlowActionLink(this HtmlHelper helper, string path, int? id,string text)
        {
            TagBuilder tb = new TagBuilder("a");
            tb.SetInnerText(text);

            if (id != null)
            {
                tb.Attributes.Add("href", path);
                tb.AddCssClass("color");
                return new HtmlString(tb.ToString());
            }
            else
            {
                return new HtmlString(tb.ToString());
            }

        }
    }
}