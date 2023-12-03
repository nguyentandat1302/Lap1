using PagedList;
using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class NhaXuatBanController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Sach
        public ActionResult Index(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.NHAXUATBAN.ToList().OrderBy(n => n.MaNXB).ToPagedList(iPageNum, iPageSize));
        }
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.NHAXUATBAN.ToList().OrderBy(n => n.TenNXB), "MaCD", "TenChuDe");

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SACH model, FormCollection f, HttpPostedFileBase fFileUpload)
        {

            ViewBag.MaCD = new SelectList(db.CHUDE.ToList().OrderBy(c => c.MaCD), "MaCD", "TenChuDe");


            return View();
        }
    }
}