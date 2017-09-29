using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="KindDetailID,Name,Status")]
    [MetadataType(typeof(KindDetailMember_Validation))]
    public partial class KindDetailMember
    {
        public List<KindDetail> kindDetailList
        {
            get
            {
                DBDataContext db = new DBDataContext();
                return db.KindDetails.Where(a => a.Status == true).ToList();
            }
        }

    }

    public class KindDetailMember_Validation
    {
        [LocalizedDisplayName("KindDetailMemberKindDetailIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int KindDetailID { get; set; }

        [Required(ErrorMessageResourceName = "KindDetailMemberNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "KindDetailMemberNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("KindDetailMemberNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("KindDetailMemberStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }


    }
}