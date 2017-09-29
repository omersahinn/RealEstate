using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{   [Bind(Include ="CityID,Name,Status")]
    [MetadataType(typeof(Town_Validation))]
    public partial class Town
    {
        public List<City> cityList
        {

            get
            {
                DBDataContext db = new DBDataContext();
                return db.Cities.Where(a => a.Status == true).ToList();
            }
        }
        
          
    

    }

    public class Town_Validation
    {
        [LocalizedDisplayName("TownCityIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int CityID { get; set; }

        [Required(ErrorMessageResourceName = "TownNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "TownNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("TownNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("TownStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }

    }
}