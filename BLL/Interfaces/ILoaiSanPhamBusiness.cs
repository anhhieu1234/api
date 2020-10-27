using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ILoaiSanPhamBusiness
    {
        List<LoaiSanPhamModel> GetData();
        bool Create(LoaiSanPhamModel model);
        bool Update(LoaiSanPhamModel model);
        bool Delete(string id);
        LoaiSanPhamModel GetDatabyID(string id);
        List<LoaiSanPhamModel> Searchadmin(int pageIndex, int pageSize, out long total, string ten);
    }
}
