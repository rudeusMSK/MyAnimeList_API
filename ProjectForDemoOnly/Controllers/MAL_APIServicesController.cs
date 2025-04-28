using System;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ProjectForDemoOnly.Models;
using System.Collections.Generic;
using ProjectForDemoOnly.Services.MyAnimeList;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System.Web;
using Microsoft.Ajax.Utilities;


namespace ProjectForDemoOnly.Controllers
{
    public class MAL_APIServicesController : Controller
    {
        // ======================================================
        // Demo account:
        //apiKey = "X-RapidAPI-Key";
        //apiValue = "dcba14be99msh7fda78dd24a8705p1f40b4jsn2874bae46dc6";
        // ======================================================

        // services:
        IMALServices services;
        private ErrorViewModel errorView = new ErrorViewModel();

        // Disconnect Service:
        public ActionResult Disconnect()
        {
            AnimeService.DeleteCookies(Response);
            return View("ChooseConnectType");
        }

        // Choose Services:
        public ActionResult ChooseConnectType(ChooseConnector? connectorType, string apiKey, string apiValue)
        {
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

            ViewBag.Message = AnimeService.State;
            return View();
        }

        // GET: Anime Of Seasonal:
        public async Task<ActionResult> Get_SeasonalAnime(string season, int? year)
        {
            // Init Service:
            services = AnimeService.InitService(Request);
            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }

            try
            {
                // Get Service:
                var AniOfSeasonal = await services.GetSeasonalAnimeAsync(season, year);
            return PartialView("Get_AnimeOfSeason", AniOfSeasonal);
            }
            // Catch json: 
            catch (JsonException je)
            {

                // create error message:
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
                return PartialView("Error", errorView);
            }
            // Catch exception:
            catch (Exception ex)
            {
                // create error message:
                errorView.title = "Exception: ";
                errorView.Message = ex.Message;
                return PartialView("Error", errorView);
            }
        }

        // GET: Top Anime
        public async Task<ActionResult> Get_TopAnime(string category)
        {
            // Init Service:
            services = AnimeService.InitService(Request);

            if (services == null)  {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }
            // Get Service:
            try
            {
                var topAni = await services.GetTopAnimeAsync(category, 1);
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
            services = AnimeService.InitService(Request);
            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }

            try
            {
                // process genres request...
                List<MAL_Genres> genres = await services.GetGenresAsync(null);
            return View(genres);
            }
            // Catch json: 
            catch (JsonException je)
            {

                // create error message:
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
                return PartialView("Error", errorView);
            }
            // Catch exception:
            catch (Exception ex)
            {
                // create error message:
                errorView.title = "Exception: ";
                errorView.Message = ex.Message;
                return PartialView("Error", errorView);
            }
        }

        public async Task<ActionResult> Get_AnimeInfo(int? id)
        {
            services = AnimeService.InitService(Request);
            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }

            // check id...
            try
            {
                MAL_AnimeInfo body = await services.GetAnimeInfoAsync(id);
            return View(body);
            }
            // Catch json: 
            catch (JsonException je)
            {

                // create error message:
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
                return PartialView("Error", errorView);

            }
            // Catch exception:
            catch (Exception ex)
            {
                // create error message:
                errorView.title = "Exception: ";
                errorView.Message = ex.Message;
                return PartialView("Error", errorView);
            }
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

            // Init Service:
            services = AnimeService.InitService(Request);
            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }

            // Process params:
            // ...
            try
            {
                List <MAL_AnimeReview> body = await services.GetAnimeReviewAsync(id);
                return PartialView("Get_AnimeReviewByAnime", body);
            }
            // Catch json: 
            catch (JsonException je)
            {

                // create error message:
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
                return PartialView("Error", errorView);

            }
            // Catch exception:
            catch (Exception ex)
            {
                // create error message:
                errorView.title = "Exception: ";
                errorView.Message = ex.Message;
                return PartialView("Error", errorView);
            }
        }

        public async Task<ActionResult> Get_Recommendations(int? page)
        {
            // Init Service:
            services = AnimeService.InitService(Request);
            if (services == null)
            {
                errorView.title = "Chua ket noi service";
                errorView.Message = "chon kieu ket noi";
                return PartialView("Error", errorView);
            }

            page = 1; // test
            try
            {
                List<MAL_Recommendations> body = await services.Get_RecommendationsAsync(page);

            return View(body);
            }
            // Catch json: 
            catch (JsonException je)
            {

                // create error message:
                errorView.title = "Json parsing error";
                errorView.Message = je.Message;
                return PartialView("Error", errorView);

            }
            // Catch exception:
            catch (Exception ex)
            {
                // create error message:
                errorView.title = "Exception: ";
                errorView.Message = ex.Message;
                return PartialView("Error", errorView);
            }
        }
    }
}