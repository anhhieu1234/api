using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHoaDonRepository
    {
        bool Create(HoaDonModel model);
        bool Update(HoaDonModel model);
        bool Delete(string id);
        HoaDonModel GetDatabyID(string id);
        List<HoaDonModel> Searchadmin(int pageIndex, int pageSize, out long total, string ten);
        List<ChiTietHoaDonModel> GetChitietbyhoadon(string id);
    }
}
