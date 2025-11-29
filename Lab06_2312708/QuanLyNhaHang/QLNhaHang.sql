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

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Role](
        [RoleID] [int] IDENTITY(1,1) NOT NULL,
        [RoleName] [nvarchar](50) NOT NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleID] ASC)
    )
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Account](
        [AccountID] [int] IDENTITY(1,1) NOT NULL,
        [MaNV] [int] NOT NULL,
        [Username] [varchar](50) NOT NULL,
        [Password] [varchar](255) NOT NULL,
        [RoleID] [int] NOT NULL,
        [IsActive] [bit] NOT NULL DEFAULT 1,
        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
        CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountID] ASC),
        CONSTRAINT [UK_Account_Username] UNIQUE ([Username]),
        CONSTRAINT [UK_Account_MaNV] UNIQUE ([MaNV]),
        CONSTRAINT [FK_Account_NhanVien] FOREIGN KEY([MaNV]) REFERENCES [dbo].[NhanVien] ([MaNV]),
        CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleID]) REFERENCES [dbo].[Role] ([RoleID])
    )
END
GO

INSERT INTO [dbo].[Role] ([RoleName]) VALUES (N'Quản lý')
INSERT INTO [dbo].[Role] ([RoleName]) VALUES (N'Nhân viên')
INSERT INTO [dbo].[Role] ([RoleName]) VALUES (N'Thu ngân')
GO

CREATE PROCEDURE [dbo].[Role_GetAll]
AS
BEGIN
    SELECT * FROM [Role]
END
GO

CREATE PROCEDURE [dbo].[Role_Insert]
    @RoleName NVARCHAR(50)
AS
BEGIN
    INSERT INTO [Role] ([RoleName]) VALUES (@RoleName)
    SELECT SCOPE_IDENTITY() AS RoleID
END
GO

CREATE PROCEDURE [dbo].[Role_Delete]
    @RoleID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [Account] WHERE RoleID = @RoleID)
    BEGIN
        DELETE FROM [Role] WHERE RoleID = @RoleID
        SELECT 1 AS Success
    END
    ELSE
    BEGIN
        SELECT 0 AS Success
    END
END
GO

CREATE PROCEDURE [dbo].[Account_GetAll]
AS
BEGIN
    SELECT a.*, nv.TenNV, nv.GioiTinh, nv.SDT, r.RoleName
    FROM [Account] a
    INNER JOIN [NhanVien] nv ON a.MaNV = nv.MaNV
    INNER JOIN [Role] r ON a.RoleID = r.RoleID
    WHERE a.IsActive = 1
END
GO

CREATE PROCEDURE [dbo].[Account_Login]
    @Username VARCHAR(50),
    @Password VARCHAR(255)
AS
BEGIN
    SELECT a.AccountID, a.MaNV, a.Username, a.RoleID, r.RoleName, nv.TenNV
    FROM [Account] a
    INNER JOIN [Role] r ON a.RoleID = r.RoleID
    INNER JOIN [NhanVien] nv ON a.MaNV = nv.MaNV
    WHERE a.Username = @Username AND a.Password = @Password AND a.IsActive = 1
END
GO

CREATE PROCEDURE [dbo].[Account_Register]
    @MaNV INT,
    @Username VARCHAR(50),
    @Password VARCHAR(255),
    @RoleID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [Account] WHERE Username = @Username)
    BEGIN
        SELECT -1 AS Result
        RETURN
    END

    IF EXISTS (SELECT 1 FROM [Account] WHERE MaNV = @MaNV)
    BEGIN
        SELECT -2 AS Result
        RETURN
    END
    
    INSERT INTO [Account] ([MaNV], [Username], [Password], [RoleID])
    VALUES (@MaNV, @Username, @Password, @RoleID)
    
    SELECT SCOPE_IDENTITY() AS Result
END
GO

CREATE PROCEDURE [dbo].[Account_Update]
    @MaNV INT,
    @Username VARCHAR(50),
    @Password VARCHAR(255),
    @RoleID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [Account] WHERE Username = @Username AND MaNV != @MaNV)
    BEGIN
        SELECT -1 AS Result
        RETURN
    END
    
    IF EXISTS (SELECT 1 FROM [Account] WHERE MaNV = @MaNV)
    BEGIN
        UPDATE [Account]
        SET Username = @Username,
            Password = @Password,
            RoleID = @RoleID
        WHERE MaNV = @MaNV
        
        SELECT 1 AS Result
    END
    ELSE
    BEGIN
        INSERT INTO [Account] ([MaNV], [Username], [Password], [RoleID])
        VALUES (@MaNV, @Username, @Password, @RoleID)
        
        SELECT 2 AS Result
    END
END
GO

CREATE PROCEDURE [dbo].[Account_Delete]
    @MaNV INT
AS
BEGIN
    UPDATE [Account]
    SET IsActive = 0
    WHERE MaNV = @MaNV
    
    SELECT 1 AS Result
END
GO

CREATE PROCEDURE [dbo].[Account_GetByMaNV]
    @MaNV INT
AS
BEGIN
    SELECT a.*, r.RoleName
    FROM [Account] a
    INNER JOIN [Role] r ON a.RoleID = r.RoleID
    WHERE a.MaNV = @MaNV AND a.IsActive = 1
END
GO
