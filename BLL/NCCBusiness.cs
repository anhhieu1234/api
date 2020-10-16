using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class NCCBusiness : INCCBusiness
    {
        private INCCRepository _res;
        public NCCBusiness(INCCRepository NCCGroupRes)
        {
            _res = NCCGroupRes;
        }
        //public bool Create(NCCModel model)
        //{
        //    return _res.Create(model);
        //}
        public List<NCCModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        //public List<NCCModel> Search(int pageIndex, int pageSize, out long total, string NCC_group_id)
        //{
        //    return _res.Search(pageIndex, pageSize, out total, NCC_group_id);
        //}
    }

}
