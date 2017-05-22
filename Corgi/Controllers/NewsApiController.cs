using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Corgi.Controllers
{
    public class NewsApiController : ApiController
    {
        // GET: api/NewsApi
        public IHttpActionResult GetArticles()
        {

            var url = $"http://webhose.io/filterWebContent?token=46e1f57d-4ca5-493c-b5e7-cf187aa11c99&format=json&ts=1495204202926&sort=crawled&q=performance_score%3A%3E0";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }
            var hotNews = JsonConvert.DeserializeObject(rawResponse);
            return Ok(hotNews);
        }
    }
}
