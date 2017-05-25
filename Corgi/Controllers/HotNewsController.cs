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




namespace Corgi.Controllers
{
    public class HotNewsController : Controller
    {
        // GET: HotNews
        public ActionResult Index()
        {
            var hotArticles = HotNewsServices.GetTheNews();
            return View(hotArticles);
        }
    }
}