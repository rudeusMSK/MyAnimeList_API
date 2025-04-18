using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectForDemoOnly.Models.Services;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;


namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public class JsonServerConnector : IMALServices
    {
        private readonly string url;

        public JsonServerConnector() // params: domain name server.
        {
            // domain default:
            this.url = "http://localhost:";
        }
        // Anime Recomendation:
        public async Task<List<MAL_Recommendations>> Get_RecommendationsAsync(int? page)
        {
            // Config:
            string format = "{0}{1}Recommendations";

            // Send request:
            string endpoint = string.Format(format, this.url, (int)JsonServerPorts.ReviewByAni);
            return await SendRequestAsync<List<MAL_Recommendations>>(endpoint,new HttpClient());
        }
        // Review by Anime:
        public async Task<List<MAL_AnimeReview>> GetAnimeReviewAsync(int? id)
        {
            string format = "{0}{1}/AnimeReviewBySeri/";

            string endpoint = string.Format(format, this.url, (int)JsonServerPorts.ReviewByAni);
            // Send request url:
            var body = await SendRequestAsync<List<MAL_AnimeReview>>(endpoint, new HttpClient());
            // process body respon ...
            return body;
        }
        // Anime informations:
        public async Task<MAL_AnimeInfo> GetAnimeInfoAsync(int? id)
        {
            string format = "{0}{1}/AnimeInfo/";

            string endpoint = string.Format(format, this.url, (int)JsonServerPorts.AniInfo);
            // Send request url:
            var body = await SendRequestAsync<MAL_AnimeInfo>(endpoint, new HttpClient());
            // process body respon ...
            return body;
        }
        // Genres:
        public async Task<List<MAL_Genres>> GetGenresAsync(int? id)
        {
            string format = "{0}{1}/Genres/";
            string endpoint = string.Format(format, this.url, (int)JsonServerPorts.Genres);
            
            var body = await SendRequestAsync<List<MAL_Genres>>(endpoint, new HttpClient());
            // process body respon ...
            return body;
        }
        // Top Anime:
        public async Task<List<MAL_TopAnime>> GetTopAnimeAsync(string Category, int? page) // Refactor param {int? top}
        {
            // page default:
            // page = page?? 1;

            //string format = "{0}{1}top/{2}?p={3}";
            string format = "{0}{1}/TopAnime?_start={2}&_end={3}";

            // Config url: {0:Url} {1:port} {2:category} {3:page}
            // string endpoint = string.Format(format,this.url, JsonServerPorts.TopAni, Category, page);
            string endpoint = string.Format(format, this.url, (int)JsonServerPorts.TopAni,0, 10);
            // Send request url:
            var body = await SendRequestAsync<List<MAL_TopAnime>>(endpoint, new HttpClient());
            // process body respon ...
            return body;
        }
        // Anime Of Season:
        public async Task<MAL_AnimeOfSeason> GetSeasonalAnimeAsync(string season, int? year)
        {
            // TV show:
            List<TV> tv = await GetAnimeTVAsync(season, year);
            List<TVNew> tVNews = await GetAnimeTVNewAsync(season, year);
            List<TVCon> tVCons = await GetAnimeTVConAsync(season, year);
            List<OVA> oVAs = await GetAnimeOVasAsync(season, year);
            List<ONA> oNAs = await GetAnimeONasAsync(season, year);
            List<Special> specials = await GetAnimeSpecialsAsync(season, year);
            List<Movie> movies = await GetAnimeMoviesAsync(season, year);

            MAL_AnimeOfSeason animeOfSeason = new MAL_AnimeOfSeason()
            {
                TV = tv,
                TVNew = tVNews,
                TVCon = tVCons,
                ONAs = oNAs,
                OVAs = oVAs,
                Specials = specials,
                Movies = movies
            };

            // Format Genres:
            MAL_Helper.CleanGenres(animeOfSeason);
            return animeOfSeason;
        }

        /* ============================================================== 
         * Anime TV SHOW */

        public async Task<List<TV>> GetAnimeTVAsync(string season, int? year) // Refactor params {season, year, start, end}
        {
            string format = "{0}{1}/TV?_start={2}&_end={3}";
            string endpoint = string.Format(format, url, (int)JsonServerPorts.AniOfSeasnal, 1, 4);

            var body = await SendRequestAsync<List<TV>>(endpoint, new HttpClient());

            // process body respon ...

            return body;
        }

        public async Task<List<TVCon>> GetAnimeTVConAsync(string season, int? year)
        {

            string format = "{0}{1}/TVCon?_start={2}&_end={3}";
            string endpoint = string.Format(format, url, (int)JsonServerPorts.AniOfSeasnal, 1, 4);
            var tVCon = await SendRequestAsync<List<TVCon>>(endpoint, new HttpClient());

            return tVCon;
        }

        public async Task<List<TVNew>> GetAnimeTVNewAsync(string season, int? year)
        {
            string format = "{0}{1}/TVNew?_start={2}&_end={3}";
            string endpoint = string.Format(format, url, (int)JsonServerPorts.AniOfSeasnal, 1, 4);

            var tVNew = await SendRequestAsync<List<TVNew>>(endpoint, new HttpClient());
            return tVNew;
        }

        public async Task<List<ONA>> GetAnimeONasAsync(string season, int? year)
        {
            string format = "{0}{1}/ONAs?_start={2}&_end={3}";
            string endpoint = string.Format(format, url, (int)JsonServerPorts.AniOfSeasnal, 1, 4);

            var oNa = await SendRequestAsync<List<ONA>>(endpoint, new HttpClient());
            return oNa;
        }

        public async Task<List<OVA>> GetAnimeOVasAsync(string season, int? year)
        {
            string format = "{0}{1}/OVAs?_start={2}&_end={3}";
            string endpoint = string.Format(format, url, (int)JsonServerPorts.AniOfSeasnal, 1, 4);

            var oVa = await SendRequestAsync<List<OVA>>(endpoint, new HttpClient());
            return oVa;
        }

        public async Task<List<Movie>> GetAnimeMoviesAsync(string season, int? year)
        {
            string format = "{0}{1}/Movies?_start={2}&_end={3}";
            string endpoint = string.Format(format, url, (int)JsonServerPorts.AniOfSeasnal, 1, 4);
            var movie = await SendRequestAsync<List<Movie>>(endpoint, new HttpClient());
            return movie;
        }

        public async Task<List<Special>> GetAnimeSpecialsAsync(string season, int? year)
        {
            string format = "{0}{1}/Specials?_start={2}&_end={3}";
            string endpoint = string.Format(format, url, (int)JsonServerPorts.AniOfSeasnal, 1, 4);
            var special = await SendRequestAsync<List<Special>>(endpoint, new HttpClient());
            return special;
        }

        /* Anime TV SHOW *
         * ==============================================================  */

        // Process Send Request:
        private async Task<T> SendRequestAsync<T>(string endpoint, HttpClient httpClient)
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
        // Create Request:
        private HttpRequestMessage CreateHttpRequest(string endpoint)
        {
            return new HttpRequestMessage(HttpMethod.Get, new Uri(endpoint));
        }
    }
}