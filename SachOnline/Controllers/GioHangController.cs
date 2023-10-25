using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        Model1 db = new Model1();
        public ActionResult Index()
        {

            var UserLogin =(KHACHHANG)Session["TaiKhoan"];
            if (UserLogin == null)
            {
                return Redirect("/User/DangNhap");
            }
            else
            {
                var GioHang = db.DONDATHANG.FirstOrDefault(d => d.Dathanhtoan == false && d.MaKH == UserLogin.MaKH);
                if (GioHang == null)
                {
                    GioHang = new DONDATHANG
                    {
                        MaKH = UserLogin.MaKH,
                        Dathanhtoan = false,
                    };
                    db.DONDATHANG.Add(GioHang);
                    db.SaveChanges();
                }
                var lstCTGioHang = db.CHITIETDONTHANG.Where(ct =>ct.MaDonHang== GioHang.MaDonHang).ToList();
                var model = (from ct in lstCTGioHang
                             join s in db.SACH
                             on ct.Masach equals s.Masach
                             select new  {MaDonHang = ct.MaDonHang,MaSach = ct.Masach , TenSach = s.Tensach,MoTa = s.Mota, AnhBia=s.Anhbia, GiaBan =s.Giaban,
                             SoLuong =ct.Soluong,ThanhTien = ct.Soluong * s.Giaban}).Select(t=>t.ToExpando()).ToList();
                             
                return View(model);
            }
           
        }
        
        public ActionResult ThemGioHang(int MaSach)
        {
            var UserLogin = (KHACHHANG)Session["TaiKhoan"];
            if (UserLogin == null)
            {
                return Redirect("/User/DangNhap");
            }
            else
            {
                var GioHang = db.DONDATHANG.FirstOrDefault(d => d.Dathanhtoan == false && d.MaKH == UserLogin.MaKH);
                if (GioHang == null)
                {
                    GioHang = new DONDATHANG
                    {
                        MaKH = UserLogin.MaKH,
                        Dathanhtoan = false,
                    };
                    db.DONDATHANG.Add(GioHang);
                    db.SaveChanges();     
                }
                // Cap nhap CTDonHang
                var CTDonHang = db.CHITIETDONTHANG.FirstOrDefault(
                    ct => ct.Masach == MaSach && ct.MaDonHang == GioHang.MaDonHang
                    );
                if (CTDonHang == null)
                {
                    CTDonHang = new CHITIETDONTHANG
                    {
                        Masach = MaSach,
                        MaDonHang = GioHang.MaDonHang,
                        Soluong = 1

                    };
                }
                else
                    CTDonHang.Soluong++;
                db.CHITIETDONTHANG.AddOrUpdate(CTDonHang);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}