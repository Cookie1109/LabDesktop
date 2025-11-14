USE [QuanLyNhaHang]
GO

-- Tạo bảng Role (Chức vụ)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Role](
        [RoleID] [int] IDENTITY(1,1) NOT NULL,
        [RoleName] [nvarchar](50) NOT NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleID] ASC)
    )
END
GO

-- Tạo bảng Account (Tài khoản - 1 tài khoản = 1 nhân viên)
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

-- Thêm dữ liệu mẫu cho bảng Role
INSERT INTO [dbo].[Role] ([RoleName]) VALUES (N'Quản lý')
INSERT INTO [dbo].[Role] ([RoleName]) VALUES (N'Nhân viên')
INSERT INTO [dbo].[Role] ([RoleName]) VALUES (N'Thu ngân')
GO

-- Stored Procedures cho Role
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
    -- Kiểm tra xem có tài khoản nào đang sử dụng role này không
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

-- Stored Procedures cho Account
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
    -- Kiểm tra username đã tồn tại chưa
    IF EXISTS (SELECT 1 FROM [Account] WHERE Username = @Username)
    BEGIN
        SELECT -1 AS Result -- Username đã tồn tại
        RETURN
    END
    
    -- Kiểm tra MaNV đã có tài khoản chưa
    IF EXISTS (SELECT 1 FROM [Account] WHERE MaNV = @MaNV)
    BEGIN
        SELECT -2 AS Result -- Nhân viên này đã có tài khoản
        RETURN
    END
    
    INSERT INTO [Account] ([MaNV], [Username], [Password], [RoleID])
    VALUES (@MaNV, @Username, @Password, @RoleID)
    
    SELECT SCOPE_IDENTITY() AS Result -- Trả về AccountID
END
GO

CREATE PROCEDURE [dbo].[Account_Update]
    @MaNV INT,
    @Username VARCHAR(50),
    @Password VARCHAR(255),
    @RoleID INT
AS
BEGIN
    -- Kiểm tra username có bị trùng với tài khoản khác không
    IF EXISTS (SELECT 1 FROM [Account] WHERE Username = @Username AND MaNV != @MaNV)
    BEGIN
        SELECT -1 AS Result -- Username đã tồn tại cho nhân viên khác
        RETURN
    END
    
    -- Nếu nhân viên đã có tài khoản thì update
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
        -- Nếu chưa có thì insert
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
    -- Đánh dấu là không hoạt động (soft delete)
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

-- Cập nhật bảng NhanVien - loại bỏ TaiKhoan và MatKhau vì đã có trong bảng Account
-- (Giữ lại để tương thích với dữ liệu cũ, nhưng không dùng nữa)
GO
