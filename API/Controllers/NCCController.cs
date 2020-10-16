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
    public class NCCController : ControllerBase
    {
        private INCCBusiness _itemGroupBusiness;
        public NCCController(INCCBusiness itemGroupBusiness)
        {
            _itemGroupBusiness = itemGroupBusiness;
        }

        [Route("get-menu")]
        [HttpGet]
        public IEnumerable<NCCModel> GetAllMenu()
        {
            return _itemGroupBusiness.GetDataAll();
        }
    }
}
