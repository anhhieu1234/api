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
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
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
    }

}
