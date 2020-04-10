using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiDongTrongToi.Models;

namespace DiDongTrongToi.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        // GET: ChiTietSanPham
        bandiDongEntities db = new bandiDongEntities();
        public ActionResult Index(int ma)
        {

            var danhMuc = db.Danh_Muc_Theo_Chung_loai.Where(m => m.id == ma).FirstOrDefault();
            if (danhMuc.id == 2) { return RedirectToAction("DongHoCongNghe", "ChiTietSanPham", new { ma = ma }); }
            else if (danhMuc.id == 3) { return RedirectToAction("DongHoThoiTrang", "ChiTietSanPham", new { ma = ma }); }
            else if (danhMuc.id == 4) { return RedirectToAction("Cammera", "ChiTietSanPham", new { ma = ma }); }
            else if (danhMuc.id == 5) { return RedirectToAction("CapSac", "ChiTietSanPham", new { ma = ma }); }
            else if (danhMuc.id == 6) { return RedirectToAction("OpLung", "ChiTietSanPham", new { ma = ma }); }
            else if (danhMuc.id == 7) { return RedirectToAction("Pin", "ChiTietSanPham", new { ma = ma }); }
            else if (danhMuc.id == 8) { return RedirectToAction("TaiNghe", "ChiTietSanPham", new { ma = ma }); }
            else if (danhMuc.id == 9) { return RedirectToAction("ThietBiMang", "ChiTietSanPham", new { ma = ma }); }
            else if (danhMuc.id == 10) { return RedirectToAction("ThietBiNho", "ChiTietSanPham", new { ma = ma }); }
            else {
                var chude = db.Danh_Muc_Theo_Chu_De.Where(l => l.id == danhMuc.Danh_Muc_Theo_Chu_De).FirstOrDefault().id;
                if (chude == 1) { return RedirectToAction("DienThoai", "ChiTietSanPham", new { ma = ma }); }
                else if (chude == 2) { return RedirectToAction("DienThoai", "ChiTietSanPham", new { ma = ma }); }
                else if (chude == 3) { return RedirectToAction("LapTop", "ChiTietSanPham", new { ma = ma }); }                
                else if (chude == 6) { return RedirectToAction("TheCao", "ChiTietSanPham", new { ma = ma }); }
                else
                {
                    return RedirectToAction("TheCao", "ChiTietSanPham", new { ma = ma });
                }
            }
        }
        public ActionResult DienThoai(int ma)
        {
            var model = db.chi_tiet_Dien_Thoai.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }        
        public ActionResult LapTop(int ma)
        {
            var model = db.chi_tiet_May_Tinh.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult DongHoThoiTrang(int ma)
        {
            var model = db.chi_tiet_DongHoThoiTrang.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult DongHoCongNghe(int ma)
        {
            var model = db.chi_tiet_Dong_Ho_CongNghe.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult Cammera(int ma)
        {
            var model = db.chi_tiet_PhuKien_Cammera.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult CapSac(int ma)
        {
            var model = db.chi_tiet_PhuKien_CapSac.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult OpLung(int ma)
        {
            var model = db.chi_tiet_PhuKien_OpLung.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult Pin(int ma)
        {
            var model = db.chi_tiet_PhuKien_PIN.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult TaiNghe(int ma)
        {
            var model = db.chi_tiet_PhuKien_tainghe.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult TheCao(int ma)
        {
            var model = db.chi_tiet_The_cao.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult ThietBiNho(int ma)
        {
            var model = db.chi_tiet_PhuKien_ThietBiNho.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
        public ActionResult ThietBiMang(int ma)
        {
            var model = db.chi_tiet_PhuKien_ThietBiMang.Where(m => m.sanpham == ma).FirstOrDefault();
            return View(model);
        }
    }
}