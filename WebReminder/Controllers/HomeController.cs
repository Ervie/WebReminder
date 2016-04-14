using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebReminder.Database.DB_Operations;
using WebReminder.Models;

namespace WebReminder.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            return View();
        }
    }
}