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
using Corgi.Services;
using Microsoft.Ajax.Utilities;
using System.Threading.Tasks;

namespace Corgi.Controllers
{
    public class HotNewsController : Controller
    {
        // GET: HotNews
        public async Task<ActionResult> Index(NewsSearchModel searchModel)
        {
            var hotArticles = await HotNewsServices.GetTheNews(searchModel);
            return View(hotArticles);
        }

        public async Task<ActionResult> Search(NewsSearchModel searchModel)
        {
            var hotArticles = await HotNewsServices.GetTheNews(searchModel);
            return PartialView("_articleList", hotArticles);

        }
        
    }
}