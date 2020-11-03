using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ISanPhamBusiness
    {
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(string id);
        SanPhamModel GetDatabyID(string id);
        List<SanPhamModel> GetDataAll();
        List<SanPhamModel> Getsanphammoi();
        List<SanPhamModel> Getsanphamkhuyenmai();
        List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
        List<SanPhamModel> Searchadmin(int pageIndex, int pageSize, out long total, string ten, float gia);

        
    }
}
