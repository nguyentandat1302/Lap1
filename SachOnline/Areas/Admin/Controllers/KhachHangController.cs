using PagedList;
using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Sach
        public ActionResult Index(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.KHACHHANG.ToList().OrderBy(n => n.MaKH).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var KH = db.KHACHHANG.SingleOrDefault(n => n.MaKH == id);
            if (KH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(KH);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(KHACHHANG KH)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANG.AddOrUpdate(KH);
                db.SaveChanges();
                //Tham cong thi tro ve danh sach don hang
                return RedirectToAction("Index", "KHACHHANG", new { Area = "Admin" });
            }
            return View(KH);
        }
        public ActionResult Details(int id)
        {
            var kh = db.KHACHHANG.SingleOrDefault(n => n.MaKH == id);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var KH = db.KHACHHANG.SingleOrDefault(n => n.MaKH == id);
            if (KH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(KH);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var KH = db.KHACHHANG.SingleOrDefault(n => n.MaKH == id);
            if (KH == null)
            {
                Response.StatusCode = 404;
                return null;
            }


            db.KHACHHANG.Remove(KH);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
