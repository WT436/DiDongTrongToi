using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DiDongTrongToi.Models;

namespace DiDongTrongToi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {          
            return View();
        }
        public ActionResult Phone()
        {
            return View();
        }
        public ActionResult Tablet()
        {
            return View();
        }
        public ActionResult Computer()
        {
            return View();
        }
        public ActionResult accessories()
        {
            return View();
        }
        public ActionResult Watch()
        {
            return View();
        }
        public ActionResult Card(string TenSanPham ,string HangSanPham,int SoSao,int GiamGia,int Gia1, int gia2,int Page = 1, int pageSize = 12)
        {
            bandiDongEntities db = new bandiDongEntities();
            var sd = db.sanphams.ToPagedList(Page, pageSize);
            return View();
        }
    }
}
