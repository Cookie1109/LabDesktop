using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class BanBus
    {
        public List<Ban> LayTatCa()
        {
            return BanDAO.Instance.GetAllBan() ?? new List<Ban>();
        }
        public bool Them(Ban ban)
        {
            return DAO.BanDAO.Instance.InsertBan(ban);
        }
        public bool Xoa(int maBan)
        {
            return DAO.BanDAO.Instance.DeleteBan(maBan);
        }
    }
}
