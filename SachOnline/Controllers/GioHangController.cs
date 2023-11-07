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
                var GioHang = db.DONDATHANG.FirstOrDefault(d => d.Ngaydat == null && d.MaKH == UserLogin.MaKH);
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
                             select new  {Masach = ct.Masach, MaDonHang = ct.MaDonHang , TenSach = s.Tensach, MoTa = s.Mota, AnhBia=s.Anhbia, GiaBan =s.Giaban,
                             SoLuongTon = s.Soluongton,    SoLuong =ct.Soluong,ThanhTien = ct.Soluong * s.Giaban}).Select(t=>t.ToExpando()).ToList();
                             
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
                var GioHang = db.DONDATHANG.FirstOrDefault(d => d.Ngaydat == null && d.MaKH == UserLogin.MaKH);
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
        public ActionResult CapNhapGioHang(int MaDonHang, int MaSach,int SoLuong)
        {
            var ct = db.CHITIETDONTHANG.FirstOrDefault(t=>t.MaDonHang==MaDonHang && t.Masach ==MaSach);
            if(SoLuong ==0)
            {
                db.CHITIETDONTHANG.Remove(ct);
            }
            else
            {
                ct.Soluong = SoLuong;
                db.CHITIETDONTHANG.AddOrUpdate(ct);
            }
         
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult XoaGioHang(int MaDonHang,int MaSach)
        {
            var ct=db.CHITIETDONTHANG.FirstOrDefault(t=> t.MaDonHang ==MaDonHang &&t.Masach==MaSach);
            db.CHITIETDONTHANG.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public ActionResult DatHang(int MaDonHang,FormCollection f)
        {
            var dh = db.DONDATHANG.FirstOrDefault(t=>t.MaDonHang==MaDonHang);
            if(dh != null)
            {
                dh.DiaChiGH = f["DiaChiGH"];
                dh.Tinhtranggiaohang = false;
                string k = f["NgayDat"];
                dh.Ngaydat = DateTime.Parse(f["NgayDat"]);
                dh.Ngaygiao = DateTime.Parse(f["NgayGiao"]);
                dh.Dathanhtoan = false;
              
                dh.DienThoaiGH = f["SDTGiaoHang"];
                db.DONDATHANG.AddOrUpdate(dh);
                db.SaveChanges();
                return RedirectToAction("XacNhanDatHang", "GioHang");
            }
           return RedirectToAction("Index", "GioHang");
        }
        public ActionResult XacNhanDatHang()
        {
            return View();
        }
    }
}