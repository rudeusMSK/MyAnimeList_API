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

namespace ProjectForDemoOnly.Controllers
{
    public class MAL_APIServicesController : Controller
    {
        private readonly string nameServer = "https://myanimelist-api1.p.rapidapi.com/anime/";
        private readonly string key = "X-RapidAPI-Key";
        private readonly string value = "5a4ff3e023msh26c80dfa95a2442p1d06d7jsnfcb35c840f94";
        HttpClient client = new HttpClient();

        // GET: MAL_APIServices
        public async Task<ActionResult> Get_Recommendations(int page = 1)
        {
            string get_Recommendations = "recommendations";
            string endpoint = $"{nameServer}{get_Recommendations}?p={page}";

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(endpoint),
                Headers = {
                    { key, value },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var recommendations = JsonConvert.DeserializeObject<dynamic>(body);

                return PartialView("Get_Recommendations", recommendations);
            }
        }

        public async Task<ActionResult> Get_TopAnime()
        {
            return default;
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

        public async Task<ActionResult> Get_SeasonalAnime(string season)
        {
            // API Services:
            string get_Seasonal = "seasonal";

            // Get Seasonal of anime:
            season = season.IsEmpty() ? 
                GetCurrentSeason()
                : season;

            // Get end point API:
            string endpoint = $"{nameServer}{get_Seasonal}?year={DateTime.Now.Year}&season={season}";
            //$"{nameServer}{get_Seasonal}?year={DateTime.Now.Year}&season={season}";

            // Setup http request message:
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get, // Method: GET
                RequestUri = new Uri(endpoint), // Request Url
                // header
                Headers = {
                   { "x-rapidapi-key", "5a4ff3e023msh26c80dfa95a2442p1d06d7jsnfcb35c840f94" },
                   { "x-rapidapi-host", "myanimelist-api1.p.rapidapi.com" },
                },
            };

            // Send request:
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                MAL_AnimeOfSeason AnimeOfSeasonal = JsonConvert.DeserializeObject<MAL_AnimeOfSeason>(body);

                // Return partial view
                return PartialView("Get_AnimeOfSeason", AnimeOfSeasonal);
            }
        }

        // Get current seasonal:
        static string GetCurrentSeason()
        {
            int month = DateTime.Now.Month;

            if (month >= 3 && month <= 5) return Seasonal.spring.ToString();
            if (month >= 6 && month <= 8) return Seasonal.summer.ToString();
            if (month >= 9 && month <= 11) return Seasonal.fall.ToString();

            return Seasonal.winter.ToString();
        }

    }
}