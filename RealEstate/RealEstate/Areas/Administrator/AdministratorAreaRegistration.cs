using System.Web.Mvc;

namespace RealEstate.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrator_default",
                "Administrator/{lang}/{controller}/{action}/{PageIndex}/{id}/",
                new { action = "Index", id = UrlParameter.Optional, PageIndex=UrlParameter.Optional}
            );
        }
    }
}