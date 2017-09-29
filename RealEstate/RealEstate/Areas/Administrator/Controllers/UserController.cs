using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RealEstate.Areas.Administrator.Controllers
{
    public class UserController : BaseController<User>
    {
        [HttpPost]
        public override ActionResult Create(User item, int PageIndex, FormCollection form)
        {

            item.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(item.Password, "md5");
            return base.Create(item, PageIndex, form);
        }
        [HttpPost]
        public override ActionResult Edit(int id, User item, int PageIndex, FormCollection form)
        {
            item.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(item.Password, "md5");
            return base.Edit(id, item, PageIndex, form);
        }
    }
}