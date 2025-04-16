using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;

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


        // SERVER
        public void Connect()
        {
            // Enpoint:

            // Sent request:
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }


        // API
        public async Task<List<MAL_TopAnime>> GetTopAnimeAsync(string Category, int? page)
        {
            // Config:
            const string endpointFormat = "{0}top/{1}?p={2}";

            page = 1;

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, Category, page);

            return await SendRequestAsync<List<MAL_TopAnime>>(endpoint);
        }

        public Task<MAL_AnimeInfo> GetAnimeInfoAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MAL_AnimeReview>> GetAnimeReviewAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MAL_Genres>> GetGenresAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<MAL_AnimeOfSeason> GetSeasonalAnimeAsync(string season, int? year)
        {
            // Config:
            //season = string.IsNullOrEmpty(season) ? MAL_Helper.GetCurrentSeason() : season;
            //year = year == 0 ? DateTime.Now.Year : year;

            // Send request:
            //const string endpointFormat = "{0}seasonal?year={1}&season={2}";
            //string endpoint = string.Format(endpointFormat, nameServer, year, season);

            // local config: Defaul 2024 WINTER Seasonal
            //string endpoint = "http://localhost:3000/AnimeOfSeason";
            // var animeOfSeasonal = await SendRequestAsync<MAL_AnimeOfSeason>(endpoint);

            // string format = "{0}{1}/TopAnime/";
            // Config url: {0:Url} {1:port} {2:category} {3:page}
            // string endpoint = string.Format(format,this.url, JsonServerPorts.TopAni, Category, page);
            // string endpoint = string.Format(format, this.url, (int)JsonServerPorts.AniOfSeasnal);
            throw new NotImplementedException();
        }

        public Task<List<MAL_Recommendations>> Get_RecommendationsAsync(int? page)
        {
            throw new NotImplementedException();
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