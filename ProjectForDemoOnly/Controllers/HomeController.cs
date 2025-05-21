using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ProjectForDemoOnly.Models;
using ProjectForDemoOnly.Services.MyAnimeList;
using System.Drawing.Printing;
using System.Web.UI;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System.Collections.Generic;
using Microsoft.Ajax.Utilities;
using System.Linq;

namespace ProjectForDemoOnly.Controllers
{
    public class HomeController : Controller
    {
        // Create ErrorView:
        private ErrorViewModel errorView = new ErrorViewModel() {
            title = "Not connected to Service.",
            Message = "> Go to Service selection.",
        };

        // Declare Services
        IMALServices services;

        public ActionResult index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Top(int? page)
        {

            page = page == null? 1: page;

            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            var topAni = await services.GetTopAnimeAsync("all", page);

            if (!topAni.Any()) return RedirectToAction("Top");

            ViewBag.PageNumber = page;
            ViewBag.PageSize = 10;

            return View(topAni);
        }

        [HttpGet]
        public async Task<ActionResult> Recommendations()
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            var body = await services.Get_RecommendationsAsync(1);
            return View(body);
        }

        [HttpGet]
        public async Task<ActionResult> Seasonal()
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            var AniOfSeasonal = await services.GetSeasonalAnimeAsync(null, 2025);
                return View(AniOfSeasonal);
        }

        [HttpGet]
        public async Task<ActionResult> Review()
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // check id...

            // Get Service:
            var body = await services.GetAnimeReviewAsync(1);
            return View(body);
        }

        [HttpGet]
        public async Task<ActionResult> AnimeDetail()
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            var body = await services.GetAnimeInfoAsync(3352);    
            return View(body);
        }

        [HttpGet]
        public async Task<ActionResult> Genres()
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            var body = await services.GetGenresAsync(null);
            return View(body);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var ex = filterContext.Exception;

            if (ex is JsonException je) {
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
            } else {
                errorView.title = "Exception:";
                errorView.Message = ex.Message;
            }

            // Return PartialView if AJAX or get from child view
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new PartialViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(errorView)
                };
            } else filterContext.Result = View("Error", errorView);
        }
    }
}