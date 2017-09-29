using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="CompanyName,FixedPhone,Fax,MobilePhone,Email,Address,Status")]
    [MetadataType(typeof(ContactInformation_Validation))]
    public partial class ContactInformation
    {
    }

    public class ContactInformation_Validation
    {
        
        [StringLength(100, ErrorMessageResourceName = "ContactInfoCompanyNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("ContactInfoCompanyNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string CompanyName { get; set; }

       
        [StringLength(13, ErrorMessageResourceName = "ContactInfoFixedPhoneString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("ContactInfoFixedPhoneDisplay", NameResourceType = typeof(Resources.lang))]
        public string FixedPhone { get; set; }

        
        [StringLength(13, ErrorMessageResourceName = "ContactInformationFaxString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("ContactInformationFaxDisplay", NameResourceType = typeof(Resources.lang))]
        public string Fax { get; set; }

      
        [StringLength(13, ErrorMessageResourceName = "ContactInfoMobilePhoneString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("ContactInfoMobilePhoneDisplay", NameResourceType = typeof(Resources.lang))]      
        public string MobilePhone { get; set; }

        
        [StringLength(100, ErrorMessageResourceName = "ContactInfoEmailString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("ContactInfoEmailDisplay", NameResourceType = typeof(Resources.lang))]
        [EmailAddresses(ErrorMessageResourceName = "ContactInfoEmailInvalid", ErrorMessageResourceType = typeof(Resources.lang))]
        public String Email { get; set; }

       
        [StringLength(255, ErrorMessageResourceName = "ContactInfoAddressString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("ContactInfoAddressDisplay", NameResourceType = typeof(Resources.lang))]
        public String Address { get; set; }

        [LocalizedDisplayName("ContactInfoStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }
    }

}