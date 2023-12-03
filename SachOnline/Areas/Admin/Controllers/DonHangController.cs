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
    public class DonHangController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Sach
        public ActionResult Index(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.DONDATHANG.ToList().OrderBy(n => n.MaDonHang).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ddh = db.DONDATHANG.SingleOrDefault(n => n.MaDonHang == id);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ddh);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DONDATHANG dh)
        {
            if (ModelState.IsValid)
            {
                db.DONDATHANG.AddOrUpdate(dh);
                db.SaveChanges();
                //Tham cong thi tro ve danh sach don hang
                return RedirectToAction("Index", "DonHang", new { Area = "Admin" });// action index, controler DoHang, Area ="Admin"

            }
            // Truong hop bi loi hay cac truong nhap ko hop le so voi rang buoc cua model => ModelState.IsValid = false

            //return View("Edit", "DonHang", new {Area = "Admin", id = dh.MaDonHang});
            //hoac neu cung controler goi thi bo qua
            return View("Edit", new { id = dh.MaDonHang });
        }   
            

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var donhang = db.DONDATHANG.SingleOrDefault(n => n.MaDonHang == id);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donhang);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var donhang = db.DONDATHANG.SingleOrDefault(n => n.MaDonHang == id);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           
           
            db.DONDATHANG.Remove(donhang);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var donhang = db.DONDATHANG.SingleOrDefault(n => n.MaDonHang == id);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donhang);
        }



    }
}