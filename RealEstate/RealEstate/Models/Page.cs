using RealEstate.HtmlHelpers;
using RealEstate.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include = "Name,ControllerAndAction")]
    [MetadataType(typeof(Page_Validation))]
    public partial class Page
    {
        public List<string> viewList
        {
            get
            {
                return GetFiles.GetViewvsFiles();
            }
        }


    }

    public class Page_Validation
    {
        [Required(ErrorMessageResourceName = "PageNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(255, ErrorMessageResourceName = "PageNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("PageNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

      
        [LocalizedDisplayName("PageControlActionDisplay", NameResourceType = typeof(Resources.lang))]
        public String ControllerAndAction { get; set; }
    }
}