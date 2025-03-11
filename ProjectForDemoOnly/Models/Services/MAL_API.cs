using Newtonsoft.Json;
using ProjectForDemoOnly.Models.Services.MyAnimeListModel;
using Object = ProjectForDemoOnly.Models.Services.MyAnimeListModel.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ProjectForDemoOnly.Models
{
        public class MAL_GetAnimeReviewsByAnime
        {
            public List<Review> reviews { get; set; }
            public int amount_reviews { get; set; }

        }

        public class MAL_GetTopAnime
        {
            public string title { get; set; }
            public string picture_url { get; set; }
            public string myanimelist_url { get; set; }
            public int myanimelist_id { get; set; }
            public int rank { get; set; }
            public double score { get; set; }
            public string type { get; set; }
            public string aired_on { get; set; }
            public int? members { get; set; }
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

    public class MAL_GetSeasonalAnime
    {
        public List<TV> TV { get; set; }
        public List<TVNew> TVNew { get; set; }
        public List<TVCon> TVCon { get; set; }
        public List<OVA> OVAs { get; set; }
        public List<ONA> ONAs { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Special> Specials { get; set; }
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



        public class MAL_GetSearchAnime
        {
            public string title { get; set; }
            public string description { get; set; }
            public string picture_url { get; set; }
            public string myanimelist_url { get; set; }
            public int myanimelist_id { get; set; }
        }

        public class MAL_GetRecommendationsByAnime
        {
            public List<Recommendation> recommendations { get; set; }
            public int amount_recommendations { get; set; }
        }

        public class MAL_Recommendations
        {
            public List<Recommendation> recommendations { get; set; }
            public int amount_recommendations { get; set; }
        }


        public class MAL_GetAnimeReviews
        {
            public Object @object { get; set; }
            public User user { get; set; }
            public List<string> tags { get; set; }
            public Text text { get; set; }
            public Date date { get; set; }
        }


        public class MAL_GetAnime
        {
            public string title_ov { get; set; }
            public string title_en { get; set; }
            public string synopsis { get; set; }
            public AlternativeTitles alternative_titles { get; set; }
            public Information information { get; set; }
            public Statistics statistics { get; set; }
            public List<object> characters { get; set; }
            public string picture_url { get; set; }
        }

        public class MAL_GetAnimeGenres
        {
            public string title { get; set; }
            public int amount { get; set; }
            public int id { get; set; }
        }

}