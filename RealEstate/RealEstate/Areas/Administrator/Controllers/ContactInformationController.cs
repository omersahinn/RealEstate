using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Areas.Administrator.Controllers
{
    public class ContactInformationController : BaseController<ContactInformation>
    {
        DBDataContext db = new DBDataContext();
        [HttpPost]
        public override ActionResult Search(ContactInformation item)
        {
            if (!ModelState.IsValidField("CompanyName"))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(item);
            }
            var name = item.GetType().GetProperty("CompanyName").GetValue(item, null);
            var items = SearchData(name.ToString());
            ViewData["Search"] = true;
            string listName = typeof(ContactInformation).Name;
            return PartialView(listName + "List", items);
        }

        public override IQueryable<ContactInformation> SearchData(string name)
        {
            this.RouteData.Values["PageIndex"] = 1;
            ViewData["TPage"] = 1;
            var itemParameter = Expression.Parameter(typeof(ContactInformation), "item");
            var whereExpression = Expression.Lambda<Func<ContactInformation, bool>>
                (
                Expression.Equal
                (
                    Expression.Property
                    (
                      itemParameter, "CompanyName"
                    ),
                    Expression.Constant(name)
                ),
                new[] { itemParameter }

                );
            return db.GetTable<ContactInformation>().Where(whereExpression);
        }
    }
}