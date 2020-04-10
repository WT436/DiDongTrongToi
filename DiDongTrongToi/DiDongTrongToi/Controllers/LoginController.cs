using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiDongTrongToi.Models;
using DiDongTrongToi.Models.Login;
using DiDongTrongToi.Models.Security;
using Facebook;

namespace DiDongTrongToi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TTK()
        {
            return View();
        }

        
        [HttpPost]
        public string loadAnh(HttpPostedFileBase fileeeee)
        {
            fileeeee.SaveAs(Server.MapPath("~/Content/IMG/" + fileeeee.FileName));
            return "/Content/IMG/" + fileeeee.FileName;
        }
        public ActionResult HandlingLoginUser(LoginModel Login)
        {
            try
            {
                using (bandiDongEntities db = new bandiDongEntities())
                {
                    acc U = db.accs.Where(n => n.taikhoan == Login.TaiKhoan).FirstOrDefault();
                    if (U == null)
                    {
                        ModelState.AddModelError("", "Tài Khoản Không Tồn Tại");
                    }
                    else
                    {
                        string ha = db.accs.Where(n => n.taikhoan == Login.TaiKhoan).FirstOrDefault().hask.ToString().Trim();
                        string matkhau = MD5.MD5Hash(Login.MatKhau.Trim(), ha);
                        if (db.accs.Where(n => n.taikhoan == Login.TaiKhoan && n.matkhau == matkhau).FirstOrDefault() == null)
                        {
                            ModelState.AddModelError("", "Mật Khẩu Chưa Chính xác");
                        }
                        else
                        {
                            Login G = new Login();
                            G.taiKhoan = U.taikhoan;
                            Session.Add(SessionLogin.sec, G);
                            if(U.phanQuyen==2)// 2 it is Suppier
                            {
                                return RedirectToAction("HS", "TrangChuSupplier", new { area = "Supplier" });
                            }
                            else// it is user
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Cần Nhập Đầy Đủ Thông Tin");
            }
            return View("Index");
        }

        public ActionResult ChangePass(LoginModel P)
        {
            try
            {
                if (P.MatKhauMoi.Equals(P.MatKhauLai)==false)
                {
                    ModelState.AddModelError("", "Mật Khẩu Không Giống Nhau");
                }
                else
                {
                    using (bandiDongEntities db = new bandiDongEntities())
                    {
                        if (db.accs.Where(n => n.taikhoan == P.TaiKhoan).FirstOrDefault() == null)
                        {
                            ModelState.AddModelError("", "Tài Khoản Không Tồn Tại");
                        }
                        else
                        {
                            string ha = db.accs.Where(n => n.taikhoan == P.TaiKhoan).FirstOrDefault().hask.ToString().Trim();
                            string matkhau = MD5.MD5Hash(P.MatKhau.Trim(), ha);
                            if (db.accs.Where(n => n.taikhoan == P.TaiKhoan && n.matkhau == matkhau).FirstOrDefault() == null)
                            {
                                ModelState.AddModelError("", "Mật Khẩu Không Tồn Tại");
                            }
                            else
                            {
                                acc ac = db.accs.Where(n => n.taikhoan == P.TaiKhoan && n.matkhau == matkhau).FirstOrDefault();
                                string has = new Random().Next(100000, 1000000).ToString().Trim();
                                ac.matkhau = MD5.MD5Hash(P.MatKhauMoi, has).Trim();
                                ac.hask = has;
                                db.SaveChanges();
                                ModelState.AddModelError("", "Mật Khẩu Đã được Thay Đổi");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("1", "Cần Nhập Đầy Đủ Thông Tin");
            }
            return View("Index");
        }
        public ActionResult RecoverPass(LoginModel RP)
        {
            try
            {
                using (bandiDongEntities db = new bandiDongEntities())
                {
                    if (db.accs.Where(n => n.taikhoan == RP.TaiKhoan).FirstOrDefault() == null)
                    {
                        ModelState.AddModelError("", "Tài Khoản Không Tồn Tại");
                    }
                    else
                    {
                        if (db.accs.Where(n => n.gmail == RP.Gmail && n.taikhoan==RP.TaiKhoan).FirstOrDefault() == null)
                        {
                            ModelState.AddModelError("", "Gmail Không chính Xác");
                        }
                        else
                        {
                            string matkhau = new Random().Next(100000, 1000000).ToString().Trim();
                            string hask = new Random().Next(100000, 1000000).ToString().Trim();
                            string NoiDung = matkhau + "  là Mật Khẩu Mói của Bạn vui lòng đăng nhập và đổi mật khẩu";
                            SendMail.SendEmail(RP.Gmail, NoiDung);
                            var acc = db.accs.Where(n => n.gmail == RP.Gmail && n.taikhoan == RP.TaiKhoan).FirstOrDefault();
                            acc.matkhau = MD5.MD5Hash(matkhau,hask).Trim();
                            acc.hask = hask.Trim();
                            db.SaveChanges();
                            ModelState.AddModelError("", "Vui Lòng Kiểm Tra Gmail");
                        }
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Chưa Nhập Gmail");
            }
            return View("Index");
        }

        public ActionResult addInFo(AddInfoUser user)
        {
            try
            {
                if(user.taikhoan==null || 
                   user.matkhau == null||
                   user.gmail == null||
                   user.ten == null||
                   user.tuoi == 0||
                   user.sdt == 0||
                   user.diachi == null||
                   user.anh == null)
                {
                    ModelState.AddModelError("", "Vui Lòng Kiểm Tra Thông Tin");
                    return View("TTK");
                }
                else
                {
                    
                    using (bandiDongEntities db= new bandiDongEntities())
                    {
                        if (db.accs.Where(n=>n.gmail==user.gmail).Count()>0)
                        {
                            ModelState.AddModelError("", "Gmail Đã tồn tại");
                            return View("TTK");
                        }
                        else{
                            acc sc = new acc();
                            sc.taikhoan = user.taikhoan.Trim();
                            string ha = new Random().Next(100000, 1000000).ToString().Trim();
                            string mk = MD5.MD5Hash(user.matkhau.Trim(), ha);
                            sc.matkhau = mk.Trim();
                            sc.gmail = user.gmail.Trim();
                            sc.hask = ha.Trim();
                            sc.phanQuyen = 0;

                            db.accs.Add(sc);
                            db.SaveChanges();


                            thongTin tb = new thongTin();

                            tb.avatar = user.anh.Trim();
                            tb.ten = user.ten;
                            tb.tuoi = user.tuoi;
                            tb.diachi = user.diachi;
                            tb.sdt = user.sdt;
                            tb.taikhoan = user.taikhoan.Trim();
                            tb.daxoa = false;
                            tb.ngayCapNhat = DateTime.Now;
                            db.thongTins.Add(tb);
                            db.SaveChanges();

                            return View("Index");
                        }                         
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Vui Lòng Kiểm Tra Thông Tin Hoặc Tài Khoẳn Đã Tồn Tại"+ex);
                return View("TTK");
            }
            
        }
        //facebook
        private Uri faceUri
        {
            get {
                var uribuilder = new UriBuilder(Request.Url);
                uribuilder.Query = null;
                uribuilder.Fragment = null;
                uribuilder.Path = Url.Action("FacebookCallback");
                return uribuilder.Uri;
            }
        }
       

        public ActionResult LoginFace()
        {
            var fa = new FacebookClient();
            var loginf = fa.GetLoginUrl(new
            {
                Client_FbAppId = ConfigurationManager.AppSettings["FbAppId"],
                Client_FbAppSecret = ConfigurationManager.AppSettings["FbAppSecret"],
                redi_uri= faceUri.AbsoluteUri,
                res_type="code",
                scope="Email",
            });
            return Redirect(faceUri.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic re = fb.Post("oauth/access_token",new
            {
                Client_FbAppId = ConfigurationManager.AppSettings["FbAppId"],
                Client_FbAppSecret = ConfigurationManager.AppSettings["FbAppSecret"],
                redi_uri = faceUri.AbsoluteUri,
                code = code
            });
            var acctoken = re.access_token;
            if(!string.IsNullOrEmpty(acctoken))
            {

            }
            return Redirect("/");
        }


    }
}