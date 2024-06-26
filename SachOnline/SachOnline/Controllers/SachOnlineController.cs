﻿using System;
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
        public ActionResult Index(int? page)
        {
            var lstSach = db.SACH.OrderBy(s => s.Masach);
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
      
    }

}