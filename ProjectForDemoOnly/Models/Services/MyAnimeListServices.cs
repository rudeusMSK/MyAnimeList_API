using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    public static class MAL_Helper
    {
        // Get current seasonal:
        public static string GetCurrentSeason()
        {
            int month = DateTime.Now.Month;

            if (month >= 3 && month <= 5) return Seasonal.spring.ToString();
            if (month >= 6 && month <= 8) return Seasonal.summer.ToString();
            if (month >= 9 && month <= 11) return Seasonal.fall.ToString();

            return Seasonal.winter.ToString();
        }

        public static List<string> CleanAndSetGenres(string rawGenres)
        {
            string cleanedGenres = Regex.Replace(rawGenres, @"\s+", " ").Trim();
            return cleanedGenres.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
    
    public enum CategoryOptions
    {
        all,
        airing,
        upcoming,
        tv,
        movie,
        ova,
        ona,
        special,
        bypopularity,
        favorite, 
    }

    public enum Seasonal
    {
        winter,
        spring,
        summer,
        fall,
    }

    public class MAL_TopAnime
    {
        public string title { get; set; }
        public string picture_url { get; set; }
        public string myanimelist_url { get; set; }
        public int? myanimelist_id { get; set; }
        public int? rank { get; set; }
        public double score { get; set; }
        public string type { get; set; }
        public string aired_on { get; set; }
        public int? members { get; set; }
    }

    public class MAL_AnimeOfSeason
    {
        public List<TV> TV { get; set; }
        public List<TVNew> TVNew { get; set; }
        public List<TVCon> TVCon { get; set; }
        public List<OVA> OVAs { get; set; }
        public List<ONA> ONAs { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Special> Specials { get; set; }
    }

    public class Movie
    {
        public string picture { get; set; }
        public string synopsis { get; set; }
        public string licensor { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public List<string> genres { get; set; }
        public List<string> producers { get; set; }
        public string fromType { get; set; }
        public string nbEp { get; set; }
        public string releaseDate { get; set; }
        public string score { get; set; }
        public string members { get; set; }
    }

    public class ONA
    {
        public string picture { get; set; }
        public string synopsis { get; set; }
        public string licensor { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public List<string> genres { get; set; }
        public List<string> producers { get; set; }
        public string fromType { get; set; }
        public string nbEp { get; set; }
        public string releaseDate { get; set; }
        public string score { get; set; }
        public string members { get; set; }
    }

    public class OVA
    {
        public string picture { get; set; }
        public string synopsis { get; set; }
        public string licensor { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public List<string> genres { get; set; }
        public List<string> producers { get; set; }
        public string fromType { get; set; }
        public string nbEp { get; set; }
        public string releaseDate { get; set; }
        public string score { get; set; }
        public string members { get; set; }
    }

    public class Special
    {
        public string picture { get; set; }
        public string synopsis { get; set; }
        public string licensor { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public List<string> genres { get; set; }
        public List<string> producers { get; set; }
        public string fromType { get; set; }
        public string nbEp { get; set; }
        public string releaseDate { get; set; }
        public string score { get; set; }
        public string members { get; set; }
    }

    public class TV
    {
        public string picture { get; set; }
        public string synopsis { get; set; }
        public string licensor { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public List<string> genres { get; set; }
        public List<string> producers { get; set; }
        public string fromType { get; set; }
        public string nbEp { get; set; }
        public string releaseDate { get; set; }
        public string score { get; set; }
        public string members { get; set; }
    }

    public class TVCon
    {
        public string picture { get; set; }
        public string synopsis { get; set; }
        public string licensor { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public List<string> genres { get; set; }
        public List<string> producers { get; set; }
        public string fromType { get; set; }
        public string nbEp { get; set; }
        public string releaseDate { get; set; }
        public string score { get; set; }
        public string members { get; set; }
    }

    public class TVNew
    {
        public string picture { get; set; }
        public string synopsis { get; set; }
        public string licensor { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public List<string> genres { get; set; }
        public List<string> producers { get; set; }
        public string fromType { get; set; }
        public string nbEp { get; set; }
        public string releaseDate { get; set; }
        public string score { get; set; }
        public string members { get; set; }
    }
}