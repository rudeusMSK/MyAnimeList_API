using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System.Web.UI;
using ProjectForDemoOnly.Models.Services;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public class RapidapiConnector : IMALServices
    {
        // Config: authentic RapApi.MyAnimeListAPI
        private readonly HttpClient httpClient;
        private readonly string nameServer = "https://myanimelist-api1.p.rapidapi.com/anime/";
        private readonly string apiKey;
        private readonly string apivalue;

        public RapidapiConnector(HttpClient httpClient, string apiKey, string apivalue)
        {
            this.httpClient = httpClient;
            this.apiKey = apiKey;
            this.apivalue = apivalue;

            // Config endpint here:
            // stringbuilder endpoint: name Server + base endpoint + params
        }

        // API
        public async Task<List<MAL_TopAnime>> GetTopAnimeAsync(string Category, int? page)
        {

            // Config:
            const string endpointFormat = "{0}top/{1}?p={2}";
            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, Category, page);

            return await SendRequestAsync<List<MAL_TopAnime>>(endpoint, new HttpClient());
        }

        public async Task<MAL_AnimeInfo> GetAnimeInfoAsync(int? id)
        {
            // Config:
            const string endpointFormat = "{0}{1}";

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, id);
            return await SendRequestAsync<MAL_AnimeInfo>(endpoint, new HttpClient());
        }

        public async Task<List<MAL_AnimeReview>> GetAnimeReviewAsync(int? id)
        {
            // config:
            const string endpointFormat = "{0}reviews/{1}?p={2}&spoilers={3}&preliminary={4}&seriesName={5}&sort={6}";

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, id, 1, false, false, "Sousou no Frieren", "newest");

            return await SendRequestAsync<List<MAL_AnimeReview>>(endpoint, new HttpClient());
        }

        public async Task<List<MAL_Genres>> GetGenresAsync(int? id)
        {
            // Config:
            const string endpointFormat = "{0}genres";
            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer);
            return await SendRequestAsync<List<MAL_Genres>>(endpoint, new HttpClient());
        }

        public async Task<MAL_AnimeOfSeason> GetSeasonalAnimeAsync(string season, int? year)
        {
            //Config:
            season = string.IsNullOrEmpty(season) ? MAL_Helper.GetCurrentSeason() : season;
            year = year == 0 || year == null ? DateTime.Now.Year : year;

            //Send request:
            const string endpointFormat = "{0}seasonal?year={1}&season={2}";
            string endpoint = string.Format(endpointFormat, nameServer, year, season);
            var animeOfSeasonal = await SendRequestAsync<MAL_AnimeOfSeason>(endpoint, new HttpClient());

            // Format Genres:
            MAL_Helper.CleanGenres(animeOfSeasonal);

            return animeOfSeasonal;
        }

        public async Task<List<MAL_Recommendations>> Get_RecommendationsAsync(int? page)
        {
            // Config:
            const string endpointFormat = "{0}recommendations?p={1}";

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, page);
            return await SendRequestAsync<List<MAL_Recommendations>>(endpoint, new HttpClient());
        }

        // Process Send Request:
        private async Task<T> SendRequestAsync<T>(string endpoint,HttpClient httpClient)
        {
            // Send Request:
            var request = CreateHttpRequest(endpoint);
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Reponses:Json body
            var body = await response.Content.ReadAsStringAsync();

            // Prosecss body:
            if (string.IsNullOrWhiteSpace(body))
                return default; // process ...

            return JsonConvert.DeserializeObject<T>(body);
        }

        // Create Request
        private HttpRequestMessage CreateHttpRequest(string endpoint)
        {
            return new HttpRequestMessage(HttpMethod.Get, new Uri(endpoint))
            {
                Headers = { { apiKey, apivalue } }
            };
        }
    }
}