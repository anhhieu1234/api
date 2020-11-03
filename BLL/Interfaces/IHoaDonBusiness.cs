using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IHoaDonBusiness
    {
        bool Create(HoaDonModel model);
        bool Update(HoaDonModel model);
        bool Delete(string id);
        HoaDonModel GetDatabyID(string id);
        List<HoaDonModel> Searchadmin(int pageIndex, int pageSize, out long total, string ten);
        HoaDonModel GetChiTietByHoaDon(string id);
    }
}
