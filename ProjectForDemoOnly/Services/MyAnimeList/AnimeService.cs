using Newtonsoft.Json;
using ProjectForDemoOnly.Models.Services;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<List<MAL_TopAnime>> GetTopAnimeAsync()
        {
            // Config:
            const string endpointFormat = "{0}top/{1}?p={2}";
            string category = CategoryOptions.all.ToString();
            int page = 1;

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, category, page);
            return await SendRequestAsync<List<MAL_TopAnime>>(endpoint);
        }

        // Get: Top Anime
        public async Task<MAL_AnimeInfo> GetAnimeInfoAsync(string id)
        {
            // Config:
            const string endpointFormat = "{0}{1}";

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, id);
            return await SendRequestAsync<MAL_AnimeInfo>(endpoint);
        }

        // Get: Seasonal Anime
        public async Task<MAL_AnimeOfSeason> GetSeasonalAnimeAsync(string season, int year)
        {
            // Config:
            season = string.IsNullOrEmpty(season) ? MAL_Helper.GetCurrentSeason() : season;
            year = year == 0 ? DateTime.Now.Year : year;

            // Send request:
            const string endpointFormat = "{0}seasonal?year={1}&season={2}";
            string endpoint = string.Format(endpointFormat, nameServer, year, season);
            var animeOfSeasonal = await SendRequestAsync<MAL_AnimeOfSeason>(endpoint);

            // Format Genres:
            MAL_Helper.CleanGenres(animeOfSeasonal);
            return animeOfSeasonal;
        }

        // Get: Genres Anime
        public async Task<List<MAL_Genres>> GetGenresAsync()
        {
            string enpoint = "http://localhost:3000/Genres";
            return await SendRequestAsync<List<MAL_Genres>>(enpoint);
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