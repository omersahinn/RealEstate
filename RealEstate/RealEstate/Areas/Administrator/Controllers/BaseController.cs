using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.Repositories;
using RealEstate.Models;
using System.Net;
using System.Text;
using RealEstate.HtmlHelpers;
using System.Linq.Expressions;

namespace RealEstate.Areas.Administrator.Controllers
{
    [Localization]
    [LanguageSessionControlAttribute]
    public class BaseController<T> : Controller,IRepository<T> where T:class,new()
    {
        DBDataContext db = new DBDataContext();

       
        public virtual ActionResult Index() //override edebilmek için virtual yaptık
        {
            var items = GetAll(1);
            return View(items);
        }
        public virtual ActionResult ListByID(int ParentID,string id,int pageIndex)
        {
            var items = GetAllByID(ParentID, id,pageIndex);
            return View("Index",items);
        }
        public virtual ActionResult Page(int PageIndex)
        {
            var items = GetAll(PageIndex);
            string name = typeof(T).Name;

            return PartialView(name + "List", items);

        }

        public virtual ActionResult Create()
        {
            return PartialView(new T());
        }
        [HttpPost]
        public virtual ActionResult Create(T item, int PageIndex, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(item);
            }

            try
            {
                Add(item);
                string name = typeof(T).Name;
                var items = GetAll(PageIndex);
                return PartialView(name + "List", items);
            }
            catch (Exception ex)
            {

                return Content(GetErrorMessage(ex));
            }
        }

        public virtual ActionResult Edit(int id)
        {

            T item = GetById(id);
            return PartialView(item);
        }
        [HttpPost]
        public virtual ActionResult Edit(int id,T item,int PageIndex,FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(item);
            }
            try
            {
               
                T itemdata = GetById(id);
                UpdateModel(itemdata);
                Save();

                string name = typeof(T).Name;
                var items = GetAll(PageIndex);
                return PartialView(name + "List", items);
            }
            catch (Exception ex)
            {

                return Content(GetErrorMessage(ex));
            }
        }
        public virtual ActionResult Search()
        {
            return PartialView();
        }
        [HttpPost]
        public virtual ActionResult Search(T item)
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

        public virtual ActionResult Delete(int PageIndex, int id)
        {
            try
            {
                T item = GetById(id);
                DeleteData(item);
                string name = typeof(T).Name;
                var items = GetAll(PageIndex);
                return PartialView(name + "List", items);

            }
            catch (Exception ex)
            {
                return Content(GetErrorMessage(ex));
            }
        }

        public string GetErrorMessage(Exception ex)
        {
            StringBuilder errorMessage = new StringBuilder(200);

            errorMessage.AppendFormat("<div class=\"validation-summary-error\" title=\"Server Error\">{0}</div>", ex.GetBaseException().Message);
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;  //jquerymodal'a 500 hata kodunu gönderiyor

            return errorMessage.ToString();
        }

        public void Add(T item)
        {
            db.GetTable<T>().InsertOnSubmit(item);
            Save();
        }

        public void DeleteData(T item)
        {
            db.GetTable<T>().DeleteOnSubmit(item);
            Save();
        }

        public IQueryable<T> GetAll(int pageIndex)
        {
            int pageSize = 25;
            this.RouteData.Values["PageIndex"] = pageIndex;
            pageIndex = pageIndex - 1;
            int totalCount = db.GetTable<T>().Count();
            int totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
            ViewData["TPage"] = totalPage;

            return db.GetTable<T>().Skip(pageIndex * pageSize).Take(pageSize);
        }

        public IQueryable<T> GetAllByID(int ParentID,string columnName,int pageIndex)
        {
            int pageSize = 25;
            this.RouteData.Values["PageIndex"] = pageIndex;
            pageIndex = pageIndex - 1;

            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal
                (
                    Expression.Property
                    (
                      itemParameter, columnName
                    ),
                    Expression.Constant(ParentID)
                ),
                new[] { itemParameter }

                );

            int totalCount = db.GetTable<T>().Where(whereExpression).Count();
            int totalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
            ViewData["TPage"] = totalPage;


            return db.GetTable<T>().Where(whereExpression).Skip(pageIndex * pageSize).Take(pageSize);
        }

        public T GetById(int id)
        {
            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal
                (
                    Expression.Property
                    (
                      itemParameter, "ID"
                    ),
                    Expression.Constant(id)
                ),
                new[] {itemParameter}

                );
           return db.GetTable<T>().SingleOrDefault(whereExpression);
        }

       
        public void Save()
        {
            db.SubmitChanges();
        }

        public virtual IQueryable<T> SearchData(string name)
        {
            this.RouteData.Values["PageIndex"] = 1;
            ViewData["TPage"] = 1;
            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal
                (
                    Expression.Property
                    (
                      itemParameter, "Name"
                    ),
                    Expression.Constant(name)
                ),
                new[] { itemParameter }

                );
            return db.GetTable<T>().Where(whereExpression);
        }
    }
}