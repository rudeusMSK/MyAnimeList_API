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

namespace ProjectForDemoOnly.Controllers
{
    public class MAL_APIServicesController : Controller
    {
        private readonly string nameServer = "https://myanimelist.p.rapidapi.com/v2/anime/";
        private readonly string key = "X-RapidAPI-Key";
        private readonly string value = "dcba14be99msh7fda78dd24a8705p1f40b4jsn2874bae46dc6";
        HttpClient client = new HttpClient();

        // GET: MAL_APIServices
        public async Task<ActionResult> Get_Recommendations()
        {
            string get_Recommendations = "recommendations";
            int defaul_Params = 1;
            string endpoint = $"{nameServer}{get_Recommendations}?p={defaul_Params}";

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
                var recommendations = JsonConvert.DeserializeObject<MAL_Recommendations>(body);

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

        public async Task<ActionResult> Get_SeasonalAnime()
        {
            return default;
        }

    }
}