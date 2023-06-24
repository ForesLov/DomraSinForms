using System.Security.Claims;
using DomraSinForms.Application;
using DomraSinForms.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Forms.Mvc.Helpers;

public static class UserManagerExtensions
{
    public static string GetRequiredUserId<TUser>(this UserManager<TUser> userManager, ClaimsPrincipal user) where TUser : IdentityUser<string>
    {
       return Option<string>
            .Some(userManager.GetUserId(user))
            .Reduce(string.Empty);
    }
}