using Newtonsoft.Json;
using ProjectForDemoOnly.Models.Services;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using static System.Net.WebRequestMethods;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public class AnimeService
    {
        // Config: authentic RapApi.MyAnimeListAPI
        private readonly HttpClient httpClient;
        private readonly string nameServer;
        private readonly string apiKey;
        private readonly string apivalue;

        public AnimeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            nameServer = "https://myanimelist-api1.p.rapidapi.com/anime/";
            apiKey = "X-RapidAPI-Key";
            apivalue = "dcba14be99msh7fda78dd24a8705p1f40b4jsn2874bae46dc6";
        }

        // Get: Top Anime
        public async Task<List<MAL_TopAnime>> GetTopAnimeAsync(string Category)
        {
            // Config:
             const string endpointFormat = "{0}top/{1}?p={2}";
             //string category = CategoryOptions.all.ToString();
             int page = 1;

            // Send request:
            // string endpoint = string.Format(endpointFormat, nameServer, Category, page);
            
            // local config:
             string endpoint = "http://localhost:3000/TopAnime?_start=0&_end=10";
            return await SendRequestAsync<List<MAL_TopAnime>>(endpoint);
        }

        // Get: Top Anime
        public async Task<MAL_AnimeInfo> GetAnimeInfoAsync(int? id)
        {
            // Config:
            const string endpointFormat = "{0}{1}";

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, id);
            return await SendRequestAsync<MAL_AnimeInfo>(endpoint);
        }

        // Refactor.
        // Get: Seasonal Anime
        public async Task<MAL_AnimeOfSeason> GetSeasonalAnimeAsync(string season, int? year)
        {
            // Config:
            //season = string.IsNullOrEmpty(season) ? MAL_Helper.GetCurrentSeason() : season;
            //year = year == 0 ? DateTime.Now.Year : year;

            // Send request:
            //const string endpointFormat = "{0}seasonal?year={1}&season={2}";
            //string endpoint = string.Format(endpointFormat, nameServer, year, season);

            // local config: Defaul 2024 WINTER Seasonal
            string endpoint = "http://localhost:3000/AnimeOfSeason";
            // var animeOfSeasonal = await SendRequestAsync<MAL_AnimeOfSeason>(endpoint);

            List<TV> tv = await GetAnimeTVAsync(season, year);

            MAL_AnimeOfSeason animeOfSeason = new MAL_AnimeOfSeason()
            {

                TV = tv

            };



            // Format Genres:
            // MAL_Helper.CleanGenres(animeOfSeasonal);
            return animeOfSeason;
        }

        public async Task<List<TV>> GetAnimeTVAsync(string season, int? year)
        {

            // local config: Defaul 2024 WINTER Seasonal
            string endpoint = "http://localhost:3000/TV?_start=1&_end=4";
            var tV = await SendRequestAsync<List<TV>>(endpoint);

            return tV;
        }

        public async Task<TVCon> GetAnimeTVConAsync(string season, int? year)
        {

            // local config: Defaul 2024 WINTER Seasonal
            string endpoint = "http://localhost:3000/TVCon?_start=1&_end=3";
            var tVCon = await SendRequestAsync<TVCon>(endpoint);

            return tVCon;
        }



        // Get: Recommendations
        public async Task<List<MAL_Recommendations>> Get_RecommendationsAsync(int? page)
        {
            // Config:
            const string endpointFormat = "{0}recommendations?p={1}";

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, page);
            return await SendRequestAsync<List<MAL_Recommendations>>(endpoint);
        }

        // Get: Genres Anime
        public async Task<List<MAL_Genres>> GetGenresAsync()
        {
            // local config:
            string enpoint = "http://localhost:3000/Genres";
            return await SendRequestAsync<List<MAL_Genres>>(enpoint);
        }

        // Get: Review Anime
        public async Task<List<MAL_AnimeReview>> GetAnimeReviewAsync(int? id)
        {
            // config:
            const string endpointFormat = "{0}reviews/{1}?p={2}&spoilers={3}&preliminary={4}&seriesName={5}&sort={6}";

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, id, 1, false, false, "Sousou no Frieren", "newest");
            return await SendRequestAsync<List<MAL_AnimeReview>>(endpoint);
        }


        // Process Send Request:
        private async Task<T> SendRequestAsync<T>(string endpoint)
        {
            // Send Request:
            var request = CreateHttpRequest(endpoint);
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Reponses:Json body
            var body = await response.Content.ReadAsStringAsync();
            
            // Prosecss body:
            if (string.IsNullOrWhiteSpace(body))
                return default;

            return JsonConvert.DeserializeObject<T>(body);
        }

        // Create Request
        private HttpRequestMessage CreateHttpRequest(string endpoint)
        {
            return new HttpRequestMessage(HttpMethod.Get, new Uri(endpoint))
            {
                Headers = { { apiKey, apivalue} }
            };
        }
    }
}