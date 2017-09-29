using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="Name,Phone,Email,Status")]
    [MetadataType(typeof(Salesman_Validation))]
    public partial class Salesman
    {
    }
    public class Salesman_Validation
    {
        [Required(ErrorMessageResourceName="SalesmanNameRequired",ErrorMessageResourceType =typeof(Resources.lang))]
        [StringLength(100,ErrorMessageResourceName ="SalesmanNameString",ErrorMessageResourceType =typeof(Resources.lang))]
        [LocalizedDisplayName("SalesmanNameDisplay",NameResourceType =typeof(Resources.lang))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "SalesmanPhoneRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(13, ErrorMessageResourceName = "SalesmanPhoneString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("SalesmanPhoneDisplay", NameResourceType = typeof(Resources.lang))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceName = "SalesmanEmailRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(100, ErrorMessageResourceName = "SalesmanEmailString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("SalesmanEmailDisplay", NameResourceType = typeof(Resources.lang))]
        [EmailAddresses(ErrorMessageResourceName="SalesmanEmailInvalid",ErrorMessageResourceType=typeof(Resources.lang))]
        public string Email { get; set; }

        [LocalizedDisplayName("SlaesmanStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }

    }
}