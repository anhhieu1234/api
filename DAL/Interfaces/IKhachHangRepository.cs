using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IKhachHangRepository
    {
        // bool Create(KhachHangModel model);
        KhachHangModel Getbyid(string id);
        List<KhachHangModel> GetDataAll();
        //List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string KhachHang_group_id);
    }
}
