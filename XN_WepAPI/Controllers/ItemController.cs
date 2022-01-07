using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using DataShared;
using System.Collections.Generic;
using XN_WepAPI.DAC;
using Microsoft.Extensions.Configuration;

namespace XN_WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public ItemController(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            ItemDAC dac = new ItemDAC(_configuration.GetConnectionString("Team5"));
            var items=dac.GetItems();

            return items;

        }
    }
}
