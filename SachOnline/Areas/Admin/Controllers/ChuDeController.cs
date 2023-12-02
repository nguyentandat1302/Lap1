using PagedList;
using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class ChuDeController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Sach
        public ActionResult Index(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.CHUDE.ToList().OrderBy(n => n.MaCD).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.CHUDE.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SACH model, FormCollection f, HttpPostedFileBase fFileUpload)
        {

            ViewBag.MaCD = new SelectList(db.CHUDE.ToList().OrderBy(c => c.MaCD), "MaCD", "TenChuDe");
            
            
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var chude = db.CHUDE.SingleOrDefault(n => n.MaCD == id);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var chude = db.CHUDE.SingleOrDefault(n => n.MaCD == id);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
           
            db.CHUDE.Remove(chude);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}