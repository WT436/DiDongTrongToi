using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiDongTrongToi.Models;
using DiDongTrongToi.Models.Login;

namespace DiDongTrongToi.Controllers
{
    public class MyCartController : Controller
    {
        // GET: MyCart
        public ActionResult SanPhamCuaToi(int a=1)
        {
            using (bandiDongEntities db = new bandiDongEntities())
            {
                var taikhoan = (Login)Session[SessionLogin.sec];
                if(taikhoan==null)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    try
                    {
                        if (db.hang_cho.Where(i => i.sanpham == a && i.acc == taikhoan.taiKhoan).Count() == 0)
                        {
                            hang_cho h = new hang_cho();
                            h.sanpham = a;
                            h.acc = taikhoan.taiKhoan;
                            h.soLuong = 1;
                            db.hang_cho.Add(h);
                            db.SaveChanges();
                            List<hang_cho> mo = db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan && i.daXoa == false).ToList();
                            return View(mo);
                        }
                        else if (db.hang_cho.Where(i => i.sanpham == a && i.acc == taikhoan.taiKhoan && i.daXoa == true).Count() == 1)
                        {
                            if (db.Dat_Hang.Where(i => i.sanpham == a && i.acc == taikhoan.taiKhoan && i.daXoa == false).Count() == 1)
                            {
                                db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan && i.id == a).FirstOrDefault().daXoa = true;
                                db.SaveChanges();
                                var mo = db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan && i.daXoa == false).ToList();
                                return View(mo);
                            }
                            else
                            {
                                db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan).FirstOrDefault().daXoa = false;
                                db.SaveChanges();
                                var mo = db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan && i.id == a && i.daXoa == false).ToList();
                                return View(mo);
                            }
                        }
                        else
                        {
                            var mo = db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan && i.id == a && i.daXoa == false).ToList();
                            return View(mo);
                        }
                    }
                    catch (Exception)
                    {
                        return View();

                    }
                }
                

            }
        }
        public ActionResult XoaSanPham(int idsanpham)
        {
            using (bandiDongEntities db = new bandiDongEntities())
            {
                var taikhoan = (Login)Session[SessionLogin.sec];
                try
                {
                    db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan && i.id == idsanpham).FirstOrDefault().daXoa = true;
                    db.SaveChanges();
                    var mo = db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan).ToList();
                    return View("SanPhamCuaToi");
                }
                catch (Exception)
                {
                    return View();
                    throw;
                }

            }
        }
        public ActionResult MuaSanPham(string idsanpham, string soluong, string MaGiamgia)
        {
            using (bandiDongEntities db = new bandiDongEntities())
            {
                var taikhoan = (Login)Session[SessionLogin.sec];
                try
                {
                    int dsanpham = Convert.ToInt32(idsanpham);
                    db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan && i.id == dsanpham).FirstOrDefault().daXoa = true;
                    db.SaveChanges();
                    db.SaveChanges();
                    var mo = db.hang_cho.Where(i => i.acc == taikhoan.taiKhoan).ToList();
                    return RedirectToAction("SanPhamDangGiao", "MyProduct", new { sanPham = dsanpham, GiamGia = MaGiamgia, soluong = soluong });
                }
                catch (Exception)
                {
                    return View();
                    throw;
                }

            }
        }
    }
}