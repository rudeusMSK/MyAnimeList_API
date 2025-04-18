using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProjectForDemoOnly.Services.MyAnimeList;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;

namespace ProjectForDemoOnly.Models.Services
{
    public static class MAL_Helper
    {
        // Get ID Anime by Url
        public static string GetAnimeID(string Url) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Url.Replace("https://myanimelist.net/anime/", ""));
            return sb.ToString().Split('/')[0];
        }

        // Clean Genres string:
        public static void CleanGenres(MAL_AnimeOfSeason animeOfSeasonal)
        {
            foreach (var tv in animeOfSeasonal.TV)
                tv.genres = MAL_Helper.CleanAndSetGenres(tv.genres[0]);

            foreach (var ova in animeOfSeasonal.OVAs)
                ova.genres = MAL_Helper.CleanAndSetGenres(ova.genres[0]);

            foreach (var ona in animeOfSeasonal.ONAs)
                ona.genres = MAL_Helper.CleanAndSetGenres(ona.genres[0]);

            foreach (var tvcon in animeOfSeasonal.TVCon)
                tvcon.genres = MAL_Helper.CleanAndSetGenres(tvcon.genres[0]);

            foreach (var movie in animeOfSeasonal.Movies)
                movie.genres = MAL_Helper.CleanAndSetGenres(movie.genres[0]);

            foreach (var tvnew in animeOfSeasonal.TVNew)
                tvnew.genres = MAL_Helper.CleanAndSetGenres(tvnew.genres[0]);
        }

        // Get ID Anime by link:
        public static string GetIDAnimeByUrl(string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(url.Replace("https://myanimelist.net/anime/", ""));
            return sb.ToString().Split('/')[0];
        }

        // Get current seasonal:
        public static string GetCurrentSeason()
        {
            int month = DateTime.Now.Month;

            if (month >= 3 && month <= 5) return Seasonal.spring.ToString();
            if (month >= 6 && month <= 8) return Seasonal.summer.ToString();
            if (month >= 9 && month <= 11) return Seasonal.fall.ToString();

            return Seasonal.winter.ToString();
        }

        // Format Genres string:
        public static List<string> CleanAndSetGenres(string rawGenres)
        {
            string cleanedGenres = Regex.Replace(rawGenres, @"\s+", " ").Trim();
            return cleanedGenres.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}