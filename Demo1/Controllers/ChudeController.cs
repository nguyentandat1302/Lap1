using Demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.Models;

namespace Demo1.Controllers
{
    public class ChudeController : Controller
    {
        // GET: Chude
        QLBANSACHEntities db=new QLBANSACHEntities();
        public ActionResult Index()
        {
            var chude = db.CHUDE;
            return View(chude);
        }
    }
}