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
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _itemBusiness;
        public SanPhamController(ISanPhamBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-item")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SanPhamModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
        [Route("get-moi")]
        [HttpGet]
        public IEnumerable<SanPhamModel> Getsanphammoi()
        {
            return _itemBusiness.Getsanphammoi();
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string item_group_id = "";
                if (formData.Keys.Contains("item_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_group_id"]))) { item_group_id = Convert.ToString(formData["item_group_id"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize,out total,  item_group_id);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

    }
}
