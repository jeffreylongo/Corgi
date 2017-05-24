using Corgi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;




namespace Corgi.Controllers
{
    public class HotNewsController : Controller
    {
        // GET: HotNews
        public ActionResult Index()
        {
            var url = $"http://webhose.io/filterWebContent?token=46e1f57d-4ca5-493c-b5e7-cf187aa11c99&format=json&ts=1495547802409&sort=crawled&q=language%3Aenglish";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            JObject json = JObject.Parse(rawResponse);

            var hotArticles = json["posts"]
                .Select(s => new HotArticles { StoryName = s["thread"]["title"].ToString(), Url = s["thread"]["url"].ToString() })
                .GroupBy(g => g.Url).Select(s => s.First());

            return View(hotArticles);

        }
    }
}