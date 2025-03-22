using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{

    public class MAL_Genres
    {
        public string title { get; set; }
        public int? amount { get; set; }
        public int id { get; set; }
    }


    public class MAL_AnimeInfo
    {
        public string title { get; set; }
        public string synopsis { get; set; }
        public string picture { get; set; }
        public List<Character> characters { get; set; }
        public List<Staff> staff { get; set; }
        public string trailer { get; set; }
        public string englishTitle { get; set; }
        public string japaneseTitle { get; set; }
        public List<string> synonyms { get; set; }
        public string type { get; set; }
        public string episodes { get; set; }
        public string aired { get; set; }
        public string premiered { get; set; }
        public string broadcast { get; set; }
        public List<string> producers { get; set; }
        public List<string> studios { get; set; }
        public string source { get; set; }
        public string duration { get; set; }
        public string rating { get; set; }
        public List<string> genres { get; set; }
        public string status { get; set; }
        public string score { get; set; }
        public string scoreStats { get; set; }
        public string ranked { get; set; }
        public string popularity { get; set; }
        public string members { get; set; }
        public string favorites { get; set; }
        public int id { get; set; }
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

    public class Date
    {
        public string date_str { get; set; }
        public string time_str { get; set; }
        public object timestamp { get; set; }
    }

    public class AnimeObject
    {
        public string title { get; set; }
        public string myanimelist_url { get; set; }
        public string myanimelist_id { get; set; }
        public string all_reviews_url { get; set; }
        public string picture_url { get; set; }
    }

    public class MAL_AnimeReview
    {
        [JsonProperty("object")]
        public AnimeObject anime { get; set; }
        public User user { get; set; }
        public List<string> tags { get; set; }
        public Text text { get; set; }
        public Date date { get; set; }
    }

    public class Text
    {
        public string visible { get; set; }
        public string hidden { get; set; }
        public string full { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string url { get; set; }
        public string picture_url { get; set; }
    }

    public class Author
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class Liked
    {
        public string title { get; set; }
        public string picture_url { get; set; }
        public string myanimelist_url { get; set; }
        public string myanimelist_id { get; set; }
    }
    public class Recommended
    {
        public string title { get; set; }
        public string picture_url { get; set; }
        public string myanimelist_url { get; set; }
        public string myanimelist_id { get; set; }
    }
    public class MAL_Recommendations
    {
        public Liked liked { get; set; }
        public Recommended recommended { get; set; }
        public string description { get; set; }
        public Author author { get; set; }
    }
    public class Character
    {
        public string link { get; set; }
        public string picture { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public Seiyuu seiyuu { get; set; }
    }
    public class Seiyuu
    {
        public string link { get; set; }
        public string picture { get; set; }
        public string name { get; set; }
    }
    public class Staff
    {
        public string link { get; set; }
        public string picture { get; set; }
        public string name { get; set; }
        public string role { get; set; }
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