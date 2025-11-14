using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class MonAnBus
    {
        public List<MonAn> LayTatCa()
        {
            return DAO.MonAnDAO.Instance.GetAllMonAn();
        }

        public List<MonAn> LayTheoLoai(int maLoai)
        {
            return DAO.MonAnDAO.Instance.GetMonAnByLoai(maLoai);
        }

        public bool Them(MonAn mon)
        {
            return DAO.MonAnDAO.Instance.InsertMonAn(mon);
        }

        public bool Xoa(int maMon, int maLoai)
        {
            return DAO.MonAnDAO.Instance.DeleteMonAn(maMon,maLoai);
        }

        public bool CapNhat(MonAn mon)
        {
            return DAO.MonAnDAO.Instance.UpdateMonAn(mon);
        }

        public MonAn LayTheoMa(int maMon)
        {
            return DAO.MonAnDAO.Instance.GetMonAnById(maMon);
        }
    }
}
