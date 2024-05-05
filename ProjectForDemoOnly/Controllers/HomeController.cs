using RestSharp;
using ProjectForDemoOnly.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace ProjectForDemoOnly.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://myanimelist.p.rapidapi.com/v2/anime/recommendations?p=1"),
                Headers =
                {
                    { "X-RapidAPI-Key", "dcba14be99msh7fda78dd24a8705p1f40b4jsn2874bae46dc6" },
                    { "X-RapidAPI-Host", "myanimelist.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var myDeserializedClass = JsonConvert.DeserializeObject<Root>(body);

                return View(myDeserializedClass);
            }
        }
    }
}
