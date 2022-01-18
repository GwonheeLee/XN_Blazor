using DataShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using XN_Blazor.Services.DAC;

namespace XN_Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public User LoginProc([FromBody] User input)
        {
            UserDAC dac = new UserDAC(_configuration.GetConnectionString("Team5"));

            var user = dac.UserCheck(input);

            if (user == null)
            {
                user = new User()
                {
                    User_ID = input.User_ID,
                    User_PW = input.User_PW,
                    IsEmp = false
                };

                return user;
            }
            else
            {
                user.IsEmp = true;
                return user;
            }

        }
    }
}
