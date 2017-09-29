using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.HtmlHelpers;
namespace RealEstate.Models
{
    [Bind(Include ="UserGroupID,Name,UserName,Email,Phone,Password,ConfirmPassword,Status")]
    [MetadataType(typeof(User_Validation))]
    public partial class User
    {

        public List<UserGroup> userGroupList
        {
            get
            {
                DBDataContext db = new DBDataContext();
                return db.UserGroups.Where(u => u.Status == true).ToList();
            }
            
        }
        public string ConfirmPassword { get; set; }
    }
   [MyPropertiesMustMatch("Password","ConfirmPassword",ErrorMessageResourceName ="UserConfirmPass",ErrorMessageResourceType =typeof(Resources.lang))]
    public class User_Validation
    {
        [LocalizedDisplayName("UserUserGroupDisplay", NameResourceType = typeof(Resources.lang))]
        public int UserGroupID { get; set; }

        [Required(ErrorMessageResourceName = "UserNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(100, ErrorMessageResourceName = "UserNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("UserNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "UserUserNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "UserUserNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("UserUserNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "UserEmailRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(100, ErrorMessageResourceName = "UserEmailString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("UserEmailDisplay", NameResourceType = typeof(Resources.lang))]
        public string Email { get; set; }

        [StringLength(13, ErrorMessageResourceName = "UserPhoneString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("UserPhoneDisplay", NameResourceType = typeof(Resources.lang))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceName = "UserPassRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "UserPassString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("UserPassDisplay", NameResourceType = typeof(Resources.lang))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "UserConfirmPassRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "UserConfirmPassString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("UserConfirmPassDisplay", NameResourceType = typeof(Resources.lang))]
        public string ConfirmPassword { get; set; }

        [LocalizedDisplayName("UserStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }
    }
}