using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public class JsonServerConnector : MAL_ConnectorServerType
    {
        public string Connect()
        {
            throw new NotImplementedException();
        }

        public string Disconnect()
        {
            throw new NotImplementedException();
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

        public Task<List<MAL_TopAnime>> GetTopAnimeAsync(string Category)
        {
            throw new NotImplementedException();
        }

        public Task<List<MAL_Recommendations>> Get_RecommendationsAsync(int? page)
        {
            throw new NotImplementedException();
        }
    }
}