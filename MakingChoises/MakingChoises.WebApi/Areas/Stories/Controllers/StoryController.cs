using System;
using System.Web.Http;
using System.Web.Mvc;
using MakingChoises.WebApi.Areas.Stories.Models;

namespace MakingChoises.WebApi.Areas.Stories.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class StoryController : Controller
    {
        public StoryController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public StoryController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View("Error");
        }

        public ActionResult Read(string storyName)
        {
            if (string.IsNullOrWhiteSpace(storyName))
            {
                return View("Error");
            }

            return View("Error");
        }
    }
}