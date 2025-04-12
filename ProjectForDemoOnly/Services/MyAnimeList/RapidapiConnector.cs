using Newtonsoft.Json;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public class RapidapiConnector : MAL_ConnectorServerType
    {
        // Config: authentic RapApi.MyAnimeListAPI
        private readonly HttpClient httpClient;
        private readonly string nameServer;
        private readonly string apiKey;
        private readonly string apivalue;

        public RapidapiConnector(HttpClient httpClient, string nameServer, string apiKey, string apivalue)
        {
            this.httpClient = httpClient;
            this.nameServer = nameServer; // https://myanimelist-api1.p.rapidapi.com/anime/
            this.apiKey = apiKey;// "X-RapidAPI-Key"
            this.apivalue = apivalue;// "dcba14be99msh7fda78dd24a8705p1f40b4jsn2874bae46dc6"

            // Config endpint here:
            // stringbuilder endpoint: name Server + base endpoint + params
        }


        // SERVER
        public string Connect()
        {
            throw new NotImplementedException();
        }

        public string Disconnect()
        {
            throw new NotImplementedException();
        }


        // API
        public Task<MAL_AnimeInfo> GetAnimeInfoAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MAL_AnimeReview>> GetAnimeReviewAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MAL_Genres>> GetGenresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MAL_AnimeOfSeason> GetSeasonalAnimeAsync(string season, int? year)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MAL_TopAnime>> GetTopAnimeAsync(string Category) // Refactor param:  Category, page.
        {
            // Config:
            const string endpointFormat = "{0}top/{1}?p={2}";
            
            //string category = CategoryOptions.all.ToString();
            int page = 1;

            // Send request:
            string endpoint = string.Format(endpointFormat, nameServer, Category, page);

            return await SendRequestAsync<List<MAL_TopAnime>>(endpoint);
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