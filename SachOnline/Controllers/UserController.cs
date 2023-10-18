using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG Model)
        {
            if (ModelState.IsValid)
            {
                var kh = db.KHACHHANG.FirstOrDefault(k => k.Taikhoan == Model.Taikhoan);
                if (kh != null)
                {
                    ModelState.AddModelError("TaiKhoan", "Ten tai Khoan ton tai");
                    return View(Model);
                }

                db.KHACHHANG.Add(Model);
                db.SaveChanges();
                return View("DangNhap");

            }

            return View(Model);


        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var u = db.KHACHHANG.FirstOrDefault(k=> k.Taikhoan== user.Username && k.Matkhau== user.Password);
                if (u != null)
                {
                    Session["TaiKhoan"] = u;
                    ViewBag.ThongBao = "Đăng Nhập Thành Công";
                    return Redirect("~/");
                }
                else
                {
                    ModelState.AddModelError("Password", "Error");
                }
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index","SachOnline");
        }
    }
}