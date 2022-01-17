using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace XN_Blazor.Pages.Login
{
    public class IsEmp :IAuthorizationRequirement
    {

    }
    //public class XNAuthorization : AuthorizationHandler<IsEmp>
    //{
    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsEmp requirement)
    //    {
    //        context.User.
    //    }
    //}
}
