using DataShared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
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
        public bool LoginProc([FromForm]User input)
        {
            UserDAC dac = new UserDAC(_configuration.GetConnectionString("Team5"));

            var user = dac.UserCheck(input);

            if(user == null)
                return false;
            else
                return true;

            ////로그인체크
            //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.User_ID));
            //identity.AddClaim(new Claim(ClaimTypes.Name, user.User_Name));
            //identity.AddClaim(new Claim("LastCheckDateTime", DateTime.UtcNow.ToString("yyyyMMddHHmmss")));

            //if (user.Customer_Code == "Administrator")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));
            //}

            //var principal = new ClaimsPrincipal(identity);
            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            //{
            //    IsPersistent = false,
            //    ExpiresUtc = DateTime.UtcNow.AddHours(4),
            //    AllowRefresh = true
            //});

        }
    }
}
