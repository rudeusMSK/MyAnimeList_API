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

namespace ProjectForDemoOnly.Controllers
{
    public class MAL_APIServicesController : Controller
    {
        private readonly string nameServer = "https://myanimelist-api1.p.rapidapi.com/anime/";
        private readonly string key = "X-RapidAPI-Key";
        private readonly string value = "5a4ff3e023msh26c80dfa95a2442p1d06d7jsnfcb35c840f94";
        HttpClient client = new HttpClient();

        // GET: MAL_APIServices
        public async Task<ActionResult> Get_TopAnime()
        {
            // API Services:
            string get_TopAnime = "top/";
            string category = null; int page = 2;
            category = category == null ? 
                CategoryOptions.all.ToString() 
                : category;
            page = 1;
            // Get end point API:
            string endpoint = $"{nameServer}{get_TopAnime}{category}?p={page}";

            // Setup http request message:
            HttpRequestMessage request = new HttpRequestMessage {
                Method = HttpMethod.Get, // Method: GET
                RequestUri = new Uri(endpoint), // Request Url
                // header
                Headers = {
                  { key, value },
                },
            };

            // Send request:
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(body))
                {
                    var jsonString = body.Replace("\\", ""); // Loại bỏ dấu backslash
                    try
                    {
                        var TopAnime = JsonConvert.DeserializeObject<List<MAL_TopAnime>>(jsonString);
                        if (TopAnime == null)
                        {
                            // Xử lý trường hợp TopAnime là null
                            return PartialView("Get_TopAnime", null);
                        }
                        return PartialView("Get_TopAnime", TopAnime);
                    }
                    catch (JsonException jsonEx)
                    {
                        // Xử lý ngoại lệ JSON
                        // Ghi lại hoặc hiển thị lỗi
                        return PartialView("Get_TopAnime", null);
                    }
                }

                // Nếu body là null hoặc rỗng
                return PartialView("Get_TopAnime", null);
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


        public async Task<ActionResult> Get_SeasonalAnime(string season) {
            // API Services:
            string get_Seasonal = "seasonal";

            // Get Seasonal of anime:
            season = season.IsEmpty() ? 
                MAL_Helper.GetCurrentSeason()
                : season;

            // Get end point API:
            string endpoint = $"{nameServer}{get_Seasonal}?year={DateTime.Now.Year}&season={season}";

            // Setup http request message:
            HttpRequestMessage request = new HttpRequestMessage {
                Method = HttpMethod.Get, // Method: GET
                RequestUri = new Uri(endpoint), // Request Url
                // header
                Headers = {
                   { key, value },
                },
            };

            // Send request:
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                MAL_AnimeOfSeason AnimeOfSeasonal = JsonConvert.DeserializeObject<MAL_AnimeOfSeason>(body);

                foreach (var tv in AnimeOfSeasonal.TV)
                    tv.genres = MAL_Helper.CleanAndSetGenres(tv.genres[0]);

                foreach (var ova in AnimeOfSeasonal.OVAs)
                    ova.genres = MAL_Helper.CleanAndSetGenres(ova.genres[0]);

                foreach (var ona in AnimeOfSeasonal.ONAs)
                    ona.genres = MAL_Helper.CleanAndSetGenres(ona.genres[0]);

                foreach (var tvcon in AnimeOfSeasonal.TVCon)
                    tvcon.genres = MAL_Helper.CleanAndSetGenres(tvcon.genres[0]);

                foreach (var movie in AnimeOfSeasonal.Movies)
                    movie.genres = MAL_Helper.CleanAndSetGenres(movie.genres[0]);

                foreach (var tvnew in AnimeOfSeasonal.TVNew)
                    tvnew.genres = MAL_Helper.CleanAndSetGenres(tvnew.genres[0]);

                // Return partial view
                return PartialView("Get_AnimeOfSeason", AnimeOfSeasonal);
            }
        }

    }
}