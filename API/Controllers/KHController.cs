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
    public class KHController : ControllerBase
    {
        private IKHBusiness _customerBusiness;
        public KHController(IKHBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }
         
        [Route("create-item")]
        [HttpPost]
        public KHModel CreateItem([FromBody] KHModel model)
        {
            _customerBusiness.Create(model);
            return model;
        } 
    }
}
