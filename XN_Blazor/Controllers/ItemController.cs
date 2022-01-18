using DataShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using XN_Blazor.Services.DAC;

namespace XN_Blazor.Controllers
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
            var items = dac.GetItems();

            return items;

        }
        [HttpPost("defect")]
        public Bad_Good GetDefectData([FromBody] Bad_Good input)
        {
            ItemDAC dac = new ItemDAC(_configuration.GetConnectionString("Team5"));
            Bad_Good result = dac.GetDefactData(input);

            return result;
        }
        [HttpPost("itemQty")]
        public double[] GetQty([FromBody] ItemQty input)
        {
            ItemDAC dac = new ItemDAC(_configuration.GetConnectionString("Team5"));
            double[] result = dac.GetQty(input);

            return result;
        }
    }
}
