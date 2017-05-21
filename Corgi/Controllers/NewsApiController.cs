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
        public void GetArticles()
        {

            var url = $"https://newsapi.org/v1/articles&apiKey=d83621ac9a174c91823a72f6e131fb00";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }
            var hotNews = JsonConvert.DeserializeObject(rawResponse);

        }
    }
}
