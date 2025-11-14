using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class LoaiMonAnBus
    {
        public List<LoaiMonAn> LayTatCa()
        {
            return DAO.LoaiMonAnDAO.Instance.GetAllLoaiMonAn();
        }

        public bool Them(LoaiMonAn loai)
        {
            return DAO.LoaiMonAnDAO.Instance.InsertLoaiMonAn(loai);
        }

        public bool Xoa(int maLoai)
        {
            return DAO.LoaiMonAnDAO.Instance.DeleteLoaiMonAn(maLoai);
        }

        public bool CapNhat(LoaiMonAn loai)
        {
            return DAO.LoaiMonAnDAO.Instance.UpdateLoaiMonAn(loai);
        }
    }
}
