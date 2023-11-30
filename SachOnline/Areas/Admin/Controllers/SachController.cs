using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Data.Entity.Migrations;
using System.Drawing;

namespace SachOnline.Areas.Admin.Controllers
{
    public class SachController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Sach
        public ActionResult Index(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.SACH.ToList().OrderBy(n => n.Masach).ToPagedList(iPageNum, iPageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.CHUDE.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SACH model, FormCollection f, HttpPostedFileBase fFileUpload)
        {

            ViewBag.MaCD = new SelectList(db.CHUDE.ToList().OrderBy(c => c.MaCD), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB");
            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    Image img = Image.FromStream(fFileUpload.InputStream, true, true);
                    model.Anhbia = Utility.ConvertImageToBase64(img);
                }
              
                db.SACH.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
      
        public static string ConverImageToBase64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public ActionResult Details(int id)
        {
            var sach = db.SACH.SingleOrDefault(n => n.Masach == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var sach = db.SACH.SingleOrDefault(n => n.Masach == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var sach = db.SACH.SingleOrDefault(n => n.Masach == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var ctdh = db.CHITIETDONTHANG.Where(ct => ct.Masach == id);
            if (ctdh.Count() > 0)
            {
                ViewBag.ThongBao = "Sách này đang có trong bảng Chi tiết đặt hàng <br>" +
                    "Nếu muốn xóa thì phải xóa hết mã sách này trong chi tiết đặt hàng";
                return View(sach);
            }
            var vietsach = db.VIETSACH.Where(vs => vs.MaSach == id).ToList();
            if (vietsach != null)
            {
                db.VIETSACH.RemoveRange(vietsach);
                db.SaveChanges();
            }
            db.SACH.Remove(sach);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sach = db.SACH.SingleOrDefault(n => n.Masach == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaCD = new SelectList(db.CHUDE.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe", sach.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection f, HttpPostedFileBase fFileUpload)
        {
            var sach = db.SACH.SingleOrDefault(n => n.Masach == int.Parse(f["iMaSach"])); 
            ViewBag.MaCD = new SelectList(db.CHUDE.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe", sach.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            if (ModelState.IsValid)
            {
                if (fFileUpload != null) 
                {
          
                    var sFileName = Path.GetFileName(fFileUpload.FileName);
           
                    var path = Path.Combine(Server.MapPath("~/Images"), sFileName);
                   //Kiểm tra file đã tồn tại chưa
                    if (!System.IO.File.Exists(path))
                    {
                        fFileUpload.SaveAs(path);
                    }
                    sach.Anhbia = sFileName;
                }
                //Lưu Sach vào CSDL
                sach.Tensach = f["sTenSach"];
                sach.Mota = f["sMoTa"];
                sach.Ngaycapnhat = Convert.ToDateTime(f["dNgayCapNhat"]);
                sach.Soluongton = int.Parse(f["iSoLuong"]);
                sach.Giaban = decimal.Parse(f["mGiaBan"]);
                sach.MaCD = int.Parse(f["MaCD"]);
                sach.MaNXB = int.Parse(f["MaNXB"]);
                db.SACH.AddOrUpdate(sach);
                db.SaveChanges();
                // Về lại trang Quản lý sách
                return RedirectToAction("Index");
            }
            return View(sach);
        }   //    }


    }
}