using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RealEstate.HtmlHelpers;

namespace RealEstate.Areas.Administrator.Controllers
{
    public class FileUploadJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            this.ContentType = "text/html"; ;
            base.ExecuteResult(context);
        }
    }

    public class AdController : BaseController<Ad>
    {
        DBDataContext db = new DBDataContext();

        public ActionResult AdDetail(int id)
        {
            var kindID = db.Ads.SingleOrDefault(a => a.ID == id).KindID;
            ViewData["id"] = id;
            var items = db.KindDetails.Where(k => k.KindID == kindID);
            return View(items);


        }

        [HttpPost]
        public ActionResult AdDetail(int id , FormCollection form) //FormCollection form içindeki bütün verilerin id lerini alır
        {
            var ads = db.AdDetailByKinds.Where(a => a.AdID == id).ToList();

            db.AdDetailByKinds.DeleteAllOnSubmit(ads);
            
            var drops = form["KindDetailDrop"].Split(',');
            var hiddenDrops = form["hiddenDrop"].Split(',');

            var checks = form["MemberList"].Split(',');


            List<AdDetailByKind> adList = new List<AdDetailByKind>();


            for (int i = 0; i < hiddenDrops.Length; i++)
            {
                if (drops[i]!="")
                {
                    AdDetailByKind ad = new AdDetailByKind();
                    ad.AdID = id;
                    ad.KindDetailID = int.Parse(hiddenDrops[i]);
                    ad.KindDetailMemberID = int.Parse(drops[i]);
                    adList.Add(ad);
                }
              
            }

            for (int i = 0; i < checks.Length; i++)
            {
                AdDetailByKind ad = new AdDetailByKind();
                ad.AdID = id;
                ad.KindDetailID = int.Parse(checks[i].Split('-')[1]);
                ad.KindDetailMemberID = int.Parse(checks[i].Split('-')[1]);

                adList.Add(ad);
            }

            db.AdDetailByKinds.InsertAllOnSubmit(adList);

            return RedirectToAction("Index");
        }
        public ActionResult UploadPicture(int id)
        {
        
            var items = db.AdToPhotos.Where(a => a.AdID == id);
            ViewData["id"] = id;
            return View(items);
        }

        [HttpPost]
        public ActionResult DeletePicture(int id)
        {
            try
            {
                AdToPhoto img = db.AdToPhotos.SingleOrDefault(a => a.ID == id);
                db.AdToPhotos.DeleteOnSubmit(img);

                var directories = from f in new DirectoryInfo(Server.MapPath("/AdImages/")).GetDirectories() select f;

                foreach (var item in directories)
                {
                    FileInfo ff = new FileInfo(Server.MapPath("/AdImages/" + item.Name + "/" + img.Photo));

                    if (ff.Exists)
                        ff.Delete();
                }

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return Content(GetErrorMessage(ex));
            }


            return Json(id);
        }
      
      
        public FileUploadJsonResult Upload(int id)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                string photo = Guid.NewGuid().ToString() + ".png";

                var f = this.Request.Files["upload"];
                string savedFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Server.MapPath("/AdImages/"));
                savedFile = Path.Combine(savedFile, photo);

                f.SaveAs(savedFile);
                

                FileResize.ImageResize(100, 100, "/AdImages/" + photo, "/AdImages/100x100/" + photo);
                FileResize.ImageResize(400, 216, "/AdImages/" + photo, "/AdImages/400x216/" + photo);
                FileResize.ImageResize(250, 250, "/AdImages/" + photo, "/AdImages/250x250/" + photo);
                FileResize.ImageResize(500, 500, "/AdImages/" + photo, "/AdImages/500x500/" + photo);
                FileResize.ImageResize(38, 38, "/AdImages/" + photo, "/AdImages/38x38/" + photo);
                AdToPhoto img = new AdToPhoto();
                img.AdID = id;
                img.Photo = photo;

                db.AdToPhotos.InsertOnSubmit(img);
                db.SubmitChanges();

                sb.Append("<li id=" + img.ID + "><img alt='' src='/AdImages/100x100/" + photo + "'/><div class='actions'><a  class='btn btn-orange btn-small' rel='facebox' href='/AdImages/400x216/" + photo + "'>" + Resources.lang.View + "</a><a href='javascript:;' name=" + img.ID + " class='btn btn-grey btn-small delete'>" + Resources.lang.Delete + "</a></div></li>");
            }
            catch (Exception)
            {

                throw;
            }

            return new FileUploadJsonResult { Data = sb.ToString() };

        }

        [ValidateInput(false)]
        [HttpPost]
        public override ActionResult Create(Ad item, int PageIndex, FormCollection form)

        {

            if (!ModelState.IsValid)
            {
                return View(item);
            }

            try
            {
                item.DateAdded = DateTime.Now;
                Add(item);

                return RedirectToAction("Index");   
            }
            catch (Exception ex)
            {
                return Content(GetErrorMessage(ex));
            }
          
            
        }
        [ValidateInput(false)]
        [HttpPost]
         public override ActionResult Edit(int id,Ad item, int PageIndex,FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }
            try
            {
                
                Ad ad = GetById(id);
                ad.DateModified = DateTime.Now;
                UpdateModel(ad);
                Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return Content(GetErrorMessage(ex));
            }
        }

        [HttpPost]
        public JsonResult GetType(int id)
        {
            
            var items = db.Types.Where(t => t.KindID == id).Where(t => t.Status == true);
            StringBuilder sb = new StringBuilder();
            string drop;
            foreach (Models.Type item in items)
            {
                drop = "<option value=" + item.ID + ">" + item.Name + "<option>";
                sb.Append(drop);
            }
            return Json(sb.ToString());
        }

        [HttpPost]
        public JsonResult GetTown(int id)
        {
            var items = db.Towns.Where(t => t.CityID == id).Where(t => t.Status == true);
            StringBuilder sb = new StringBuilder();
            string drop;
            foreach (Town item in items)
            {
                drop = "<option value=" + item.ID + ">" + item.Name + "<option>";
                sb.Append(drop);
            }
            return Json(sb.ToString());
        }

        [HttpPost]
        public JsonResult GetDistrict(int id)
        {
            var items = db.Districts.Where(t => t.TownID == id).Where(t => t.Status == true);
            StringBuilder sb = new StringBuilder();
            string drop;
            foreach (District item in items)
            {
                drop = "<option value=" + item.ID + ">" + item.Name + "<option>";
                sb.Append(drop);
            }
            return Json(sb.ToString());
        }
    }
}