using System;
using System.Web.Mvc;
using System.Net.Http;
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
        // service authentication:

        IMALServices services;


        private ErrorViewModel errorView = new ErrorViewModel();


        // Connect Type
        public ActionResult ChooseConnectType(ChooseConnector connectorType, string apiKey, string apiValue)
        {
            // demo account:
            connectorType = ChooseConnector.JsonServer;
            apiKey = "X-RapidAPI-Key";
            apiValue = "dcba14be99msh7fda78dd24a8705p1f40b4jsn2874bae46dc6";

            // choose connect type service
            services = AnimeService.CreateConnect(connectorType, apiKey, apiValue);
            return View();
        }

        // GET: Anime Of Seasonal: 
        public async Task<ActionResult> Get_SeasonalAnime(string season, int? year)
        {
            // process service instance not created
            services = AnimeService.CreateConnect(ChooseConnector.JsonServer,"","");
            var AniOfSeasonal = await services.GetSeasonalAnimeAsync(season, year);
            return PartialView("Get_AnimeOfSeason", AniOfSeasonal);
        }


        // GET: Top Anime
        public async Task<ActionResult> Get_TopAnime(string category)
        {
            // process service instance not created
            services = AnimeService.CreateConnect(ChooseConnector.JsonServer, "X-RapidAPI-Key", "dcba14be99msh7fda78dd24a8705p1f40b4jsn2874bae46dc6");

            try {
                var topAni =  await services.GetTopAnimeAsync(category, 1);
                return PartialView("Get_TopAnime", topAni);
            } 
            // Catch json: 
            catch (JsonException je) {

                // create error message:
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
                return PartialView("Error", errorView);

            } 
            // Catch exception:
            catch (Exception ex)  {
                // create error message:
                errorView.title = "Exception: ";
                errorView.Message = ex.Message;
                return PartialView("Error", errorView);
            }
        }


        public async Task<ActionResult> Get_AnimeGenres(string[] genreList)
        {
            // process genres request...
            services = AnimeService.CreateConnect(ChooseConnector.JsonServer, "", "");
            List<MAL_Genres> genres = await services.GetGenresAsync(null);
            return View(genres);
        }


        public async Task<ActionResult> Get_AnimeInfo(int? id)
        {
            // check id...
            services = AnimeService.CreateConnect(ChooseConnector.JsonServer, "", "");
            MAL_AnimeInfo body = await services.GetAnimeInfoAsync(id);
            return View(body);
        }

        public async Task<ActionResult> Get_AnimeReviewByAnime(
            int? id,
            string name,
            int page,
            bool spoilers,
            string include_tags,
            bool preliminary,
            string sort)
        {
            // Process params:
            // ...

            services = AnimeService.CreateConnect(ChooseConnector.JsonServer, "", "");
            List<MAL_AnimeReview> body = await services.GetAnimeReviewAsync(id);

            return PartialView("Get_AnimeReviewByAnime", body);
        }

        ////public async Task<ActionResult> Get_RecommendationsByAnime(string seriesName, int? id)
        ////{
        ////    return default;
        ////}

        ////public async Task<ActionResult> Get_SearchAnime(
        ////    string SearchKey, 
        ////    int? score,
        ////    int?  genreID )
        ////{

        ////    // Number of result param: n < Minimum: 1 Maximum: 50 Default: 1 >

        ////    return default;
        ////}

        //public async Task<ActionResult> Get_Recommendations(int? page)
        //{
        //    page = 1; // test
        //    List<MAL_Recommendations> recommendations = await animeService.Get_RecommendationsAsync(page);

        //    return View(recommendations);
        //}

        //public async Task<ActionResult> Get_AnimeReviews(
        //    int id,
        //    int page,
        //    bool spoilers,
        //    string include_tags,
        //    bool preliminary,
        //    string include_filters)
        //{
        //    // demo param:
        //    List<MAL_AnimeReview> animeReviews = await animeService.GetAnimeReviewAsync(id);

        //    return View(animeReviews);
        //}
    }
}