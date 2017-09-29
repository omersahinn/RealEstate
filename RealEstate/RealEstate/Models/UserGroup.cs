using RealEstate.HtmlHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include = "Name,Status")]
    [MetadataType(typeof(UserGroup_Validation))]
    public partial class UserGroup
    {
        public List<Page> pageList
        {
            get
            {
                DBDataContext db = new DBDataContext();
                 return db.Pages.ToList();
            }
        }
        public List<int> permList
        {
            get
            {
                DBDataContext db = new DBDataContext();
                return db.Permissions.Where(p=>p.UserGroupID==this.ID).Select(p => p.PageID).ToList();
            }
        }
        public void DeletePerm()
        {
            DBDataContext db = new DBDataContext();
            List<Permission> perm = db.Permissions.Where(p => p.UserGroupID == this.ID).ToList();
            db.Permissions.DeleteAllOnSubmit(perm);
            db.SubmitChanges();
        }
    }

    public class UserGroup_Validation
    {
        [Required(ErrorMessageResourceName = "UserGroupNameRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(50, ErrorMessageResourceName = "UserGroupNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("UserGroupNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string Name { get; set; }

        [LocalizedDisplayName("UserGroupStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }
    }
}