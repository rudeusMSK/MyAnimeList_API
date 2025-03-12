using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Models.Services.MyAnimeListModel
{
    enum Seasonal
    {
        winter,
        spring,
        summer,
        fall,
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