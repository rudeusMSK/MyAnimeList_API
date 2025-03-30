using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ProjectForDemoOnly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System.Web.WebPages;
using RestSharp;
using ProjectForDemoOnly.Services.MyAnimeList;
using ProjectForDemoOnly.Models.Services;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Services.Description;
using System.Web.Security;

namespace ProjectForDemoOnly.Controllers
{
    public class MAL_APIServicesController : Controller
    {
        // service authentication:
        private static readonly AnimeService animeService = new AnimeService(new HttpClient());
        private ErrorViewModel errorView = new ErrorViewModel();


        // GET: Top Anime
        public async Task<ActionResult> Get_TopAnime(string category)
        {
            // Page number param: p < Default: 1 >


            try
            {
                var topAnime = await animeService.GetTopAnimeAsync();
                return PartialView("Get_TopAnime", topAnime);

            } // Catch json: 
            catch (JsonException je) {

                // create error message:
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
                return PartialView("Error", errorView);

            } // Catch exception:
            catch (Exception  ex) {
                // create error message:
                errorView.title = "Exception: ";
                errorView.Message = ex.Message;
                return PartialView("Error", errorView);
            }
        }

        public async Task<ActionResult> Get_AnimeGenres(string[] genres)
        {
            // process genres request...

            List<MAL_Genres> genreBody = await animeService.GetGenresAsync();
            return View(genreBody);
        }

        public async Task<ActionResult> Get_AnimeInfo(int? id)
        {
            // check id...

            MAL_AnimeInfo AnimeInfo = await animeService.GetAnimeInfoAsync(id);
            return View(AnimeInfo);
        }

        public async Task<ActionResult> Get_AnimeReviewByAnime(
            int? id,
            int page,
            bool spoilers,
            string include_tags,
            bool preliminary,
            string sort )
        {
            // Process params:
            // ...

            List<MAL_AnimeReview> animeReviewByAni = await animeService.GetAnimeReviewAsync(id);
            return default;
        }

        public async Task<ActionResult> Get_RecommendationsByAnime(string seriesName, int? id)
        {
            return default;
        }

        public async Task<ActionResult> Get_SearchAnime(
            string SearchKey, 
            int? score,
            int?  genreID )
        {

            // Number of result param: n < Minimum: 1 Maximum: 50 Default: 1 >

            return default;
        }

        public async Task<ActionResult> Get_Recommendations(int? page)
        {
            page = 1; // test
            List<MAL_Recommendations> recommendations = await animeService.Get_RecommendationsAsync(page);

            return View(recommendations);
        }

        public async Task<ActionResult> Get_AnimeReviews(
            int id,
            int page,
            bool spoilers,
            string include_tags,
            bool preliminary,
            string include_filters)
        {
            // demo param:
            List<MAL_AnimeReview> animeReviews = await animeService.GetAnimeReviewAsync(id);

            return View(animeReviews);
        }

        // GET: Anime Of Seasonal: 
        public async Task<ActionResult> Get_SeasonalAnime(string season, int year)
        {
            // test param default
            year = 0; 
            try {
                var animeOfSeasonal = await animeService.GetSeasonalAnimeAsync(season, year);
                return PartialView("Get_AnimeOfSeason", animeOfSeasonal);

            }  // Catch json:
            catch (JsonException je) {
                // create error message:
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
                return PartialView("Error", errorView);

            } // Catch exception:
            catch (Exception ex) {// create error message
                errorView.title = "Exception: ";
                errorView.Message = ex.Message;
                return PartialView("Error", errorView);
            }
        }
    }
}