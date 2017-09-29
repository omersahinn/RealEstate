using RealEstate.Models;
using System.Web.Mvc;

namespace RealEstate.Areas.Administrator.Controllers
{
    public class LanguageController : BaseController<Language>
    {

        public JsonResult GetCode(string fileName)
        {
            string code = fileName.Substring(0, fileName.Length - 5);
            code = code.Substring(5, code.Length - 5);

            return Json(code);
        }
    }
}