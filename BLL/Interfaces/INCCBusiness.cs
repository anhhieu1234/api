using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface INCCBusiness
    {
        //bool Create(ItemModel model);
        List<NCCModel> GetDataAll();
       // List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
    }
}
