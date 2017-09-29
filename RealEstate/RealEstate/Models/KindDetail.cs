using RealEstate.HtmlHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="KindID,Name,ControlType,Status")]
    public partial class KindDetail
    {
        public List<Kind> kindList
        {
            get
            {
                DBDataContext db = new DBDataContext();
                return db.Kinds.Where(a => a.Status == true).ToList();
            }
        }
    }

    public class KindDetail_Validation
    {
        [LocalizedDisplayName("KindDetailKindIDDisplay",NameResourceType =typeof(Resources.lang))]
        public int KindID { get; set; }

        [Required(ErrorMessageResourceName = "KindDetailNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "KindDetailNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("KindDetailNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("KindDetailControlTypeDisplay", NameResourceType = typeof(Resources.lang))]
        public string ControlType { get; set; }

        [LocalizedDisplayName("KindDetailStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }
    }
}