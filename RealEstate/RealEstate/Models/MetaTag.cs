using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="Title,MetaDescription,Keywords")]
    [MetadataType(typeof(MetaTag_Validation))]
    public partial class MetaTag
    {
    }
    public class MetaTag_Validation
    {
        [Required(ErrorMessageResourceName ="MetaTagTitleRequired",ErrorMessageResourceType =typeof(Resources.lang))]
        [LocalizedDisplayName("MetaTagTitleDisplay",NameResourceType =typeof(Resources.lang))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "MetaTagDescRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("MetaTagdescDisplay", NameResourceType = typeof(Resources.lang))]
        public string MetaDescription { get; set; }

        [Required(ErrorMessageResourceName = "MetaTagKeywordRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("MetaTagKeywordDisplay", NameResourceType = typeof(Resources.lang))]
        public string Keywords { get; set; }




    }

}