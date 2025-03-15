using Newtonsoft.Json;
using ProjectForDemoOnly.Models.Services;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
            apivalue = "5a4ff3e023msh26c80dfa95a2442p1d06d7jsnfcb35c840f94";
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