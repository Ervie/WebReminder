using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using WebReminder.Database.DB_Operations;
using WebReminder.Models;

namespace WebReminder.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            using (TaskDatabase db = new TaskDatabase())
            {
                string currentUserName = HttpContext.User.Identity.Name;
                
                return View(db.GetUsersTaskByName(currentUserName));
            }
            
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            using (TaskDatabase db = new TaskDatabase())
            {
                var selectedTask = db.GetTaskById(id);
                return View(selectedTask);
            }
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new Task());
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(Task task)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (TaskDatabase db = new TaskDatabase())
                {
                    int currentUserId;

                    Int32.TryParse(Session["UserId"].ToString(), out currentUserId);

                    db.AddTaskToDatabase(task, currentUserId);
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            using (TaskDatabase db = new TaskDatabase())
            {
                var selectedTask = db.GetTaskById(id);
                return View(selectedTask);
            }
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(Task task)
        {
            try
            {
                using (TaskDatabase db = new TaskDatabase())
                {
                    db.ReplaceProperties(task);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            using (TaskDatabase db = new TaskDatabase())
            {
                db.RemoveTaskById(id);
            }
                return RedirectToAction("Index");
        }

        //// POST: Task/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
