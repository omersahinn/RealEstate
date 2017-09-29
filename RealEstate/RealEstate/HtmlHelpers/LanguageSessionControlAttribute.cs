using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.Models;
using static RealEstate.HtmlHelpers.SwitchLanguageHelper;

namespace RealEstate.HtmlHelpers
{
    public class LanguageSessionControlAttribute : ActionFilterAttribute
    {
        public static StringDictionary LanguageSession = new StringDictionary();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (LanguageSession.Count == 0)
            {
                DBDataContext db = new DBDataContext();
                var languages = db.Languages.Where(l => l.Status == true);

                foreach (var item in languages)
                {
                    LanguageSession.Add(item.Code, item.Name);
                }
            }
        }
    }
}