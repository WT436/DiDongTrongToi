 create database bandiDong
 go
 use bandiDong
 go
  create  table acc(
					taikhoan varchar(50) primary key ,
					matkhau varchar(100) not null,
					hask varchar(30) not null,
					phanQuyen int not null default 0 check (phanQuyen>-1 and phanQuyen<3),
					gmail varchar(50) not null,
					ngaytao date default getdate(),
					daxoa bit default 0
)
go
create table thongTin(
                     id int identity(1,1) primary key ,
					 avatar varchar(50) not null,
					 ten nvarchar(30) not null,
					 tuoi int check(tuoi>0 and tuoi<100) not null ,
					 diachi nvarchar(200) not null,
					 sdt int not null,
					 daxoa  bit default 0,
					 ngayCapNhat date default getdate(),
					 taikhoan varchar(50) foreign key references acc(taikhoan)
)
go
create table nhacungCap(
						id int identity(1,1) primary key ,
						idncc int not null foreign key references thongTin(id),
						Avatar varchar(100) not null,
						TenTrang nvarchar(30) not null,
						thoi_Gian_vao date default getdate() not null,
						da_Xoa bit default 0
)
go
create table Danh_Gia_Trang(
                           id int identity(1,1)  primary key,
						   so_Sao int check(so_Sao <6 and so_Sao>0) not null default 3,
						   Theo_doi bit default 0 not null,
						   nha_Cung_Cap int foreign key references nhacungCap(id),
						   acc  varchar(50) foreign key references acc(taikhoan),
						   da_Xoa bit default 0
)
go
create table Danh_Muc_Theo_Chu_De(
							id int identity(1,1) primary key ,
							ten_chu_de nvarchar(30) not null,
							da_xoa bit default 0 not null
)
go
create table Danh_Muc_Theo_Chung_loai(
							id int identity(1,1) primary key ,
							ten_chung_Loai nvarchar(30) not null,
							Danh_Muc_Theo_Chu_De int foreign key references Danh_Muc_Theo_Chu_De(id),
							da_xoa bit default 0 not null
)
go
create table anhsanpham(
						id int identity(1,1) primary key ,
                        anh1 varchar(100) not null,
						anh2 varchar(100) not null,
						anh3 varchar(100) not null,
						anh5 varchar(100) not null,
						anh6 varchar(100) not null,
						anh7 varchar(100) not null,
)
go
create table sanpham(
					id int identity(1,1) primary key ,
					ten nvarchar(100) not null,				
					gia money not null,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  not null,					
					anhsanpham int foreign key references anhsanpham(id),
					Danh_Muc_Theo_Chung_loai int foreign key references Danh_Muc_Theo_Chung_loai(id),
					nhacungCap  int foreign key references nhacungCap(id),
					daxoa bit default 0,

)
go
create table chi_tiet_Dien_Thoai(
                    id int identity(1,1) primary key ,
					mau_Sac nvarchar(10) not null,
					man_hinh nvarchar(100) not null,
					he_dieu_hanh varchar(30) not null,
					camera_Truoc nvarchar(50) not null,
					camera_Sau nvarchar(50) not null,
					Loi_san_Pham nvarchar(100) not null,
					di_Kem nvarchar(100) not null,
					ram nvarchar(50) not null,
					cpu nvarchar(50) not null,
					bo_nho int  not null,
					the_nho nvarchar(50) not null,
					sim nvarchar(50) not null,
					doPhanGiai nvarchar(100) not null,
					Man_Hinh_rong nvarchar(100) not null,
				    KinhCamUng nvarchar(100) not null,										
					chipset varchar(30) not null,
					TocDocpu varchar(30) not null,
					GPU varchar(30) not null,									
					DoPhanGiaiCammeraTruoc varchar(30) not null,
					VideoCall varchar(30) not null,
					ThongTinKhacCamMera varchar(30) not null,					
					DoPhanGiaiCamerasau varchar(30) not null,
					quayPhim varchar(30) not null,
					denFlash varchar(30) not null,
					chupAnhNangCao varchar(30) not null,									
					hoTroMang nvarchar(50) not null,
					wifi nvarchar(50) not null,
					GPS nvarchar(50) not null,
					bluetooth nvarchar(50) not null,
					congKetNoi nvarchar(50) not null,
					JackTaiNGhe nvarchar(50) not null,
					ketNoiKhac nvarchar(50) not null,
					thietKe nvarchar(50) not null,
					ChatLieu nvarchar(50) not null,
					KichThuoc nvarchar(50) not null,
					TrongLuong nvarchar(50) not null,
					LoaiPin nvarchar(50) not null,
					CongNghePin nvarchar(50) not null,
					dung_luong_Pin int  not null,
					BaoMat nvarchar(50) not null,
					TinhNangNoiBat nvarchar(50) not null,
					GhiAm nvarchar(50) not null,
					Radio nvarchar(50) not null,
					XemPhim nvarchar(50) not null,
					NGheNHac nvarchar(50) not null,
					ThoiDiemRaMat nvarchar(50) not null,
					LoaiSanPham bit not null ,--1 la dienthoai 0 laf tablet
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_May_Tinh(--
                    id int identity(1,1) primary key ,
					cpu nvarchar(50) not null,
					loaiCPU nvarchar(50) not null,
					tocdocpu int ,
					tocdoToida int ,
					loaiRam nvarchar(50) not null,
					tocDoBusRam nvarchar(50) not null,
					hoTroRamToiDa nvarchar(50) not null,
					Ram nvarchar(50) not null,
					OCung nvarchar(50) not null,
					kichthuocManHinh nvarchar(50) not null,
					DoPhanGiai nvarchar(50) not null,
					CongNgheManHinh nvarchar(50) not null,
					ManHinhCamUng bit ,
					ThietKeCard nvarchar(50) not null,
					cardDoHoa nvarchar(50) not null,
					CongNgheAmThanh nvarchar(50) not null,
					congGiaoTiep nvarchar(50) not null,
					ketnoiKhongday nvarchar(50) not null,
					kheDocTheNho nvarchar(50) not null,
					OdiaQuang nvarchar(50) not null,
					WebCam nvarchar(50) not null,
					TinhNangKhac nvarchar(50) not null,
					DenBanPhm nvarchar(50) not null,
					pin nvarchar(50) not null,
					thongTinPhin nvarchar(50) not null,
					HeDieuHanh nvarchar(50) not null,
					KichThuoc nvarchar(50) not null,
					TrongLuong nvarchar(50) not null,
					ChatLieu nvarchar(50) not null,
					ThoiDiemRaMat nvarchar(50) not null,
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_Dong_Ho_CongNghe(--
                    id int identity(1,1) primary key ,
					mau_Sac nvarchar(10) not null,
					man_hinh nvarchar(100) not null,
					congNgheManHinh nvarchar(30),
					KichThucManHinh varchar(30),
					doPhanGiai varchar(30),
					duongKinhMat int,
					cpu varchar(30),
					boNhoTrong varchar(30),
					HeDieuHanh varchar(30),
					ketNoiHeDieuHanh varchar(30),
					congSac varchar(30),
					ThoiGianSuDungPin int,
					thoiGianSac int,
					dungLuongPin int,
					theoDoiSucKhoe varchar(50),
					HienThiThongBao varchar(50),
					TienIchKhac varchar(50),
					ketnoi varchar(30),
					cammera varchar(30),
					dodaiDay int ,
					doRongDay int,
					chatlieuday varchar(30),
					daycoThethaoroi bit,
					chatlieukhungvien varchar(30),
					ngonNgu varchar(30),
					khichThuoc varchar(30),
					trongLuong int ,
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_DongHoThoiTrang(
                    id int identity(1,1) primary key ,
					loaimay nvarchar(30),
					duongKinhmat int ,
					chatLieuMatKinh nvarchar(30),
					chatLieuKhungVien nvarchar(30),
					chongxuoc nvarchar(30),
					dodayMat int ,
					chatLieuDay nvarchar(30),
					tienIch nvarchar(30),
					doRongDay int , 
					NguonNangLuong nvarchar(30),
					ThoiGianSuDungPin nvarchar(30),
					DoiTuongSuDung  nvarchar(30),
					ThuongHieu nvarchar(30),
					noiSanXuat nvarchar(50),
					ThoiDiemRaMat nvarchar(50) not null,
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_The_cao(--
                    id int identity(1,1) primary key ,
					SimOrThe bit check(SimOrThe>0 and SimOrThe<2) not null,
					sdt dec(12,0),
					maThe dec(15,0),
					seri dec(15,0),
					menhGia money,
					NhaMang varchar(30) not null,
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_PhuKien_tainghe(--
                    id int identity(1,1) primary key ,
					chungLoai int  check(chungLoai>0 and chungLoai<5) not null,
					TuongThich nvarchar(50),
					congXuat int,
					cachKetNoi nvarchar(50),
					PhimDieuKhien nvarchar(50),
					TinhNangKhac nvarchar(50),
					KhoangCachBluetooth int,
					kichThuocSieuTram nvarchar(50),
					KichThuocVeTinh nvarchar(50),
					trongLuong int,
					thuongHieu nvarchar(50),
					XuatSu nvarchar(50),
					BoBanHangChuan nvarchar(50),
					CongSac nvarchar(50),
					ThoiGianSuDung int,
					KetNoiCungLuc int,
					ThoiGianXacDay int,
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_PhuKien_PIN(--
                    id int identity(1,1) primary key ,
					HieuXuatXac int ,
					dungluong int , 
					thoiGianXac int ,
					nguonvao nvarchar(30),
					loiPin  nvarchar(30),
					congnghe  nvarchar(30),
					tienich  nvarchar(30),
					trongLuong int ,
					thuongHieu  nvarchar(30),
					NguonGoc  nvarchar(30),
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_PhuKien_CapSac(--
                    id int identity(1,1) primary key ,
					loai int  check(loai>0 and loai <4),
					doDaiDay int ,
					chucNang nvarchar(30),
					dauvao nvarchar(30),
					dauRa nvarchar(30),
					congNghe nvarchar(30),
					tienIch nvarchar(30),
					ThuongHieu nvarchar(30),
					NguonGoc nvarchar(30),
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_PhuKien_Cammera(--
                    id int identity(1,1) primary key ,
					dophangiai  nvarchar(30),
					nguondienvao int,
					tamNhinHongNgoai int ,
					hoTroTheNho  nvarchar(30),
					hoTroThietBi  nvarchar(30),
					khichthuoc  nvarchar(30),
					trongluong int ,
					nhietdoHoatDong  nvarchar(30),
					thuongHieu  nvarchar(30),
					nguonGoc  nvarchar(30),
					PhuKien  nvarchar(100),
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_PhuKien_ThietBiMang(--
                    id int identity(1,1) primary key ,
					loai int  check(loai>0 and loai <4),
					tocDo int , 
					bangTan int ,
					cacCongKetNoi nvarchar(50),
					DenBaoHieu nvarchar(30),
					soAngTen nvarchar(30),
					TruyCapToiDa int ,
					DoPhuSong int ,
					NutBamHoTro nvarchar(30),
					mauSac nvarchar(30),
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_PhuKien_OpLung(--
                    id int identity(1,1) primary key ,
					DongMay nvarchar(50),
					chatLieu nvarchar(50),
					sanpham int foreign key references sanpham(id)
)
go
create table chi_tiet_PhuKien_ThietBiNho(--
                    id int identity(1,1) primary key ,
					loai int check(loai>0 and loai <3) not null,
					cong  nvarchar(5),
					dungluong int ,
					tocdodoc int ,
					tocdoghi int ,
					kichthuoc int ,
					trongluong int ,
					noisanxuat  nvarchar(30),
					thuonghieu  nvarchar(30),
					sanpham int foreign key references sanpham(id)
)
go
create table magiamgia( 
					 id varchar(7) primary key ,
					 phan_Tram int check(phan_Tram>0 and phan_Tram<101) not null, 
					 chung bit default 0 not null,
					 rieng bit default 0 not null,
					 Ma_san_Pham int foreign key references sanpham(id),					 
					 ngay_Tao date default getdate() not null,
					 ngay_Het_Han date not null,
					 da_Xoa bit default 0 not null
)
go
create table BaiViet_LinhKien(
                      tag nvarchar(50) primary key,
					  noidung text not null,
					  anhsanpham int foreign key references anhsanpham(id),
					  da_Xoa bit not null default 0
)
go
create table Tra_Gop(
                    id int primary key identity(1,1),
					Total_money money not null,
					money_DaThanhToan money not null,
					percent_Number int check(percent_Number>0 and percent_Number<100) not null,
					time_Begin date  not null,
					time_update date  default getdate() not null,
					sotienLanLuot nvarchar(200) not null,
					time_end date  not null,
					sanpham int foreign key references anhsanpham(id),
					acc  varchar(50) foreign key references acc(taikhoan),
					da_xoa bit default 0 not null
)
go
create table Gioi_Thieu_product(
                      tag nvarchar(50) primary key,
					  noidung text not null,
					  sanpham int foreign key references sanpham(id),
					  anhsanpham int foreign key references anhsanpham(id),
					  da_Xoa bit not null default 0
)
go
create table hang_cho(
					 id int identity(1,1) primary key,
					 giamgia varchar(7) foreign key references magiamgia(id),
					 sanpham int foreign key references sanpham(id),
				 	 acc  varchar(50) foreign key references acc(taikhoan),
				 	 soLuong int check(soLuong>0) not null,
					 daXoa bit default 0 not null
					 
)
go
create table Dat_Hang(
              id int identity(1,1) primary key,
			  giamgia varchar(7) foreign key references magiamgia(id),
			  sanpham int foreign key references sanpham(id),
			  acc  varchar(50) foreign key references acc(taikhoan),
			  soLuong int check(soLuong>0) not null,
			  daXoa bit default 0 not null,
			  ngaydat date default  getdate() not null,
			  NgayGiao date default  getdate() not null,
			  daGiao bit default 0 not null,
			  ChuanBi bit default 0 not null,
			  VanChuyen bit default 0 not null
)
go
create table Bao_Hanh(
              id int identity(1,1) primary key,
			  giamgia varchar(7) foreign key references magiamgia(id),
			  sanpham int foreign key references sanpham(id),
			  acc  varchar(50) foreign key references acc(taikhoan),
			  soLuong int check(soLuong>0) not null,
			  daXoa bit default 0 not null,
			  ngay_begin_baoHanh date default getdate() not null,
			  time_baoHanh date not null
) 
go
create table danh_gia(
                    id int identity(1,1) primary key ,
					noidung nvarchar(max) not null,
					soSao int check(soSao>0 and soSao<5) default 3,
					sanpham int foreign key references sanpham(id),
					acc  varchar(50) foreign key references acc(taikhoan),
					thoiGian date default getdate()
)
go
create table rep_danh_Gia(
                    id int identity(1,1) primary key ,
					noidung nvarchar(max) not null,
					acc  varchar(50) foreign key references acc(taikhoan),
					thoiGian date default getdate(),
					danhgia int foreign key references danh_gia(id)
)
go
create table like_DanhGia(
                         id int identity(1,1) primary key ,
					     _like bit  ,
						 dislike bit ,
					     acc  varchar(50) foreign key references acc(taikhoan),
					     thoiGian date default getdate(),
					     danhgia int foreign key references danh_gia(id)
)
go
create table like_Rep_danhGia(
                         id int identity(1,1) primary key ,
					     _like bit  ,
						 dislike bit ,
					     acc  varchar(50) foreign key references acc(taikhoan),
					     thoiGian date default getdate(),
					     like_DanhGia int foreign key references like_DanhGia(id)
)
---------------------------------------- veiw Lay ngau nhien 6 san pham va lay ngau nhien 20 san pham
create view V_LayNgauNhienSanPhamView
as
select top(20) id ,ten,gia,soLuong,soLuongconlai ,bao_hanh,anhsanpham ,Danh_Muc_Theo_Chung_loai  ,nhacungCap ,daxoa  
     FROM dbo.sanpham  ORDER BY NEWID()
--tạo mới một hàm để lấy sản phẩm ngẫu nhiên 
create function F_layNgauNhienSanPham(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamView
    
return
end
-----------------------------------------------------view lấy san phâm theo chủng loại
--DienThoai
create view V_LayNgauNhienSanPhamViewChungLoaiDienThoai
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id 
	  where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=1 ORDER BY NEWID()
go
create function F_layNgauNhienSanPhamChungLoaiDienThoai(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamViewChungLoaiDienThoai
    
return
end
--Tablet
create view V_LayNgauNhienSanPhamViewChungLoaiTablet
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id 
	  where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=2 ORDER BY NEWID()
go
create function F_layNgauNhienSanPhamChungLoaiTablet(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamViewChungLoaiTablet
    
return
end
--MayTinh
create view V_LayNgauNhienSanPhamViewChungLoaiMayTinh
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id 
	  where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=3 ORDER BY NEWID()
go
create function F_layNgauNhienSanPhamChungLoaiMayTinh(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamViewChungLoaiMayTinh
    
return
end
--PhuKien
create view V_LayNgauNhienSanPhamViewChungLoaiPhuKien
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id 
	  where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=4 ORDER BY NEWID()
go
create function F_layNgauNhienSanPhamChungLoaiPhuKien(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamViewChungLoaiPhuKien
    
return
end
--DongHo
create view V_LayNgauNhienSanPhamViewChungLoaiDongHo
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id 
	  where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=5 ORDER BY NEWID()
go
create function F_layNgauNhienSanPhamChungLoaiDongHo(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamViewChungLoaiDongHo
    
return
end
--SimThe
create view V_LayNgauNhienSanPhamViewChungLoaiSimThe
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id 
	  where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=6 ORDER BY NEWID()
go
create function F_layNgauNhienSanPhamChungLoaiSimThe(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamViewChungLoaiSimThe
    
return
end
-----------------------------------------------------------lay san pham noi bat nhat 4 sao hoac 5 sao
--chung
create view V_LaySanPhamNoiBatChung
as
    select top(10) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.danh_gia
	 on dbo.sanpham.id=dbo.danh_gia.sanpham
	  where danh_gia.soSao=4 or danh_gia.soSao=5 ORDER BY NEWID()
go
create function F_LaySanPhamNoiBatChung(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LaySanPhamNoiBatChung
    
return
end
--DienThoai
create view V_LaySanPhamNoiBatChungDienThoai
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id
	 inner join dbo.danh_gia
	 on dbo.sanpham.id=dbo.danh_gia.sanpham
	 where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=1 and danh_gia.soSao=4 or danh_gia.soSao=5 
	 ORDER BY NEWID()
go
create function F_LaySanPhamNoiBatChungDienThoai(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamViewChungLoaiDienThoai    
return
end
--tablet
create view V_LaySanPhamNoiBatChungtablet
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id
	 inner join dbo.danh_gia
	 on dbo.sanpham.id=dbo.danh_gia.sanpham
	 where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=2 and danh_gia.soSao=4 or danh_gia.soSao=5 
	 ORDER BY NEWID()
go
create function F_LaySanPhamNoiBatChungtablet(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LayNgauNhienSanPhamViewChungLoaiDienThoai    
return
end
--MayTinh
create view V_LaySanPhamNoiBatChungMayTinh
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id
	 inner join dbo.danh_gia
	 on dbo.sanpham.id=dbo.danh_gia.sanpham
	 where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=3 and danh_gia.soSao=4 or danh_gia.soSao=5 
	 ORDER BY NEWID()
go
create function F_LaySanPhamNoiBatChungMayTinh(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LaySanPhamNoiBatChungMayTinh   
return
end
--phukien
create view V_LaySanPhamNoiBatChungphukien
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id
	 inner join dbo.danh_gia
	 on dbo.sanpham.id=dbo.danh_gia.sanpham
	 where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=4 and danh_gia.soSao=4 or danh_gia.soSao=5 
	 ORDER BY NEWID()
go
create function F_LaySanPhamNoiBatChungphukien(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LaySanPhamNoiBatChungphukien   
return
end
--DongHo
create view V_LaySanPhamNoiBatChungDongHo
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id
	 inner join dbo.danh_gia
	 on dbo.sanpham.id=dbo.danh_gia.sanpham
	 where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=5 and danh_gia.soSao=4 or danh_gia.soSao=5 
	 ORDER BY NEWID()
go
create function F_LaySanPhamNoiBatChungDongHo(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LaySanPhamNoiBatChungDongHo 
return
end
--SimThe
create view V_LaySanPhamNoiBatChungSimThe
as
    select top(20) sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa  
     FROM dbo.sanpham inner join dbo.Danh_Muc_Theo_Chung_loai 
	 on dbo.sanpham.Danh_Muc_Theo_Chung_loai=dbo.Danh_Muc_Theo_Chung_loai.id
	 inner join dbo.danh_gia
	 on dbo.sanpham.id=dbo.danh_gia.sanpham
	 where dbo.Danh_Muc_Theo_Chung_loai.Danh_Muc_Theo_Chu_De=6 and danh_gia.soSao=4 or danh_gia.soSao=5 
	 ORDER BY NEWID()
go
create function F_LaySanPhamNoiBatChungSimThe(@so int)
returns @table table(id int ,
					ten nvarchar(100) ,				
					gia money ,
					soLuong int ,
					soLuongconlai int ,
					bao_hanh int  ,					
					anhsanpham int ,
					Danh_Muc_Theo_Chung_loai int ,
					nhacungCap  int ,
					daxoa bit )
as
begin
     insert into @table select top(@so) * from V_LaySanPhamNoiBatChungSimThe
return
end
---------------------------------------------------------------Lấy San Phẩm Giảm Giá Cao Nhất
create view V_layPhamGiamGiaCaoNhatChung
as
select top 1 sanpham.id ,
				sanpham.ten,sanpham.gia,
				sanpham.soLuong,
				sanpham.soLuongconlai ,
				sanpham.bao_hanh,
				sanpham.anhsanpham ,
				sanpham.Danh_Muc_Theo_Chung_loai  ,
				sanpham.nhacungCap ,sanpham.daxoa ,
				magiamgia.Ma_san_Pham,
				magiamgia.phan_Tram
				from sanpham inner join magiamgia on sanpham.id = magiamgia.Ma_san_Pham where magiamgia.da_Xoa= 0 and magiamgia.ngay_Het_Han>GETDATE() order by magiamgia.phan_Tram DESC 
--
--test các hàm trên 
select * from F_layNgauNhienSanPham(5)
select * from F_layNgauNhienSanPhamChungLoaiDienThoai(5)