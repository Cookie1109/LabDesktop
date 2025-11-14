USE [QuanLyNhaHang]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 10/10/2025 10:57:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[MaBan] [int] IDENTITY(1,1) NOT NULL,
	[SoTang] [int] NOT NULL,
	[TenBan] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Ban] PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/10/2025 10:57:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [int] NOT NULL,
	[MaMon] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](18, 0) NOT NULL,
	[ThanhTien] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonThanhToan]    Script Date: 10/10/2025 10:57:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonThanhToan](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[TongTien] [decimal](18, 0) NOT NULL,
	[GiamGia] [int] NOT NULL,
	[ThanhToan] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_HoaDonThanhToan] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiMonAn]    Script Date: 10/10/2025 10:57:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMonAn](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nchar](20) NOT NULL,
	[Loai] [nchar](15) NOT NULL,
 CONSTRAINT [PK_LoaiMonAn] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 10/10/2025 10:57:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[MaMon] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nchar](25) NOT NULL,
	[MaLoai] [int] NOT NULL,
	[DonGia] [decimal](18, 0) NOT NULL,
	[DonViTinh] [nchar](10) NOT NULL,
	[GhiChu] [nchar](50) NULL,
 CONSTRAINT [PK_MonAn] PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/10/2025 10:57:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nchar](50) NOT NULL,
	[GioiTinh] [nchar](5) NOT NULL,
	[SDT] [char](10) NOT NULL,
	[ChucVu] [nchar](10) NOT NULL,
	[TaiKhoan] [char](10) NOT NULL,
	[MatKhau] [char](10) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDonThanhToan] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDonThanhToan] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDonThanhToan]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_MonAn] FOREIGN KEY([MaMon])
REFERENCES [dbo].[MonAn] ([MaMon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_MonAn]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_NhanVien]
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD  CONSTRAINT [FK_MonAn_LoaiMonAn] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiMonAn] ([MaLoai])
GO
ALTER TABLE [dbo].[MonAn] CHECK CONSTRAINT [FK_MonAn_LoaiMonAn]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]
ADD MaBan INT NOT NULL
DEFAULT 1;
GO
ALTER TABLE [dbo].[HoaDonThanhToan]
ADD CONSTRAINT FK_HoaDonThanhToan_Ban
FOREIGN KEY (MaBan) REFERENCES [dbo].[Ban] (MaBan);
GO
ALTER TABLE [dbo].[Ban]
ALTER COLUMN [TenBan] NVARCHAR(10) NOT NULL;
GO
ALTER TABLE [dbo].[NhanVien]
ALTER COLUMN [TenNV] NVARCHAR(50) NOT NULL;
GO
ALTER TABLE [dbo].[LoaiMonAn]
ALTER COLUMN [TenLoai] NVARCHAR(50) NOT NULL;
GO
ALTER TABLE [dbo].[MonAn]
ALTER COLUMN [GhiChu] NVARCHAR(100) NOT NULL;
GO
/*SELECT ALL*/
create proc [dbo].[LoaiMonAn_GetAll]
as
begin
	select * from LoaiMonAn
end
go
create proc [dbo].[Ban_GetAll]
as
begin
	select * from Ban
end
go
create proc [dbo].[ChiTietHoaDon_GetAll]
as
begin
	select * from ChiTietHoaDon
end
go
create proc [dbo].[HoaDonThanhToan_GetAll]
as
begin
	select * from HoaDonThanhToan
end
go
create proc [dbo].[MonAn_GetAll]
as
begin
	select * from MonAn
end
go
create PROCEDURE [dbo].[MonAn_GetByLoai]
    @MaLoai INT
AS
BEGIN
    SELECT * FROM MonAn 
    WHERE MaLoai = @MaLoai;
END
GO
create proc [dbo].[NhanVien_GetAll]
as
begin
	select * from NhanVien
end
go
ALTER TABLE [dbo].[MonAn]
ALTER COLUMN [TenMon] NVARCHAR(100) NOT NULL;
GO

/*INSERT*/
create proc [dbo].[Ban_INSERT]
@SoTang int, @TenBan nvarchar(10)
as
begin
	insert into Ban(SoTang,TenBan) values (@SoTang,@TenBan)
end
go
create proc [dbo].[ChiTietHoaDon_INSERT]
@MaHD int, @MaMon int, @SoLuong int, @DonGia decimal(18,0), @ThanhTien decimal(18,0)
as
begin
	if not exists (select MaHD from ChiTietHoaDon where MaHD=@MaHD and MaMon=@MaMon)
	begin
		insert into ChiTietHoaDon(MaHD,MaMon, SoLuong, DonGia, ThanhTien) values (@MaHD,@MaMon,@SoLuong,@DonGia,@ThanhTien)
	end
end
go
create proc [dbo].[HoaDonThanhToan_INSERT]
@MaNV int, @NgayLap datetime, @TongTien decimal(18,0), @GiamGia int, @ThanhToan decimal(18,0), @MaBan int
as
begin
	insert into HoaDonThanhToan(MaNV,NgayLap,TongTien,GiamGia,ThanhToan,MaBan) 
	values (@MaNV,@NgayLap,@TongTien,@GiamGia,@ThanhToan,@MaBan)

    -- Return the newly inserted MaHD
    SELECT SCOPE_IDENTITY() as MaHD
end
go
create proc [dbo].[LoaiMonAn_INSERT]
@TenLoai nvarchar(50), @Loai nchar(15)
as
begin
	if not exists (select TenLoai from LoaiMonAn where TenLoai=@TenLoai and Loai=@Loai)
	begin
		insert into LoaiMonAn(TenLoai,Loai) values (@TenLoai,@Loai)
	end
end
go
create proc [dbo].[MonAn_INSERT]
@TenMon nvarchar(100), @MaLoai int, @DonGia decimal(18,0), @DonViTinh nchar(10), @GhiChu nchar(50)=null
as
begin
	if not exists (select TenMon from MonAn where TenMon=@TenMon and MaLoai=@MaLoai)
	begin
		insert into MonAn(TenMon,MaLoai,DonGia,DonViTinh,GhiChu) values (@TenMon,@MaLoai,@DonGia,@DonViTinh,@GhiChu)
	end
end
go
create proc [dbo].[NhanVien_INSERT]
@TenNV nvarchar(50), @GioiTinh nchar(5), @SDT char(10), @ChucVu nchar(10), @TaiKhoan char(10), @MatKhau char(10)
as
begin
	if not exists (select TenNV from NhanVien where TenNV=@TenNV and SDT=@SDT)
	begin
		insert into NhanVien(TenNV,GioiTinh,SDT,ChucVu,TaiKhoan,MatKhau) values (@TenNV,@GioiTinh,@SDT,@ChucVu,@TaiKhoan,@MatKhau)
	end
end
go

/*DELETE*/
create proc [dbo].[Ban_Delete]
@MaBan int
as
begin
	delete from Ban where MaBan=@MaBan
end
go
create proc [dbo].[ChiTietHoaDon_Delete]
@MaHD int, @MaMon int
as
begin
	delete from ChiTietHoaDon where MaHD=@MaHD and MaMon=@MaMon
end
go
create proc [dbo].[HoaDonThanhToan_Delete]
@MaHD int
as
begin
	delete from HoaDonThanhToan where MaHD=@MaHD
end
go
create proc [dbo].[LoaiMonAn_Delete]
@MaLoai int
as
begin
	delete from LoaiMonAn where MaLoai=@MaLoai
end
go
create proc [dbo].[MonAn_Delete]
@MaMon int, @MaLoai int
as
begin
	delete from MonAn where MaMon=@MaMon and MaLoai=@MaLoai
end
go
create proc [dbo].[NhanVien_Delete]
@MaNV int
as
begin
	delete from NhanVien where MaNV=@MaNV
end
go

/*UPDATE*/
create proc [dbo].[LoaiMonAn_Update]
@MaLoai int, @TenLoai nvarchar(50), @Loai nchar(15)
as
begin
	update LoaiMonAn set TenLoai=@TenLoai, Loai=@Loai where MaLoai=@MaLoai
end
go
create proc [dbo].[MonAn_Update]
@MaMon int, @TenMon nvarchar(100), @DonGia decimal(18,0), @DonViTinh nvarchar(20), @GhiChu nvarchar(100)
as
begin
	update MonAn set TenMon=@TenMon, DonGia=@DonGia, DonViTinh=@DonViTinh, GhiChu=@GhiChu where MaMon=@MaMon
end
go

/*STORED PROCEDURES FOR FILTERING HOADON*/
create proc [dbo].[HoaDonThanhToan_GetByDate]
@Ngay date
as
begin
	select * from HoaDonThanhToan where CAST(NgayLap AS DATE) = @Ngay order by NgayLap desc
end
go

create proc [dbo].[HoaDonThanhToan_GetByMonth]
@Thang int, @Nam int
as
begin
	select * from HoaDonThanhToan where MONTH(NgayLap) = @Thang and YEAR(NgayLap) = @Nam order by NgayLap desc
end
go

create proc [dbo].[HoaDonThanhToan_GetByYear]
@Nam int
as
begin
	select * from HoaDonThanhToan where YEAR(NgayLap) = @Nam order by NgayLap desc
end
go

ALTER TABLE Ban
ADD TrangThai INT

SELECT MaNV, TenNV, ChucVu FROM NhanVien