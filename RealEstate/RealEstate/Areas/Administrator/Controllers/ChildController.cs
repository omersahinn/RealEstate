using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Areas.Administrator.Controllers
{
    public class ChildController<T,B> : BaseController<T> where T:class,new()
    {
       
        public override ActionResult Index()
        {
            int id = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            
            var name = typeof(B).Name;

            var items = GetAllByID(id,name + "ID", 1);
            return View(items);
        }
        public override ActionResult Page(int PageIndex)
        {
            int id = int.Parse(this.Url.RequestContext.RouteData.Values["id"].ToString());
            var pName = typeof(B).Name;
            var name = typeof(T).Name;

            var items = GetAllByID(id, pName + "ID", PageIndex);

            return PartialView(name + "List", items);
        }
       
        [HttpPost]
        public override ActionResult Create(T item, int PageIndex, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(item);
            }

            try
            {
                Add(item);
                var pname = typeof(B).Name;
                var name = typeof(T).Name;
                var parentID = item.GetType().GetProperty(pname + "ID").GetValue(item, null);

                var items = GetAllByID(int.Parse(parentID.ToString()),pname + "ID", PageIndex);
                return PartialView(pname+"List", items);
            }
            catch (System.Exception ex)
            {

                return Content(GetErrorMessage(ex));

            }
        }

        [HttpPost]
        public override ActionResult Edit(int id, T item, int PageIndex, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            }
            try
            {
                T itemData = GetById(id);
                UpdateModel(itemData);
                Save();

                var pname = typeof(B).Name;
                var name = typeof(T).Name;

                var parentID = item.GetType().GetProperty(pname + "ID").GetValue(item, null);

                var items = GetAllByID(int.Parse(parentID.ToString()), pname + "ID", PageIndex);
                return PartialView(name + "List", items);
            }
            catch (Exception ex)
            {

                return Content(GetErrorMessage(ex));
            }
        }

        public override ActionResult Delete(int PageIndex, int id)
        {
            try
            {
                T item = GetById(id);
                DeleteData(item);

                var pname = typeof(B).Name;
                var name = typeof(T).Name;

                var parentID = item.GetType().GetProperty(pname + "ID").GetValue(item, null);

                var items = GetAllByID(int.Parse(parentID.ToString()), pname + "ID", PageIndex);
                return PartialView(name + "List", items);
            }
            catch (Exception ex)
            {

                return Content(GetErrorMessage(ex));
            }
        }

        [HttpPost]
        public override ActionResult Search(T item)
        {
            if (!ModelState.IsValidField("Name"))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(item);
            }
            var name = item.GetType().GetProperty("Name").GetValue(item, null);
           

            var items = SearchData(name.ToString());
            ViewData["Search"] = true;
            string listName = typeof(T).Name;
            return PartialView(listName + "List", items);
        }
    }
}