using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Areas.Administrator.Controllers
{
    public class InformationPageController : BaseController<InformationPage>
    {
        public override ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public override ActionResult Create(InformationPage item, int PageIndex, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            try
            {
                Add(item);
                
            }
            catch (Exception ex)
            {

                return Content(GetErrorMessage(ex));
            }
            return RedirectToAction("Index");
        }

        public override ActionResult Edit(int id)
        {
            InformationPage item = GetById(id);
            return View(item);
        }

        [ValidateInput(false)]
        [HttpPost]
        public override ActionResult Edit(int id, InformationPage item, int PageIndex, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return View(item);

            }
            try
            {
                InformationPage info = GetById(id);
                UpdateModel(info);
                Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(GetErrorMessage(ex));
                
            }
        }
    }
}










