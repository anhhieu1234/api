using System;
using System.Collections.Generic;
using System.IO;
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
        private string _path;
        public SanPhamController(ISanPhamBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-sanpham")]
        [HttpPost]
        public SanPhamModel CreateSanPham([FromBody] SanPhamModel model)
        {
            if (model.item_image != null)
            {
                var arrData = model.item_image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.item_image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.item_id = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("update-sanpham")]
        [HttpPost]
        public SanPhamModel UpdateSanPham([FromBody] SanPhamModel model)
        {
            if (model.item_image != null)
            {
                var arrData = model.item_image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.item_image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _itemBusiness.Update(model);
            return model;
        }
        [Route("delete-sanpham")]
        [HttpPost]
        public IActionResult DeleteSanPham([FromBody] Dictionary<string, object> formData)
        {
            string item_id = "";
            if (formData.Keys.Contains("item_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_id"]))) { item_id = Convert.ToString(formData["item_id"]); }
            _itemBusiness.Delete(item_id);
            return Ok();
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
        [Route("get-khuyenmai")]
        [HttpGet]
        public IEnumerable<SanPhamModel> Getsanphamkhuyenmai()
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
        [Route("searchadmin")]
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
                float gia = 0;
                if (formData.Keys.Contains("gia") && !string.IsNullOrEmpty(Convert.ToString(formData["gia"]))) { ten = Convert.ToString(formData["gia"]); }
                long total = 0;
                var data = _itemBusiness.Searchadmin(page, pageSize, out total,ten, gia);
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
