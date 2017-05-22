using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Corgi.Controllers
{
    public class HotNewsController : Controller
    {
        // GET: HotNews
        public ActionResult Index()
        {
            return View();
        }
    }
}