using DataShared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using XN_Blazor.Services;
using System.Text;
using System;

namespace XN_Blazor.Pages.Login
{
    public class LoginModel : PageModel
    {
        readonly LoginService _loginService;
        public LoginModel(LoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult OnGet()
        {
            if(HttpContext.User.Claims.FirstOrDefault(claim => claim.Value == "Emp") is null)
            {
                return Page();
            }
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
        [BindProperty]
        public User LoginUser { get; set; }
        public string ErrMsg { get; set; }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid == false)
            {
                ViewData["ErrorMsg"] = "잘못 입력하였습니다";
                return Page();
            }

            User resUser = await _loginService.LoginProcess(LoginUser);

            if (resUser.IsEmp)
            {
                ViewData["ErrorMsg"] = string.Empty;
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Role,resUser.Customer_Code),
                    new Claim(ClaimTypes.Actor,"Emp"),
                    new Claim(ClaimTypes.Name,resUser.User_Name)
                }, "IsEmp");
                ClaimsPrincipal claims = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claims);
                return Redirect("/");
            }
            else
            {
                ViewData["ErrorMsg"] = "계정이 없습니다";
                return Page();
            }
  
        }
    }
}
