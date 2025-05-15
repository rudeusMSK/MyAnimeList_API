using RestSharp;
using ProjectForDemoOnly.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using ProjectForDemoOnly.Services.MyAnimeList;
using System.Web.Services.Description;

namespace ProjectForDemoOnly.Controllers
{
    public class HomeController : Controller
    {

        private ErrorViewModel errorView = new ErrorViewModel();
        IMALServices services;

        public ActionResult index()
        {
            return View();
        }

        public async Task<ActionResult> Top()
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }
            // Get Service:
                var topAni = await services.GetTopAnimeAsync("all", 1);
                return View(topAni);
        }

        public async Task<ActionResult> Recommendations()
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }
            // Get Service:
            var body = await services.Get_RecommendationsAsync(1);
            return View(body);
        }

        public async Task<ActionResult> Seasonal()
        {
            // Init Service:
            services = AnimeService.InitService(Request);
            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }
                // Get Service:
                var AniOfSeasonal = await services.GetSeasonalAnimeAsync(null, 2025);
                return View(AniOfSeasonal);
        }

        public ActionResult Review()
        {
            return View();
        }

        public async Task<ActionResult> AnimeDetail()
        {
            IMALServices services = AnimeService.InitService(Request);
            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }
            // check id...
                MAL_AnimeInfo body = await services.GetAnimeInfoAsync(3352);
                return View(body);
        }

        public ActionResult Genres()
        {
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var ex = filterContext.Exception;

            if (ex is JsonException je)
            {
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
            }
            else
            {
                errorView.title = "Exception:";
                errorView.Message = ex.Message;
            }

            // Trả về PartialView nếu là AJAX hoặc lấy từ view con
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new PartialViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(errorView)
                };
            }
            else
            {
                filterContext.Result = View("Error", errorView);
            }
        }
    }
}