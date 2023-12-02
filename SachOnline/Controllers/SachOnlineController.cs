using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SachOnline.Models;

namespace SachOnline.Controllers
{
   
    public class SachOnlineController : Controller
    {
        Model1 db = new Model1();

        // GET: SachOnline
        public ActionResult Index(string searchString, int? page)
        {
            searchString = searchString ?? "";

            var lstSach = db.SACH.Where(s=>s.Tensach.Contains(searchString)).OrderBy(s => s.Masach).ToList();
            int pageNumber = (page) ?? 1;
            int pageSize = 6;
            ViewBag.TieuDe = "SACH MOI";
            return View(lstSach.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in db.CHUDE select cd;
            return PartialView(listChuDe);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNXB = from cd in db.NHAXUATBAN select cd;
            return PartialView(listNXB);
        }
            public ActionResult _Layout()
        {      
            var dropdown = new object[] { db.CHUDE ,db.NHAXUATBAN };
                return View(dropdown);
        }

        public ActionResult SachBanNhieuPartial() {
            return PartialView();
        }
        public ActionResult ChiTietSach(int MaSach)
        {
            var sach = db.SACH.FirstOrDefault(s => s.Masach == MaSach);
            return View(sach);
        }

        public ActionResult SachTheoChuDe(int id)
        {
            var sach = from s in db.SACH where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SachTheoNhaXuatBan(int id)
        {
            var sach = from s in db.SACH where s.MaNXB == id select s;
            return View(sach);
        }


        public  ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        //public ActionResult Rating(Feedback model)
        //{
        //    if (Session["TaiKhoan"] == null)
        //    {
        //        return RedirectToAction("DangNhap", "User");

        //    }
        //    return RedirectToAction("ChiTietSach", "Sach", new { Masach = model.MaKH });
        //}
        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(Feedback Model)
        {
            if (Session["TaiKhoan"] == null)
            {
                // Người dùng chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("DangNhap", "User");
            }
            else
            {
                // Người dùng đã đăng nhập, tiếp tục xử lý bình luận
                var u = (KHACHHANG)Session["TaiKhoan"]; 

                if (u != null)
                {
                    Model.MaKH = u.MaKH;
                    db.Feedback.Add(Model);
                    db.SaveChanges();

                    
                    return RedirectToAction("ViewFeedback", "Feedback");
                }
                else
                {
              
                    ViewBag.ErrorMessage = "Không thể xác định thông tin người dùng.";
                    return View("Error"); 
                }
            }
        }

        public ActionResult ViewFeedback()
        {
            var list = from fb in db.Feedback select fb;
            return View(list);
        }

    }

}