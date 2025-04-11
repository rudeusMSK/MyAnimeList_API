using System;
using System.Web;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using System.Threading.Tasks;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public interface MAL_ConnectorServerType
    {
        // Server Config:
        string Connect();
        string Disconnect();

        // API Services
        Task<List<MAL_AnimeReview>> GetAnimeReviewAsync(int? id);
        Task<List<MAL_Genres>> GetGenresAsync(); // params: int? id
        Task<List<MAL_Recommendations>> Get_RecommendationsAsync(int? page);
        Task<MAL_AnimeOfSeason> GetSeasonalAnimeAsync(string season, int? year);
        Task<MAL_AnimeInfo> GetAnimeInfoAsync(int? id);
        Task<List<MAL_TopAnime>> GetTopAnimeAsync(string Category);
    }
}