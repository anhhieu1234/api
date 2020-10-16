using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class KHBusiness : IKHBusiness
    {
        private IKHRepository _res;
        public KHBusiness(IKHRepository res)
        {
            _res = res;
        }
        public bool Create(KHModel model)
        {
            return _res.Create(model);
        }
    }

}
