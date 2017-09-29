using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Areas.Administrator.Controllers
{
    public class UserGroupController : BaseController<UserGroup>
    {
        public override ActionResult Create(UserGroup user, int PageIndex, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return PartialView(user);
            }

            try
            {
                var ids = form["PageList"].Split(',');

                foreach (var item in ids)
                {
                    Permission perm = new Permission();
                    perm.PageID = int.Parse(item);

                    user.Permissions.Add(perm);
                }

                Add(user);

                var items = GetAll(PageIndex);

                return PartialView("UserGroupList", items);
            }
            catch (Exception ex)
            {
                return Content(GetErrorMessage(ex));
            }
        }

        public override ActionResult Edit(int id, UserGroup user, int PageIndex, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return PartialView(user);
            }

            try
            {
                UserGroup u = GetById(id);
                u.DeletePerm();

                var ids = form["PageList"].Split(',');
                foreach (var item in ids)
                {
                    Permission perm = new Permission();
                    perm.PageID = int.Parse(item);

                    u.Permissions.Add(perm);
                }

                UpdateModel(u);
                Save();

                var items = GetAll(PageIndex);

                return PartialView("UserGroupList", items);
            }
            catch (Exception ex)
            {
                return Content(GetErrorMessage(ex));
            }
        }
    }
}