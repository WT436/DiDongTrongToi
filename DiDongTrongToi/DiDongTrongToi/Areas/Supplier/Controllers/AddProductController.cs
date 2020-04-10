using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiDongTrongToi.Areas.Supplier.Models;
using DiDongTrongToi.Models;
using DiDongTrongToi.Models.Login;

namespace DiDongTrongToi.Areas.Supplier.Controllers
{
    public class AddProductController : Controller
    {
        bandiDongEntities db = new bandiDongEntities();
        // GET: Supplier/AddProduct
        SaveNewProduct G = new SaveNewProduct();
        public ActionResult PSA(sanpham sa)
        {

            var taikhoan = (Login)Session[SessionLogin.sec];
            if (taikhoan == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                string a = taikhoan.taiKhoan;
                var CallDataHere = (SaveNewProduct)Session[a];
                if (CallDataHere.maAnh == 0)
                {
                    return RedirectToAction("ASP", "AddProduct", new { area = "Supplier" });
                }
                else
                {
                    if (sa.ten == null ||
                        sa.gia == 0 ||
                        sa.soLuong == null ||
                        sa.soLuongconlai == null ||
                        sa.bao_hanh == 0 ||
                        sa.Danh_Muc_Theo_Chung_loai == null
                        )
                    {
                        ModelState.AddModelError("", "Chọn Đầy đủ  không để trống");
                        return View();
                    }
                    else
                    {
                        try
                        {
                            Login taikhoan112 = (Login)Session[SessionLogin.sec];
                            int maThongTin = db.thongTins.Where(m => m.taikhoan == taikhoan112.taiKhoan.Trim()).FirstOrDefault().id;
                            int maanhsanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoan112.taiKhoan]).maAnh);
                            sa.anhsanpham = maanhsanpham;
                            int manhacungcap = db.nhacungCaps.Where(n => n.idncc == maThongTin).FirstOrDefault().id;
                            sa.nhacungCap = manhacungcap;
                            db.sanphams.Add(sa);
                            db.SaveChanges();
                            int maSanPhamVuaAdd = db.sanphams.Where(n => n.ten == sa.ten &&
                                                  n.gia == sa.gia &&
                                                  n.soLuong == sa.soLuong &&
                                                  n.soLuongconlai == sa.soLuongconlai &&
                                                  n.bao_hanh == sa.bao_hanh &&
                                                  n.Danh_Muc_Theo_Chung_loai == sa.Danh_Muc_Theo_Chung_loai &&
                                                  n.anhsanpham == maanhsanpham &&
                                                  n.nhacungCap == manhacungcap).FirstOrDefault().id;
                            G.maSanPham = maSanPhamVuaAdd;
                            G.maChungloai = Convert.ToInt32(sa.Danh_Muc_Theo_Chung_loai);
                            G.machude = Convert.ToInt32(db.Danh_Muc_Theo_Chung_loai.Where(n => n.id == sa.Danh_Muc_Theo_Chung_loai).FirstOrDefault().Danh_Muc_Theo_Chu_De);

                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("", "Chọn Đầy đủ  không để trống 1");
                            return View();

                        }
                        int machude = Convert.ToInt32(db.Danh_Muc_Theo_Chung_loai.Where(m => m.id == sa.Danh_Muc_Theo_Chung_loai).FirstOrDefault().Danh_Muc_Theo_Chu_De);
                        if (G.machude == 1)//dienthoai
                        {
                            return RedirectToAction("DienThoai", "AddProduct", new { area = "Supplier" });
                        }
                        else if (G.machude == 2)//tablet
                        {
                            return RedirectToAction("Tablet", "AddProduct", new { area = "Supplier" });
                        }
                        else if (G.machude == 3)//MayTinh
                        {
                            return RedirectToAction("MayTinh", "AddProduct", new { area = "Supplier" });
                        }
                        else if (G.machude == 4)//PhuKien
                        {
                            if (G.maChungloai == 4)//cammera
                            {
                                return RedirectToAction("Cammera", "AddProduct", new { area = "Supplier" });
                            }
                            else if (G.maChungloai == 5)//capSac
                            {
                                return RedirectToAction("CapSac", "AddProduct", new { area = "Supplier" });
                            }
                            else if (G.maChungloai == 6)//ốp lưng
                            {
                                return RedirectToAction("OpLung", "AddProduct", new { area = "Supplier" });
                            }
                            else if (G.maChungloai == 7)//pin
                            {
                                return RedirectToAction("Pin", "AddProduct", new { area = "Supplier" });
                            }
                            else if (G.maChungloai == 8)//tainghe
                            {
                                return RedirectToAction("TaiNghe", "AddProduct", new { area = "Supplier" });
                            }
                            else if (G.maChungloai == 9)//thiet bi mang
                            {
                                return RedirectToAction("ThietBiMang", "AddProduct", new { area = "Supplier" });
                            }
                            else if (G.maChungloai == 10)//thiet bi nho
                            {
                                return RedirectToAction("ThietBiNho", "AddProduct", new { area = "Supplier" });
                            }
                            else
                            {
                                ModelState.AddModelError("", "Chọn Đầy đủ  không để trống 1");
                                return View();
                            }
                        }
                        else if (G.machude == 5)//dongho
                        {
                            if (G.maChungloai == 2)//dh thong minh
                            {
                                return RedirectToAction("DongHoCongNghe", "AddProduct", new { area = "Supplier" });
                            }
                            else if (G.maChungloai == 3)//dh thoi trang
                            {
                                return RedirectToAction("DongHoThoiTrang", "AddProduct", new { area = "Supplier" });
                            }
                        }
                        else if (G.machude == 6)//SimThe
                        {
                            return RedirectToAction("TheCao", "AddProduct", new { area = "Supplier" });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Chọn Đầy đủ  không để trống 1");
                            return View();
                        }

                    }
                    return View();
                }
            }
        }
        public ActionResult ASP(anhsanpham anh)
        {
            if (anh.anh1 == null ||
               anh.anh2 == null ||
               anh.anh3 == null ||
               anh.anh5 == null ||
               anh.anh6 == null ||
               anh.anh7 == null)
            {
                ModelState.AddModelError("", "Chọn Đầy đủ ảnh không để trống ảnh 1");
                return View();
            }
            else
            {
                try
                {
                    db.anhsanphams.Add(anh);
                    db.SaveChanges();
                    int maAnh = db.anhsanphams.Where(n => n.anh1 == anh.anh1 &&
                                                          n.anh2 == anh.anh2 &&
                                                          n.anh3 == anh.anh3 &&
                                                          n.anh5 == anh.anh5 &&
                                                          n.anh6 == anh.anh6 &&
                                                          n.anh7 == anh.anh7).FirstOrDefault().id;
                    ModelState.AddModelError("", "Chọn Đầy đủ ảnh không để trống ảnh 1");
                    var taikhoan = (Login)Session[SessionLogin.sec];
                    string a = taikhoan.taiKhoan;
                    G.taiKhoan = a;
                    G.maAnh = maAnh;
                    Session.Add(a, G);
                    return RedirectToAction("PSA", "AddProduct", new { area = "Supplier" });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Bạn Cần Đăng Nhập Tài Khoản");
                    return View();
                }

            }

        }

        public ActionResult Cammera(chi_tiet_PhuKien_Cammera cm)//
        {
            try
            {
                Login taikhoanDT = (Login)Session[SessionLogin.sec];                
                cm.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);

                db.chi_tiet_PhuKien_Cammera.Add(cm);
                db.SaveChanges();
                return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = cm.sanpham });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
        }
        public ActionResult CapSac(chi_tiet_PhuKien_CapSac cs)//
        {
            try
            {
                Login taikhoanDT = (Login)Session[SessionLogin.sec];
               
                cs.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);

                db.chi_tiet_PhuKien_CapSac.Add(cs);
                db.SaveChanges();
                return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = cs.sanpham });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
        }
        public ActionResult DienThoai(chi_tiet_Dien_Thoai dt)//
        {
            if (dt.mau_Sac == null ||
                dt.man_hinh == null ||
                dt.he_dieu_hanh == null ||
                dt.camera_Truoc == null ||
                dt.camera_Sau == null ||
                dt.Loi_san_Pham == null ||
                dt.di_Kem == null ||
                dt.ram == null ||
                dt.cpu == null ||
                dt.bo_nho == 0 ||
                dt.the_nho == null ||
                dt.sim == null ||
                dt.doPhanGiai == null ||
                dt.Man_Hinh_rong == null ||
                dt.KinhCamUng == null ||
                dt.chipset == null ||
                dt.TocDocpu == null ||
                dt.GPU == null ||
                dt.DoPhanGiaiCammeraTruoc == null ||
                dt.VideoCall == null ||
                dt.ThongTinKhacCamMera == null ||
                dt.DoPhanGiaiCamerasau == null ||
                dt.quayPhim == null ||
                dt.denFlash == null ||
                dt.chupAnhNangCao == null ||
                dt.hoTroMang == null ||
                dt.wifi == null ||
                dt.GPS == null ||
                dt.bluetooth == null ||
                dt.congKetNoi == null ||
                dt.JackTaiNGhe == null ||
                dt.ketNoiKhac == null ||
                dt.thietKe == null ||
                dt.ChatLieu == null ||
                dt.KichThuoc == null ||
                dt.TrongLuong == null ||
                dt.LoaiPin == null ||
                dt.CongNghePin == null ||
                dt.dung_luong_Pin == 0 ||
                dt.BaoMat == null ||
                dt.TinhNangNoiBat == null ||
                dt.GhiAm == null ||
                dt.Radio == null ||
                dt.XemPhim == null ||
                dt.NGheNHac == null ||
                dt.ThoiDiemRaMat == null
               )
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    dt.LoaiSanPham = true;
                    dt.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);

                    db.chi_tiet_Dien_Thoai.Add(dt);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = dt.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        public ActionResult Tablet(chi_tiet_Dien_Thoai dt)//
        {
            if (dt.mau_Sac == null ||
               dt.man_hinh == null ||
               dt.he_dieu_hanh == null ||
               dt.camera_Truoc == null ||
               dt.camera_Sau == null ||
               dt.Loi_san_Pham == null ||
               dt.di_Kem == null ||
               dt.ram == null ||
               dt.cpu == null ||
               dt.bo_nho == 0 ||
               dt.the_nho == null ||
               dt.sim == null ||
               dt.doPhanGiai == null ||
               dt.Man_Hinh_rong == null ||
               dt.KinhCamUng == null ||
               dt.chipset == null ||
               dt.TocDocpu == null ||
               dt.GPU == null ||
               dt.DoPhanGiaiCammeraTruoc == null ||
               dt.VideoCall == null ||
               dt.ThongTinKhacCamMera == null ||
               dt.DoPhanGiaiCamerasau == null ||
               dt.quayPhim == null ||
               dt.denFlash == null ||
               dt.chupAnhNangCao == null ||
               dt.hoTroMang == null ||
               dt.wifi == null ||
               dt.GPS == null ||
               dt.bluetooth == null ||
               dt.congKetNoi == null ||
               dt.JackTaiNGhe == null ||
               dt.ketNoiKhac == null ||
               dt.thietKe == null ||
               dt.ChatLieu == null ||
               dt.KichThuoc == null ||
               dt.TrongLuong == null ||
               dt.LoaiPin == null ||
               dt.CongNghePin == null ||
               dt.dung_luong_Pin == 0 ||
               dt.BaoMat == null ||
               dt.TinhNangNoiBat == null ||
               dt.GhiAm == null ||
               dt.Radio == null ||
               dt.XemPhim == null ||
               dt.NGheNHac == null ||
               dt.ThoiDiemRaMat == null
              )
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    dt.LoaiSanPham = false;
                    dt.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);

                    db.chi_tiet_Dien_Thoai.Add(dt);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = dt.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        public ActionResult DongHoCongNghe(chi_tiet_Dong_Ho_CongNghe cn)//
        {
            if (cn.mau_Sac == null ||
                cn.man_hinh == null ||
                cn.congNgheManHinh == null ||
                cn.doPhanGiai == null ||
                cn.duongKinhMat == null ||
                cn.cpu == null ||
                cn.boNhoTrong == null ||
                cn.HeDieuHanh == null ||
                cn.ketNoiHeDieuHanh == null ||
                cn.congSac == null ||
                cn.ThoiGianSuDungPin == null ||
                cn.thoiGianSac == null ||
                cn.dungLuongPin == null ||
                cn.theoDoiSucKhoe == null ||
                cn.HienThiThongBao == null ||
                cn.TienIchKhac == null ||
                cn.ketnoi == null ||
                cn.cammera == null ||
                cn.dodaiDay == null ||
                cn.doRongDay == null ||
                cn.chatlieuday == null ||
                cn.daycoThethaoroi == null ||
                cn.chatlieukhungvien == null ||
                cn.ngonNgu == null ||
                cn.khichThuoc == null ||
                cn.trongLuong == null
                )
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    cn.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_Dong_Ho_CongNghe.Add(cn);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = cn.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        public ActionResult DongHoThoiTrang(chi_tiet_DongHoThoiTrang tt)//
        {
            if (tt.loaimay == null ||
                tt.duongKinhmat == null ||
                tt.chatLieuMatKinh == null ||
                tt.chatLieuKhungVien == null ||
                tt.chongxuoc == null ||
                tt.dodayMat == null ||
                tt.chatLieuDay == null ||
                tt.tienIch == null ||
                tt.doRongDay == null ||
                tt.NguonNangLuong == null ||
                tt.ThoiGianSuDungPin == null ||
                tt.DoiTuongSuDung == null ||
                tt.ThuongHieu == null ||
                tt.noiSanXuat == null ||
                tt.ThoiDiemRaMat == null
                )
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    tt.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_DongHoThoiTrang.Add(tt);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = tt.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        public ActionResult MayTinh(chi_tiet_May_Tinh mt)//
        {
            if (mt.cpu == null ||
                mt.loaiCPU == null ||
                mt.tocdoToida == null ||
                mt.tocdocpu == null ||
                mt.loaiRam == null ||
                mt.tocDoBusRam == null ||
                mt.hoTroRamToiDa == null ||
                mt.Ram == null ||
                mt.OCung == null ||
                mt.kichthuocManHinh == null ||
                mt.DoPhanGiai == null ||
                mt.CongNgheManHinh == null ||
                mt.ManHinhCamUng == null ||
                mt.ThietKeCard == null ||
                mt.cardDoHoa == null ||
                mt.CongNgheAmThanh == null ||
                mt.congGiaoTiep == null ||
                mt.ketnoiKhongday == null ||
                mt.kheDocTheNho == null ||
                mt.OdiaQuang == null ||
                mt.WebCam == null ||
                mt.TinhNangKhac == null ||
                mt.DenBanPhm == null ||
                mt.pin == null ||
                mt.thongTinPhin == null ||
                mt.HeDieuHanh == null ||
                mt.KichThuoc == null ||
                mt.TrongLuong == null ||
                mt.ChatLieu == null ||
                mt.ThoiDiemRaMat == null
                )
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    mt.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_May_Tinh.Add(mt);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = mt.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        public ActionResult OpLung(chi_tiet_PhuKien_OpLung ol)//
        {
            if (ol.DongMay == null ||
                ol.chatLieu == null
                )
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    ol.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_PhuKien_OpLung.Add(ol);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = ol.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }

        }
        public ActionResult Pin(chi_tiet_PhuKien_PIN pi)//
        {
            if (pi.HieuXuatXac == null ||
                pi.thoiGianXac == null ||
                pi.dungluong == null ||
                pi.nguonvao == null ||
                pi.loiPin == null ||
                pi.congnghe == null ||
                pi.tienich == null ||
                pi.trongLuong == null ||
                pi.thuongHieu == null ||
                pi.NguonGoc == null
                )
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    pi.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_PhuKien_PIN.Add(pi);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = pi.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        public ActionResult TaiNghe(chi_tiet_PhuKien_tainghe tn)//
        {
            if (tn.chungLoai == 0)
            {
                ModelState.AddModelError("", "Phải chọn ô loại sản phẩm");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    tn.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_PhuKien_tainghe.Add(tn);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = tn.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        public ActionResult TheCao(chi_tiet_The_cao tc)//
        {            
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    tc.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_The_cao.Add(tc);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = tc.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }           
        }
        public ActionResult ThietBiMang(chi_tiet_PhuKien_ThietBiMang tbm)//
        {
            if (tbm.loai==0)
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    tbm.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_PhuKien_ThietBiMang.Add(tbm);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = tbm.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        public ActionResult ThietBiNho(chi_tiet_PhuKien_ThietBiNho tbn)//
        {
            if (tbn.loai == 0 )
            {
                ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                return View();
            }
            else
            {
                try
                {
                    Login taikhoanDT = (Login)Session[SessionLogin.sec];
                    tbn.sanpham = Convert.ToInt32(((SaveNewProduct)Session[taikhoanDT.taiKhoan]).maSanPham);
                    db.chi_tiet_PhuKien_ThietBiNho.Add(tbn);
                    db.SaveChanges();
                    return RedirectToAction("ChiTietSanPham", "Product", new { area = "", id = tbn.sanpham });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Điền Đầy đủ thông tin");
                    return View();
                }
            }
        }
        [HttpPost]
        public string loadAnh(HttpPostedFileBase fileeeee)
        {
            fileeeee.SaveAs(Server.MapPath("~/Content/IMG/" + fileeeee.FileName));
            return "/Content/IMG/" + fileeeee.FileName;
        }
    }
}