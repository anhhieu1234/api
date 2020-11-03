using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        private ISanPhamBusiness _rsp;
        public HoaDonBusiness(IHoaDonRepository res,ISanPhamBusiness rsp)
        {
            _res = res;
            _rsp = rsp;
        }
        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(HoaDonModel model)
        {
            return _res.Update(model);
        }
        public HoaDonModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<HoaDonModel> Searchadmin(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Searchadmin(pageIndex, pageSize, out total, ten);
        }
        public HoaDonModel GetChiTietByHoaDon(string id)
        {
            var kq= _res.GetDatabyID(id);
            
                kq.listjson_chitiet = _res.GetChitietbyhoadon(id);
            foreach(var item in kq.listjson_chitiet)
            {
                item.item_name = _rsp.GetDatabyID(item.item_id).item_name;
                item.don_gia = _rsp.GetDatabyID(item.item_id).item_price.Value;
            }
            
            return kq;
        }
    }

}
