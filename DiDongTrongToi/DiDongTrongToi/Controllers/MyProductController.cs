using DiDongTrongToi.Models;
using DiDongTrongToi.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiDongTrongToi.Controllers
{
    public class MyProductController : Controller
    {
        // GET: MyProduct
        public ActionResult MyProduct()
        {
            var taikhoan = (Login)Session[SessionLogin.sec];
            if(taikhoan==null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View("MyProduct");
            }            
        }
        public ActionResult SanPhamDangGiao(int sanPham, string GiamGia, int soluong)
        {
            try
            {
                using (bandiDongEntities db = new bandiDongEntities())
                {
                    var taikhoan = (Login)Session[SessionLogin.sec];
                    try
                    {
                        if (db.Dat_Hang.Where(i => i.sanpham == sanPham && i.acc == taikhoan.taiKhoan).Count() == 0)
                        {
                            Dat_Hang h = new Dat_Hang();
                            h.giamgia = GiamGia;
                            h.ChuanBi = true;
                            h.sanpham = sanPham;
                            h.acc = taikhoan.taiKhoan;
                            h.soLuong = soluong;
                            h.ngaydat = DateTime.Now;
                            h.NgayGiao = DateTime.Now.AddDays(3);
                            db.Dat_Hang.Add(h);
                            db.SaveChanges();
                            return RedirectToAction("MyProduct", "MyProduct");
                        }
                        else
                        {
                            return RedirectToAction("MyProduct", "MyProduct");
                        }
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("MyProduct", "MyProduct");
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
           

        }
        public ActionResult XoaSanPham(int i)
        {
            try
            {
                using (bandiDongEntities db = new bandiDongEntities())
                {
                    var dathang = db.Dat_Hang.Where(k => k.id == i && k.daXoa == false).FirstOrDefault();
                    if(dathang.VanChuyen==true && dathang.daGiao==true)
                    {
                        return RedirectToAction("MyProduct", "MyProduct");
                    }
                    else if (dathang.ChuanBi == true && dathang.VanChuyen == false && dathang.daGiao == false)
                    {
                        dathang.daXoa = true;
                        db.SaveChanges();
                        return RedirectToAction("MyProduct", "MyProduct");
                    }
                    else
                    {
                        return RedirectToAction("MyProduct", "MyProduct");
                    }
                }
                    
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}