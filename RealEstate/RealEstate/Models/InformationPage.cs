using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="Name,SeoWord,MetaDescription,Text,Status")]
    [MetadataType(typeof(InformationPage_Validation))]
    public partial class InformationPage
    {
    }
    public class InformationPage_Validation
    {
        [Required(ErrorMessageResourceName = "InformationPageNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "InformationPageNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("InformationPageNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [StringLength(50, ErrorMessageResourceName = "InformationPageSeoWordString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("InformationPageSeoWordDisplay", NameResourceType = typeof(Resources.lang))]
        public string SeoWord { get; set; }

        [LocalizedDisplayName("InformationPageMetaDescriptionDisplay", NameResourceType = typeof(Resources.lang))]
        public string MetaDescription { get; set; }

        [Required(ErrorMessageResourceName = "InformationPageTextRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("InformationPageTextDisplay", NameResourceType = typeof(Resources.lang))]
        public string Text { get; set; }

       
        [LocalizedDisplayName("InformationPageStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }
    }
}