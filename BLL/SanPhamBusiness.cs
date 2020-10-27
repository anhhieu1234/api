using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class SanPhamBusiness : ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(SanPhamModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }
        public SanPhamModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<SanPhamModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<SanPhamModel> Getsanphammoi()
        {
            return _res.Getsanphammoi();
        }
        public List<SanPhamModel> Getsanphamkhuyenmai()
        {
            return _res.Getsanphamkhuyenmai();
        }
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string item_group_id)
        {
            return _res.Search(pageIndex, pageSize, out total, item_group_id);
        }
        public List<SanPhamModel> Searchadmin(int pageIndex, int pageSize, out long total, string ten, float gia)
        {
            return _res.Searchadmin(pageIndex, pageSize, out total, ten, gia);
        }
    }

}
