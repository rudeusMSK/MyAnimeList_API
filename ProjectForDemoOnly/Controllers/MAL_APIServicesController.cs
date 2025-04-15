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
            var topAni =  await services.GetTopAnimeAsync(category, 1);
            return PartialView("Get_TopAnime", topAni);


            //            // check Defined CategoryOptions enum.
            //            if (!Enum.IsDefined(typeof(CategoryOptions), category))
            //            {
            //                errorView.title = "Json parsing error";
            //                errorView.Message = "Don't category option !";
            //                return PartialView("Error", errorView);
            //            }

            //            //
            //            try
            //            {
            //                var topAnime = await animeService.GetTopAnimeAsync(category);

            //                return PartialView("Get_TopAnime", topAnime);

            //            } // Catch json: 
            //            catch (JsonException je) {

            //                // create error message:
            //                errorView.title = "Json parsing error";
            //                errorView.Message = je.Message;
            //                return PartialView("Error", errorView);

            //            } // Catch exception:
            //            catch (Exception  ex) {
            //                // create error message:
            //                errorView.title = "Exception: ";
            //                errorView.Message = ex.Message;
            //                return PartialView("Error", errorView);
            //            }
        }

        //public async Task<ActionResult> Get_AnimeGenres(string[] genres)
        //{
        //    // process genres request...

        //    List<MAL_Genres> genreBody = await animeService.GetGenresAsync();
        //    return View(genreBody);
        //}

        //public async Task<ActionResult> Get_AnimeInfo(int? id)
        //{
        //    // check id...

        //    MAL_AnimeInfo AnimeInfo = await animeService.GetAnimeInfoAsync(52991);
        //    return View(AnimeInfo);
        //}

        //public async Task<ActionResult> Get_AnimeReviewByAnime(
        //    int? id,
        //    string name,
        //    int page,
        //    bool spoilers,
        //    string include_tags,
        //    bool preliminary,
        //    string sort )
        //{
        //    // Process params:
        //    // ...

        //    List<MAL_AnimeReview> animeReviewByAni = await animeService.GetAnimeReviewAsync(id);
            
        //    return PartialView("Get_AnimeReviewByAnime", animeReviewByAni);
        //}

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

        //// GET: Anime Of Seasonal: 
        //public async Task<ActionResult> Get_SeasonalAnime(string season, int? year)
        //{
        //    // test param default
        //    year = 0;

        //    // TV, TV CON, TV NEW, OVAs, ONAs, Movies, Specials.

        //    try
        //    {
        //        var animeOfSeasonal = await animeService.GetSeasonalAnimeAsync(season, year);
        //        return PartialView("Get_AnimeOfSeason", animeOfSeasonal);

        //    }  // Catch json:
        //    catch (JsonException je) {
        //        // create error message:
        //        errorView.title = "Json parsing error";
        //        errorView.Message = je.Message;
        //        return PartialView("Error", errorView);

        //    } // Catch exception:
        //    catch (Exception ex) {// create error message
        //        errorView.title = "Exception: ";
        //        errorView.Message = ex.Message;
        //        return PartialView("Error", errorView);
        //    }
        //}
    
    }
}