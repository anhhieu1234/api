using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBusiness _itemGroupBusiness;
        public KhachHangController(IKhachHangBusiness itemGroupBusiness)
        {
            _itemGroupBusiness = itemGroupBusiness;
        }

        [Route("get-menu")]
        [HttpGet]
        public IEnumerable<KhachHangModel> GetAllMenu()
        {
            return _itemGroupBusiness.GetDataAll();
        }
        [Route("get-id/{id}")]
        [HttpGet]
        public KhachHangModel Getbyid(string id)
        {
            return _itemGroupBusiness.GetDatabyID(id);
        }
    }
}
