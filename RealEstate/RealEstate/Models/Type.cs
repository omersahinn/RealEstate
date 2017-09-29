using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="KindID,Name,Status")]
    [MetadataType(typeof(Type_Validation))]
    public partial class Type
    {
        public List<Kind> kindList { get; set; }

        public void PartialConst()
        {
            DBDataContext db = new DBDataContext();
            kindList = db.Kinds.Where(a => a.Status == true).ToList();
        }
    }
    public class Type_Validation
    {
        [LocalizedDisplayName("TypeKindIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int KindID { get; set; }

        [Required(ErrorMessageResourceName = "TypeNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "TypeNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("TypeNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("TypeStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }


    }
}