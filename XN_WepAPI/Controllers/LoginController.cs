using DataShared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using XN_WepAPI.DAC;

namespace XN_WepAPI.Controllers
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
