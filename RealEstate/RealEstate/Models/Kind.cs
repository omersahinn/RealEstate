using RealEstate.HtmlHelpers;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="Name,Status")]
    [MetadataType(typeof(Kind_Validation))]
    public partial class Kind //Kind isminde başka class olduğu için PARTİAL olmalı
    {

    }
    public class Kind_Validation //Emlak Türü
    {
        [Required(ErrorMessageResourceName = "KindNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "KindNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("KindNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("KindStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }

    }
}