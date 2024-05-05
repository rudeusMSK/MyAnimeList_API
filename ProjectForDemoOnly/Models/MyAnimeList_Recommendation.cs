using System.Collections.Generic;

namespace ProjectForDemoOnly.Models
{
    // nếu bạn ko đã biết hoặc muốn tiếp kiệm thời gian hãy copy phần body và dùng tool trợ giúp xây phần model !
    // đây là tool tôi đã dùng cho phần model bên dưới ! link: https://json2csharp.com/

    // model:
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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
        public int myanimelist_id { get; set; }
    }

    public class Recommendation
    {
        public Liked liked { get; set; }
        public Recommendation recommendation { get; set; }

        public Recommendation2 recommendation2 { get; set; }
        public string description { get; set; }
        public Author author { get; set; }
        public string recommendation_age { get; set; }

    }

    public class Recommendation2
    {
        public string title { get; set; }
        public string picture_url { get; set; }
        public string myanimelist_url { get; set; }
        public int myanimelist_id { get; set; }
    }

    public class Root
    {
        public List<Recommendation> recommendations { get; set; }
        public int amount_recommendations { get; set; }
    }



}
