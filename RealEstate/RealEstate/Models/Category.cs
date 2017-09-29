
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using RealEstate.HtmlHelpers;
namespace RealEstate.Models
{
    [Bind(Include = "Name,MetaDescription,Status")]
    [MetadataType(typeof(Category_Validation))]
    public partial class Category //Category isminde başka class olduğu için PARTİAL olmalı
    { 

    }
    public class Category_Validation //Emlak Kategorisi
    {
        [Required(ErrorMessageResourceName ="CategoryNameRequired",ErrorMessageResourceType =typeof(Resources.lang))]
        [StringLength(50,ErrorMessageResourceName ="CategoryNameString",ErrorMessageResourceType =typeof(Resources.lang))]
        [LocalizedDisplayName("CategoryNameDisplay",NameResourceType =typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("CategoryMetaDescriptionDisplay", NameResourceType = typeof(Resources.lang))]
        public string MetaDescription { get; set; }

        [LocalizedDisplayName("CategoryStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }

    }
}