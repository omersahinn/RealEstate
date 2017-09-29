using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="Name,Code,Status")]
    [MetadataType(typeof(Currency_Validation))]
    public partial class Currency
    {
    }
    public class Currency_Validation
    {
        [Required(ErrorMessageResourceName ="CurrencyNameRequired",ErrorMessageResourceType =typeof(Resources.lang))]
        [StringLength(50,ErrorMessageResourceName ="CurrencyNameString",ErrorMessageResourceType =typeof(Resources.lang))]
        [LocalizedDisplayName("CurrencyNameDisplay",NameResourceType =typeof(Resources.lang))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "CurrencyCodeRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "CurrencyCodeString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("CurrencyCodeDisplay", NameResourceType = typeof(Resources.lang))]
        public string Code { get; set; }

        [LocalizedDisplayName("CurrencyStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }
    }

}