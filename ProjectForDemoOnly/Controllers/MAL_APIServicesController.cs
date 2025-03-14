﻿using Newtonsoft.Json.Linq;
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

namespace ProjectForDemoOnly.Controllers
{
    public class MAL_APIServicesController : Controller
    {
        // service authentication:
        private static readonly AnimeService animeService = new AnimeService(new HttpClient());
        private ErrorViewModel errorView = new ErrorViewModel();


        // GET: Top Anime
        public async Task<ActionResult> Get_TopAnime()
        {
            try {
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

        public async Task<ActionResult> Get_AnimeReviewByAnime()
        {
            return default;
        }

        public async Task<ActionResult> Get_RecommendationsByAnime()
        {
            return default;
        }

        public async Task<ActionResult> Get_AnimeGenres()
        {
            return default;
        }

        public async Task<ActionResult> Get_Anime()
        {
            return default;
        }

        public async Task<ActionResult> Get_AnimeReviews()
        {
            return default;
        }

        public async Task<ActionResult> Get_SearchAnime()
        {

            return default;
        }

        // GET: Anime Of Seasonal: 
        public async Task<ActionResult> Get_SeasonalAnime(string season)
        {
            int year = 0; 
            try
            {
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