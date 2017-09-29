using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{    [Bind(Include ="Name,Status")]
     [MetadataType(typeof(City_Validation))]
    public partial class City
    {
    }
    public class City_Validation
    {
        [Required(ErrorMessageResourceName ="CityNameRequired",ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "CityNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("CityNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("CityStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }
    }
}