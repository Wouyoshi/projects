using System;
using System.Web.Http;
using System.Web.Mvc;
using MakingChoises.WebApi.Areas.Stories.Models;
namespace MakingChoises.WebApi.Areas.Stories.Controllers
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using MakingChoises.ReadModel;

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

        public ActionResult Read(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return this.View("Read");
            }

            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50180/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    var task = client.GetAsync(string.Format("api/story/{0}", id));
                    task.Wait();
                    if (task.Result.IsSuccessStatusCode)
                    {
                        var story = task.Result.Content.ReadAsAsync<Story>();
                        story.Wait();
                        var result = story.Result;
                        var storyModel = new StoryModel()
                                             {
                                                 Name = result.Name, 
                                                 Text = result.FirstProblem.Text, 
                                                 Options = new Dictionary<int, string>(),
                                                 PreviousOptions = string.Empty
                                             };
                        foreach (var option in result.FirstProblem.Options)
                        {
                            storyModel.Options.Add(option.Number, option.Text);
                        }

                        return this.View(storyModel); 
                    }
                }

                return this.View("Read");
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }


        public ActionResult ReadNext(string id, string options)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(options))
            {
                return this.View("Read");
            }

            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50180/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    var task = client.GetAsync(string.Format("api/story/{0}", id));
                    task.Wait();
                    if (task.Result.IsSuccessStatusCode)
                    {
                        var story = task.Result.Content.ReadAsAsync<Story>();
                        story.Wait();
                        var storyResult = story.Result;
                        var storyModel = new StoryModel()
                        {
                            Name = storyResult.Name, 
                            Text = string.Empty,
                            Options = new Dictionary<int, string>(),
                            PreviousOptions = options
                        };
                        task = client.GetAsync(string.Format("api/story/{0}/{1}", id, options));
                        var problem = task.Result.Content.ReadAsAsync<Problem>();
                        problem.Wait();
                        var problemResult = problem.Result;
                        storyModel.Text = problemResult.Text;
                        foreach (var option in problemResult.Options)
                        {
                            storyModel.Options.Add(option.Number, option.Text);
                        }

                        return this.View(storyModel);
                    }
                }

                return this.View("Read");
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
    }
}