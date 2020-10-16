using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IKhachHangBusiness
    {
        //bool Create(ItemModel model);
        KhachHangModel GetDatabyID(string id);
        List<KhachHangModel> GetDataAll();
       // List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
    }
}
