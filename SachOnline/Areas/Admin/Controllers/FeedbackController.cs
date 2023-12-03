using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        Model1 db = new Model1();

        // GET: Admin/Feedback
        public ActionResult Index()
        {
            var list = from fb in db.Feedback select fb;
            return View(list);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var feedback = db.Feedback.SingleOrDefault(n => n.IDFeedback == id);
            if (feedback == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(feedback);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var feedback = db.Feedback.SingleOrDefault(n => n.IDFeedback == id);
            if (feedback == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           
            
            db.Feedback.Remove(feedback);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}