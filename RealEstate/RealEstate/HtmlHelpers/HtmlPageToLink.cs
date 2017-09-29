
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RealEstate.HtmlHelpers
{
    public static class HtmlPageToLink
    {
        public static MvcHtmlString BackToLink(this HtmlHelper html)
        {
            string id = html.ViewContext.RouteData.Values["id"] == null ? null : html.ViewContext.RouteData.Values["id"].ToString();
            if (html.ViewData["Search"]!=null)
            return html.ActionLink(Resources.lang.Back, "Page", new { PageIndex = 1,id=id},new { @class = "aPage" });

            return MvcHtmlString.Create("");
        }
       
        public static MvcHtmlString PageToLink(this HtmlHelper html,int TPage)
        {
            UrlHelper url = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);

            string controllerName = url.RequestContext.RouteData.Values["controller"].ToString();
            int Page = int.Parse(url.RequestContext.RouteData.Values["PageIndex"].ToString());

            StringBuilder sb = new StringBuilder();
            string id =html.ViewContext.RouteData.Values["id"]==null ? null : html.ViewContext.RouteData.Values["id"].ToString();
            if (Page != 1)
            {
                string first = "<a class=\"aPage\" href=" + url.Action("Page", new { PageIndex = 1,id=id }) + "><img src=/Areas/Administrator/Content/images/first.gif></a>";
                sb.Append(first);

                string previous = "<a class=\"aPage\" href=" + url.Action("Page", new { PageIndex = (Page - 1), id = id }) + "><img src=/Areas/Administrator/Content/images/previous.gif ></a>";
                sb.Append(previous);

                sb.Append("....  ");
            }

            for (int i = (Page >= 7 ? (Page - 5) : 1); i <= ((Page + 5) < TPage ? (Page + 5) : TPage); i++)
            {
                if (i == Page)
                {
                    sb.Append(i);
                    sb.Append(" ");
                    continue;
                }
                var link = html.ActionLink(i.ToString(), "Page", new { PageIndex = i, id = id }, new { @class="aPage"});
                sb.Append(link.ToString());
                sb.Append(" ");

            }
            if (Page != TPage)
            {
                sb.Append("....  ");
                string next = "<a class=\"aPage\" href=" + url.Action("Page", new { PageIndex = (Page + 1), id = id }) + "><img src=/Areas/Administrator/Content/images/next.gif></a>";
                sb.Append(next);

                string last = "<a class=\"aPage\" href=" + url.Action("Page", new { PageIndex = (TPage), id = id }) + "><img src=/Areas/Administrator/Content/images/last.gif></a>";
                sb.Append(last);
            }


            return MvcHtmlString.Create(sb.ToString());

        }
    }
}