using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{

    [Bind(Include = "TownID,Name,Status")]
    [MetadataType(typeof(District_Validation))]
    public partial class District
    {
        public List<Town> townList
        {
            get
            {
                DBDataContext db = new DBDataContext();
                return db.Towns.Where(a => a.Status == true).ToList();
            }
        }

    }

    public class District_Validation
    {
        [LocalizedDisplayName("DistrictTownIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int TownID { get; set; }

        [Required(ErrorMessageResourceName = "DistrictNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "DistrictNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("DistrictNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("DistrictStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }


    }
}