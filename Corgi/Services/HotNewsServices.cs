using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Corgi.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Ajax.Utilities;

namespace Corgi.Services
{
    public class HotNewsServices
    {
        //public static IEnumerable<HotArticles> GetTheNews()
        //{
        //    var url = $"http://webhose.io/filterWebContent?token=46e1f57d-4ca5-493c-b5e7-cf187aa11c99&format=json&ts=1495411468230&sort=relevancy&q=language%3Aenglish%20site_type%3Anews";
        //    var request = WebRequest.Create(url);
        //    var response = request.GetResponse();
        //    var rawResponse = String.Empty;
        //    using (var reader = new StreamReader(response.GetResponseStream()))
        //    {
        //        rawResponse = reader.ReadToEnd();
        //    }

        //    JObject json = JObject.Parse(rawResponse);

        //    var hotArticles = json["posts"]
        //        .Select(s => new HotArticles { StoryName = s["thread"]["title"].ToString(), Url = s["thread"]["url"].ToString() })
        //        .GroupBy(g => g.Url).Select(s => s.First());
        //    return hotArticles;
        //}

        public static IEnumerable<HotArticles> GetTheNews(NewsSearchModel searchModel)
        {
            var url = $"http://webhose.io/filterWebContent?token=46e1f57d-4ca5-493c-b5e7-cf187aa11c99&format=json&ts=1495411468230&sort=relevancy&q=language%3Aenglish%20site_type%3Anews";
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

            var result = hotArticles.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.StoryName != null)
                    hotArticles = result.Where(w => w.StoryName.ToLower().Contains(searchModel.StoryName.ToLower()));
            }

            return hotArticles;
        }

    }
}