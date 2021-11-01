using MyTimeHub.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTimeHub.Controllers
{
    public class ExportController : Controller
    {
        private MyTimeHubDBContext db = new MyTimeHubDBContext();
        // GET: Export
        public ActionResult Index()
        {
            return View();
        }
    }
}