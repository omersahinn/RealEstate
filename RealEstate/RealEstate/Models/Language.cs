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
    [Bind(Include ="Name,Code,Flag,FileName,Status")]
    [MetadataType(typeof(Language_Validation))]
    public partial class Language
    {
        public List<String> FlagList
        {
            get
            {
                return GetFiles.GetLanguageFiles("/Flags/");
            }
        }
        public List<String> FileList
        {
            get
            {
                return GetFiles.GetLanguageFiles("/App_GlobalResources/");
            }
        }

       
    }
    public class Language_Validation
    {
        [Required(ErrorMessageResourceName ="LanguageNameRequired",ErrorMessageResourceType =typeof(Resources.lang))]
        [StringLength(50,ErrorMessageResourceName ="LanguageNameString",ErrorMessageResourceType =typeof(Resources.lang))]
        [LocalizedDisplayName("LanguageNameDisplay",NameResourceType =typeof(Resources.lang))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "LanguageCodeRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(10, ErrorMessageResourceName = "LanguageCodeString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("LanguageCodeDisplay", NameResourceType = typeof(Resources.lang))]
        public string Code { get; set; }

        [LocalizedDisplayName("LanguageFlagDisplay", NameResourceType = typeof(Resources.lang))]
        public string Flag { get; set; }

        [LocalizedDisplayName("LanguageFileNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string FileName { get; set; }

        [LocalizedDisplayName("LanguageStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }
    }
        
}