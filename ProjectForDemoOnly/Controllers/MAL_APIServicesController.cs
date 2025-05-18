using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ProjectForDemoOnly.Models;
using System.Collections.Generic;
using ProjectForDemoOnly.Services.MyAnimeList;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;


namespace ProjectForDemoOnly.Controllers
{
    public class MAL_APIServicesController : Controller
    {
        // ======================================================
        // Demo account:
        //  apiKey = "X-RapidAPI-Key";
        //  apiValue = "dcba14be99msh7fda78dd24a8705p1f40b4jsn2874bae46dc6";
        // ======================================================

        // Declare Services:
        IMALServices services;

        // Create ErrorView:
        private ErrorViewModel errorView = new ErrorViewModel()
        {
            title = "Not connected to Service.",
            Message = "> Go to Service selection.",
        };

        // Disconnect Service:
        public ActionResult Disconnect()
        {
            // Delete Services:
            AnimeService.DeleteCookies(Response);
            return View("ChooseConnectType");
        }

        // Choose Services:
        public ActionResult ChooseConnectType(ChooseConnector? connectorType, string apiKey, string apiValue)
        {
            // Processing value:
            if (connectorType.HasValue
                && !string.IsNullOrEmpty(apiKey)
                && !string.IsNullOrEmpty(apiValue))

                // Save:
                AnimeService.SaveConnectionCookies(
                    Response,
                    connectorType.Value,
                    apiKey,
                    apiValue
                );

            // Init Notification:
            ViewBag.Message = AnimeService.State;
            return View();
        }

        // GET: Anime Of Seasonal:
        [HttpGet]
        public async Task<ActionResult> Get_SeasonalAnime(string season, int? year)
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            var AniOfSeasonal = await services.GetSeasonalAnimeAsync(season, year);
            return PartialView("Get_AnimeOfSeason", AniOfSeasonal);
        }

        // GET: Top Anime
        [HttpGet]
        public async Task<ActionResult> Get_TopAnime(string category)
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            var topAni = await services.GetTopAnimeAsync(category, 1);
            return PartialView("Get_TopAnime", topAni);
        }

        [HttpGet]
        public async Task<ActionResult> Get_AnimeGenres(string[] genreList)
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            List<MAL_Genres> genres = await services.GetGenresAsync(null);
            return View(genres);
        }

        [HttpGet]
        public async Task<ActionResult> Get_AnimeInfo(int? id)
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Get Service:
            MAL_AnimeInfo body = await services.GetAnimeInfoAsync(id);
            // check id...
            return View(body);
        }

        [HttpGet]
        public async Task<ActionResult> Get_AnimeReviewByAnime(
            int? id,
            string name,
            int page,
            bool spoilers,
            string include_tags,
            bool preliminary,
            string sort)
        {

            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            // Process params:
            // ...

            // Get Service:
            List<MAL_AnimeReview> body = await services.GetAnimeReviewAsync(id);
            return PartialView("Get_AnimeReviewByAnime", body);
        }

        [HttpGet]
        public async Task<ActionResult> Get_Recommendations(int? page)
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            // service processing:
            if (services == null) return PartialView("Error", errorView);

            page = 1; // test

            // Get Service:
            List<MAL_Recommendations> body = await services.Get_RecommendationsAsync(page);
            return View(body);
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

            // Return PartialView if AJAX or get from child view
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new PartialViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(errorView)
                };
            }
            else filterContext.Result = View("Error", errorView);
        }
    }
}