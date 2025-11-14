use Lab08_Database
go

CREATE TABLE Role (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
)

CREATE TABLE Account (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    DisplayName NVARCHAR(100),
    RoleID INT NOT NULL,
    FOREIGN KEY (RoleID) REFERENCES Role(ID)
)

CREATE TABLE TableFood (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Status NVARCHAR(50)
)

CREATE TABLE Category (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
)

CREATE TABLE Food (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Unit NVARCHAR(50),
    Price INT NOT NULL,
    Notes NVARCHAR(500),
    CategoryID INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Category(ID)
)

CREATE TABLE Bill (
    ID INT PRIMARY KEY IDENTITY(1,1),
    DateCheckIn DATETIME NOT NULL DEFAULT GETDATE(),
    TableID INT NOT NULL,
    Status INT NOT NULL DEFAULT 0,
    FOREIGN KEY (TableID) REFERENCES TableFood(ID)
)

CREATE TABLE BillDetails (
    ID INT PRIMARY KEY IDENTITY(1,1),
    BillID INT NOT NULL,
    FoodID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (BillID) REFERENCES Bill(ID),
    FOREIGN KEY (FoodID) REFERENCES Food(ID)
)

CREATE TABLE RoleAccount (
    RoleID INT NOT NULL,
    AccountID INT NOT NULL,
    PRIMARY KEY (RoleID, AccountID),
    FOREIGN KEY (RoleID) REFERENCES Role(ID),
    FOREIGN KEY (AccountID) REFERENCES Account(ID)
)

CREATE TABLE Product (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price INT NOT NULL
)

INSERT INTO Category (Name) VALUES (N'Khai vị')
INSERT INTO Category (Name) VALUES (N'Món chính')
INSERT INTO Category (Name) VALUES (N'Tráng miệng')
INSERT INTO Category (Name) VALUES (N'Đồ uống')

INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Gỏi cuốn tôm thịt', N'Cuốn', 20000, N'3 cuốn/phần', 1)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Chả giò rế', N'Dĩa', 65000, N'6 cuốn/dĩa', 1)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Cơm chiên Dương Châu', N'Dĩa', 80000, N'Nhiều lạp xưởng', 2)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Phở bò tái nạm', N'Tô', 60000, N'Nhiều hành', 2)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Bò bít tết', N'Phần', 150000, N'Sốt tiêu đen', 2)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Cá lóc kho tộ', N'Tộ', 120000, N'Ăn kèm cơm trắng', 2)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Bánh flan', N'Cái', 25000, N'Caramel', 3)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Chè khúc bạch', N'Chén', 35000, N'Nhiều nhãn', 3)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Coca-Cola', N'Lon', 20000, N'Thêm đá', 4)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Nước cam vắt', N'Ly', 40000, N'Cam sành', 4)
INSERT INTO Food (Name, Unit, Price, Notes, CategoryID) VALUES (N'Cà phê đen đá', N'Ly', 30000, NULL, 4)
GO

SELECT * FROM Category
SELECT * FROM Food