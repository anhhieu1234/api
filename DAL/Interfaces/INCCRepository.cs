using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface INCCRepository
    {
        // bool Create(KhachHangModel model);
        List<NCCModel> GetDataAll();
        //List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string KhachHang_group_id);
    }
}
