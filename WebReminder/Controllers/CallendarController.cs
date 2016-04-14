using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebReminder.Database.DB_Operations;

namespace WebReminder.Controllers
{
    public class CallendarController : Controller
    {
        // GET: Callendar
        public ActionResult Index()
        {
            using (TaskDatabase db = new TaskDatabase())
            {
                int currentUserId;

                Int32.TryParse(Session["UserId"].ToString(), out currentUserId);

                ViewBag.TaskList = db.getUsersTasks(currentUserId);

                return View();
            }
        }
    }
}