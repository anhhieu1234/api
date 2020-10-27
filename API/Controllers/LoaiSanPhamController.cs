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
        [Route("create-loai")]
        [HttpPost]
        public LoaiSanPhamModel CreateLoai([FromBody] LoaiSanPhamModel model)
        {
           
            model.item_group_id = Guid.NewGuid().ToString();
            _itemGroupBusiness.Create(model);
            return model;
        }
        [Route("update-loai")]
        [HttpPost]
        public LoaiSanPhamModel UpdateSanPham([FromBody] LoaiSanPhamModel model)
        {
            _itemGroupBusiness.Update(model);
            return model;
        }
        [Route("delete-loai")]
        [HttpPost]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string item_group_id = "";
            if (formData.Keys.Contains("item_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_group_id"]))) { item_group_id = Convert.ToString(formData["item_group_id"]); }
            _itemGroupBusiness.Delete(item_group_id);
            return Ok();
        }
        [Route("searchloai")]
        [HttpPost]
        public ResponseModel Searchadmin([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"]))) { ten = Convert.ToString(formData["ten"]); }
                long total = 0;
                var data = _itemGroupBusiness.Searchadmin(page, pageSize, out total, ten);
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
