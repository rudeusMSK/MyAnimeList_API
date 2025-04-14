using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks; 
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using Newtonsoft.Json;
using System.Net.Http;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public class JsonServerConnector : IMALServices
    {
        private readonly string url;
        private HttpClient httpClient;

        public JsonServerConnector() // params: domain name server.
        {
            // domain default:
            this.url = "http://localhost:";
        }

        public async Task<List<MAL_TopAnime>> GetTopAnimeAsync(string Category, int? page)
        {
            // page default:
            page = page?? 1;

            string format = "{0}{1}top/{2}?p={3}";
            // Config url: {0:Url} {1:port} {2:category} {3:page}
            string endpoint = string.Format(format,this.url, JsonServerPorts.TopAni, Category, page);
            // Send request url:
            var topAni = await SendRequestAsync<List<MAL_TopAnime>>(endpoint);

            return topAni;

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
            return new HttpRequestMessage(HttpMethod.Get, new Uri(endpoint));
        }



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

        public Task<List<MAL_Recommendations>> Get_RecommendationsAsync(int? page)
        {
            throw new NotImplementedException();
        }
    }
}