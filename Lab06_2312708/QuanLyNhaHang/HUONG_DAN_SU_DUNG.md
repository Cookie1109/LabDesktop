# HƯỚNG DẪN CÀI ĐẶT VÀ SỬ DỤNG CHỨC NĂNG ĐĂNG KÝ, ĐĂNG NHẬP VÀ PHÂN QUYỀN

## 1. CÀI ĐẶT CƠ SỞ DỮ LIỆU

### Bước 1: Chạy script tạo bảng Account và Role
1. Mở SQL Server Management Studio
2. Kết nối đến SQL Server
3. Mở file `CreateAccountAndRoleTable.sql`
4. Chạy toàn bộ script để tạo:
   - Bảng `Role` (Vai trò/Chức vụ)
   - Bảng `Account` (Tài khoản - 1 tài khoản = 1 nhân viên)
   - Các stored procedures cần thiết
   - Dữ liệu mẫu cho bảng Role (Quản lý, Nhân viên, Thu ngân)

## 2. CẤU TRÚC DỮ LIỆU

### Bảng Role (Vai trò/Chức vụ)
```
RoleID      INT (Primary Key, Identity)
RoleName    NVARCHAR(50)
```

### Bảng Account (Tài khoản)
```
AccountID   INT (Primary Key, Identity)
MaNV        INT (Foreign Key -> NhanVien.MaNV, UNIQUE)
Username    VARCHAR(50) (UNIQUE)
Password    VARCHAR(255)
RoleID      INT (Foreign Key -> Role.RoleID)
IsActive    BIT (Default: 1)
CreatedDate DATETIME (Default: GETDATE())
```

**Lưu ý:** 1 tài khoản = 1 nhân viên (quan hệ 1-1)

## 3. CHỨC NĂNG ĐĂNG KÝ (frmRegister)

### Cách sử dụng:
1. Từ form đăng nhập, click vào link "Đăng ký ngay"
2. Nhập đầy đủ thông tin:
   - Họ và Tên
   - Giới tính (Nam/Nữ)
   - Số điện thoại
   - Chức vụ (chọn từ danh sách)
   - Tài khoản
   - Mật khẩu
   - Xác nhận mật khẩu
3. Click nút "Đăng ký"

### Quy trình:
- Hệ thống tự động tạo nhân viên mới trong bảng `NhanVien`
- Tạo tài khoản tương ứng trong bảng `Account`
- Kiểm tra tên đăng nhập không trùng lặp
- Kiểm tra mật khẩu xác nhận khớp

## 4. CHỨC NĂNG ĐĂNG NHẬP (frmLogin)

### Cách sử dụng:
1. Nhập tên đăng nhập
2. Nhập mật khẩu
3. Click nút "Đăng nhập" hoặc nhấn Enter

### Thông tin đăng nhập:
- Hệ thống kiểm tra trong bảng `Account`
- Chỉ cho phép đăng nhập tài khoản đang hoạt động (IsActive = 1)
- Sau khi đăng nhập thành công, thông tin tài khoản được lưu trong `frmLogin.CurrentAccount`

## 5. CHỨC NĂNG QUẢN LÝ NHÂN VIÊN (frmNhanVien)

### Hiển thị danh sách:
- Hiển thị tất cả nhân viên đã đăng ký tài khoản
- Thông tin: Tên, Giới tính, Số điện thoại, Chức vụ, Tài khoản

### Cập nhật thông tin (Nút Lưu):
1. Click vào 1 dòng trong DataGridView để chọn nhân viên
2. Thông tin tự động hiển thị ở form bên phải
3. Chỉnh sửa các thông tin cần thiết
4. Click nút "Lưu"
5. Hệ thống cập nhật đồng thời:
   - Bảng `NhanVien` (Tên, Giới tính, SĐT, Chức vụ)
   - Bảng `Account` (Username, Password, RoleID)

### Xóa tài khoản (Context Menu):
1. Click phải vào nhân viên cần xóa
2. Chọn "Xóa tài khoản"
3. Xác nhận xóa
4. **Lưu ý:** Hệ thống sử dụng Soft Delete (đánh dấu IsActive = 0)
   - Tài khoản không bị xóa vật lý khỏi database
   - Tài khoản không thể đăng nhập
   - Tài khoản không hiển thị trong danh sách

### Xem danh sách vai trò (Context Menu):
1. Click phải vào DataGridView
2. Chọn "Xem danh sách vai trò"
3. Form quản lý vai trò sẽ mở ra

## 6. CHỨC NĂNG QUẢN LÝ VAI TRÒ (frmRole)

### Thêm vai trò mới:
1. Nhập tên vai trò vào textbox
2. Click nút "Thêm"
3. Vai trò mới sẽ xuất hiện trong DataGridView và ComboBox ở form NhanVien

### Xóa vai trò:
1. Click vào vai trò cần xóa trong DataGridView
2. Click nút "Xóa"
3. Xác nhận xóa
4. **Lưu ý:** Không thể xóa vai trò đang được sử dụng bởi tài khoản nào

## 7. TÍCH HỢP VỚI MAINFORM

Sau khi đăng nhập thành công, bạn có thể sử dụng thông tin tài khoản hiện tại:

```csharp
// Trong MainForm hoặc bất kỳ form nào
if (frmLogin.CurrentAccount != null)
{
    string tenNV = frmLogin.CurrentAccount.TenNV;
    string roleName = frmLogin.CurrentAccount.RoleName;
    int roleID = frmLogin.CurrentAccount.RoleID;
    
    // Phân quyền dựa trên RoleID
    if (roleID == 1) // Quản lý
    {
        // Hiển thị tất cả chức năng
    }
    else if (roleID == 2) // Nhân viên
    {
        // Giới hạn một số chức năng
    }
}
```

## 8. LƯU Ý QUAN TRỌNG

1. **Quan hệ 1-1:** Mỗi nhân viên chỉ có 1 tài khoản duy nhất
2. **Soft Delete:** Khi xóa tài khoản, chỉ đánh dấu IsActive = 0
3. **Unique Username:** Tên đăng nhập không được trùng lặp
4. **Cascade:** Không thể xóa vai trò đang được sử dụng
5. **Password:** Hiện tại password lưu plain text (nên mã hóa trong production)

## 9. STORED PROCEDURES ĐƯỢC SỬ DỤNG

### Role:
- `Role_GetAll`: Lấy tất cả vai trò
- `Role_Insert`: Thêm vai trò mới
- `Role_Delete`: Xóa vai trò

### Account:
- `Account_GetAll`: Lấy tất cả tài khoản đang hoạt động
- `Account_Login`: Đăng nhập
- `Account_Register`: Đăng ký tài khoản mới
- `Account_Update`: Cập nhật tài khoản
- `Account_Delete`: Xóa tài khoản (soft delete)
- `Account_GetByMaNV`: Lấy thông tin tài khoản theo mã nhân viên

## 10. XỬ LÝ LỖI THƯỜNG GẶP

### Lỗi: "Tên đăng nhập đã tồn tại"
- Giải pháp: Chọn tên đăng nhập khác

### Lỗi: "Nhân viên này đã có tài khoản"
- Giải pháp: Mỗi nhân viên chỉ được tạo 1 tài khoản

### Lỗi: "Không thể xóa vai trò"
- Giải pháp: Đổi vai trò của các tài khoản đang sử dụng vai trò này trước khi xóa

### Lỗi kết nối database
- Kiểm tra connection string trong `DataProvider.cs`
- Đảm bảo SQL Server đang chạy
- Kiểm tra tên database: `QuanLyNhaHang`

## 11. DEMO ACCOUNT (sau khi đăng ký)

Sau khi chạy script và đăng ký tài khoản đầu tiên, bạn có thể đăng nhập với:
- Username: (tài khoản bạn vừa tạo)
- Password: (mật khẩu bạn vừa tạo)

## KẾT LUẬN

Hệ thống đã hoàn thiện các chức năng:
✅ Đăng ký tài khoản (tự động tạo nhân viên)
✅ Đăng nhập
✅ Quản lý nhân viên (hiển thị nhân viên có tài khoản)
✅ Cập nhật thông tin nhân viên và tài khoản
✅ Xóa tài khoản (soft delete)
✅ Quản lý vai trò/chức vụ
✅ Tích hợp vai trò vào ComboBox
✅ Context menu cho xóa tài khoản và xem vai trò
