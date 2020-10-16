using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class KhachHangBusiness : IKhachHangBusiness
    {
        private IKhachHangRepository _res;
        public KhachHangBusiness(IKhachHangRepository KhachHangGroupRes)
        {
            _res = KhachHangGroupRes;
        }
        //public bool Create(KhachHangModel model)
        //{
        //    return _res.Create(model);
        //}
        public KhachHangModel GetDatabyID(string id)
        {
            return _res.Getbyid(id);
        }
        public List<KhachHangModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        //public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string KhachHang_group_id)
        //{
        //    return _res.Search(pageIndex, pageSize, out total, KhachHang_group_id);
        //}
    }

}
