using DiDongTrongToi.Models;
using DiDongTrongToi.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiDongTrongToi.Controllers
{
    public class VanChuyenController : Controller
    {
        // GET: VanChuyen
        public ActionResult TrangThai(int a)
        {
            var taikhoan = (Login)Session[SessionLogin.sec];
            if (taikhoan == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                using (bandiDongEntities db = new bandiDongEntities())
                {
                    var mo = db.Dat_Hang.Where(i => i.id == a).FirstOrDefault();
                    return View(mo);
                }
                    
            }
        }
    }
}