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
        public ActionResult index()
        {
            return View();
        }

        public ActionResult Top()
        {
            return View();
        }

        public ActionResult Recommendations()
        {
            return View();
        }

        public ActionResult Seasonal()
        {
            return View();
        }

        public ActionResult Review()
        {
            return View();
        }

        public ActionResult AnimeDetail()
        {
            return View();
        }

        public ActionResult Genres()
        {
            return View();
        }
    }
}