using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Areas.Administrator.Controllers
{
    public class MetaTagController : BaseController<MetaTag>
    {
        public override ActionResult Edit(int id)
        {
            MetaTag metaTag = GetById(id);

            return View(metaTag);
        }
        public override ActionResult Edit(int id, MetaTag item, int PageIndex,FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            try
            {
                MetaTag meta = GetById(id);
                UpdateModel(meta);
                Save();

                return View(meta);
            }
            catch (Exception ex)
            {
                return Content(GetErrorMessage(ex));
                
            }

        }
    }
}