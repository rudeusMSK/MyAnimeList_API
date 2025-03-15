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
    }
}
