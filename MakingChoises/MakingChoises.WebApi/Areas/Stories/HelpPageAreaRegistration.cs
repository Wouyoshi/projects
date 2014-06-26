using System.Web.Http;
using System.Web.Mvc;

namespace MakingChoises.WebApi.Areas.Stories
{
    public class HelpPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Stories";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Stories_Default",
                "Story/{action}/{apiId}",
                new { controller = "Story", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}