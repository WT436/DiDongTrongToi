using DiDongTrongToi.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiDongTrongToi.Models;
using PagedList;
namespace DiDongTrongToi.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ChiTietSanPham(int id, int page = 1, int pageSize = 10)
        {
            ViewBag.maSanPham = id;
            bandiDongEntities db = new bandiDongEntities();
            var model = db.danh_gia.Where(n => n.sanpham == id).OrderByDescending(m => m.thoiGian).ToPagedList(page, pageSize);
            return View(model);
        }
        [HttpPost]
        public JsonResult CapNhatDanhGia(string noidung, string sosaochon, string idsanpham)
        {
            string trave = "1";
            if (noidung == null || sosaochon == null || idsanpham == null)
            {
                trave = "1";
            }
            else
            {
                try
                {
                    using (bandiDongEntities db = new bandiDongEntities())
                    {
                        danh_gia g = new danh_gia();
                        g.acc = ((Login)Session[SessionLogin.sec]).taiKhoan;
                        g.noidung = noidung.Trim();
                        g.sanpham = Int32.Parse(idsanpham.Trim());
                        g.soSao = Int32.Parse(sosaochon.Trim());
                        g.thoiGian = DateTime.Now;
                        db.danh_gia.Add(g);
                        db.SaveChanges();
                        trave = "0";
                    }
                }
                catch (Exception ex)
                {
                    trave = "1";
                }
            }
            return Json(trave);
        }
        public JsonResult CapNhatComment(string noidung, string idsanpham)
        {
            string trave = "1";
            if (noidung == null || idsanpham == null)
            {
                trave = "1";
            }
            else
            {
                try
                {
                    using (bandiDongEntities db = new bandiDongEntities())
                    {
                        rep_danh_Gia g = new rep_danh_Gia();
                        g.acc = ((Login)Session[SessionLogin.sec]).taiKhoan;
                        g.noidung = noidung.Trim();
                        g.danhgia = Int32.Parse(idsanpham);
                        g.thoiGian = DateTime.Now;
                        db.rep_danh_Gia.Add(g);
                        db.SaveChanges();
                        trave = "0";
                    }
                }
                catch (Exception)
                {
                    trave = "1";
                }
            }
            return Json(trave);
        }
        public JsonResult SuLyThichDanhGia(string idsanpham)
        {
            string trave = "1";
            if (idsanpham == null)
            {
                trave = "1";
            }
            else
            {
                try
                {
                    using (bandiDongEntities db = new bandiDongEntities())
                    {
                        var acc = ((Login)Session[SessionLogin.sec]).taiKhoan;
                        int maDanhGia = Int32.Parse(idsanpham);
                        var laydanhGiaCuaNGuoiDungNay = db.like_DanhGia.Where(m => m.danhgia == maDanhGia && m.acc == acc);
                        if (laydanhGiaCuaNGuoiDungNay.Count() == 0)
                        {
                            like_DanhGia li = new like_DanhGia();
                            li.C_like = true;
                            li.dislike = false;
                            li.acc = acc;
                            li.danhgia = maDanhGia;

                            db.like_DanhGia.Add(li);
                            db.SaveChanges();
                            trave = "2";
                        }
                        else
                        {
                            if (laydanhGiaCuaNGuoiDungNay.FirstOrDefault().C_like == false)
                            {
                                laydanhGiaCuaNGuoiDungNay.FirstOrDefault().dislike = false;
                                laydanhGiaCuaNGuoiDungNay.FirstOrDefault().C_like = true;
                                db.SaveChanges();
                                trave = "3";
                            }
                            else {
                                trave = "4";
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    trave = "1";
                }
            }
            return Json(trave);
        }

        public JsonResult SuLyKoThichDanhGia(string idsanpham)
        {
            string trave = "1";
            if (idsanpham == null)
            {
                trave = "1";
            }
            else
            {
                try
                {
                    using (bandiDongEntities db = new bandiDongEntities())
                    {
                        var acc = ((Login)Session[SessionLogin.sec]).taiKhoan;
                        int maDanhGia = Int32.Parse(idsanpham);
                        var laydanhGiaCuaNGuoiDungNay = db.like_DanhGia.Where(m => m.danhgia == maDanhGia && m.acc == acc);
                        if (laydanhGiaCuaNGuoiDungNay.Count() == 0)
                        {
                            like_DanhGia li = new like_DanhGia();
                            li.C_like = false;
                            li.dislike = true;
                            li.acc = acc;
                            li.danhgia = maDanhGia;

                            db.like_DanhGia.Add(li);
                            db.SaveChanges();
                            trave = "2";
                        }
                        else
                        {
                            if (laydanhGiaCuaNGuoiDungNay.FirstOrDefault().dislike == false)
                            {
                                laydanhGiaCuaNGuoiDungNay.FirstOrDefault().C_like = false;
                                laydanhGiaCuaNGuoiDungNay.FirstOrDefault().dislike = true;
                                db.SaveChanges();
                                trave = "3";
                            }
                            else
                            {
                                trave = "4";
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    trave = "1";
                }
            }
            return Json(trave);
        }
    }
}