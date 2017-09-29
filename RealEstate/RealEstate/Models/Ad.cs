using RealEstate.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    [Bind(Include ="CategoryID,KindID,TypeID,CityID,TownID,DistrictID,Location,Price,PriceCurrencyID,Deposit,DepositCurrencyID,SalesmanID,OwnerName,OwnerPhone,OwnerEmail,Status,DateAdded,DateModified,Title,Description,MetaDescription,Keywords,Seoword")]
    [MetadataType(typeof(Ad_Validation))]
    public partial class Ad
    {
        
        int cityID;
        int townID;
        int kindID;
        DBDataContext db = new DBDataContext();
        public void PartialConst()
        {
           
            cityID = db.Cities.Where(c => c.Status == true).Select(c => c.ID).FirstOrDefault();
            townID = db.Towns.Where(t => t.CityID == cityID).Select(t => t.ID).FirstOrDefault();
            kindID = db.Kinds.Where(k => k.Status == true).Select(k => k.ID).FirstOrDefault();
        }

        public List<Category> categoryList
        {
            get
            {
                
                return db.Categories.Where(c => c.Status == true).ToList();
            }
        }

        public List<Kind> kindList
        {
            get
            {
                return db.Kinds.Where(k => k.Status == true).ToList();
            }
        }

        public List<Type> typeList
        {
            get
            {
                return db.Types.Where(t => t.KindID == kindID).Where(t => t.Status == true).ToList();
            }
        }

        public List<City> cityList
        {
            get
            {
                return db.Cities.Where(c => c.Status == true).ToList();
            }
        }

        public List<Town> townList
        {
            get
            {
                return db.Towns.Where(t => t.CityID == cityID).Where(t => t.Status == true).ToList();
            }
        }

        public List<District> districtList
        {
            get
            {
                return db.Districts.Where(d => d.TownID == townID).Where(d => d.Status == true).ToList();
            }
        }

        public List<Currency> currencyList
        {
            get
            {
                return db.Currencies.Where(c => c.Status == true).ToList();
            }
        }

        public List<Salesman> salesmanList
        {
            get
            {
                return db.Salesmans.Where(s => s.Status == true).ToList();
            }
        }
    }
    public class Ad_Validation
    {
        [LocalizedDisplayName("AdCategoryIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int CategoryID { get; set; }

        [LocalizedDisplayName("AdKindIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int KindID { get; set; }

        [LocalizedDisplayName("AdTypeIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int TypeID { get; set; }

        [LocalizedDisplayName("AdCityIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int CityID { get; set; }

        [LocalizedDisplayName("AdTownIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int TownID { get; set; }

        [LocalizedDisplayName("AdDistrictIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int DistrictID { get; set; }

        [StringLength(100, ErrorMessageResourceName = "AdLocationString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("AdLocationDisplay", NameResourceType = typeof(Resources.lang))]
        public string Location { get; set; }

        [LocalizedDisplayName("AdPriceDisplay", NameResourceType = typeof(Resources.lang))]
        public decimal Price { get; set; }

        [LocalizedDisplayName("AdDepositDisplay", NameResourceType = typeof(Resources.lang))]
        public decimal Deposit { get; set; }

        [LocalizedDisplayName("AdSalesmanIDDisplay", NameResourceType = typeof(Resources.lang))]
        public int SalesmanID { get; set; }

        [StringLength(100, ErrorMessageResourceName = "AdOwnerNameString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("AdOwnerNameDisplay", NameResourceType = typeof(Resources.lang))]
        public string OwnerName { get; set; }

        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        [StringLength(13, ErrorMessageResourceName = "AdOwnerPhoneString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("AdOwnerPhoneDisplay", NameResourceType = typeof(Resources.lang))]
        public string OwnerPhone { get; set; }

        [EmailAddress(ErrorMessageResourceName = "AdEmailInvalid", ErrorMessageResourceType = typeof(Resources.lang))]
        [StringLength(100, ErrorMessageResourceName = "AdOwnerEmailString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("AdOwnerEmailDisplay", NameResourceType = typeof(Resources.lang))]
        public string OwnerEmail { get; set; }

        [LocalizedDisplayName("AdStatusDisplay", NameResourceType = typeof(Resources.lang))]
        public bool Status { get; set; }

        [Required(ErrorMessageResourceName = "AdTitleRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("AdTitleDisplay", NameResourceType = typeof(Resources.lang))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "AdDescriptionRequired", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("AdDescriptionDisplay", NameResourceType = typeof(Resources.lang))]
        public string Description { get; set; }

        [LocalizedDisplayName("AdMetaDescriptionDisplay", NameResourceType = typeof(Resources.lang))]
        public string MetaDescription { get; set; }

        [LocalizedDisplayName("AdKeywordsDisplay", NameResourceType = typeof(Resources.lang))]
        public string Keywords { get; set; }

        [StringLength(255, ErrorMessageResourceName = "AdSeoWordString", ErrorMessageResourceType = typeof(Resources.lang))]
        [LocalizedDisplayName("AdSeoWordDisplay", NameResourceType = typeof(Resources.lang))]
        public string Seoword { get; set; }
    }

}