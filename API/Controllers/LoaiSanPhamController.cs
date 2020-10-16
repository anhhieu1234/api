using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        private ILoaiSanPhamBusiness _itemGroupBusiness;
        public LoaiSanPhamController(ILoaiSanPhamBusiness itemGroupBusiness)
        {
            _itemGroupBusiness = itemGroupBusiness;
        }

        [Route("get-menu")]
        [HttpGet]
        public IEnumerable<LoaiSanPhamModel> GetAllMenu()
        {
            return _itemGroupBusiness.GetData();
        }
    }
}
