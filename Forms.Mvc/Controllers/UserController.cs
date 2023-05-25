using DomraSinForms.Domain.Identity;
using Forms.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;

    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }
    [HttpPost]
    public async Task<IActionResult> Edit([Bind] EditUserViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Profile));
        }
        var user = await _userManager.GetUserAsync(User);
        if (user.Email != viewModel.Email)
        {
            user.Email = viewModel.Email;
            await _userManager.UpdateAsync(user);
            await _userManager.ChangeEmailAsync(user, viewModel.Email, await _userManager.GenerateEmailConfirmationTokenAsync(user));
        }
        if (user.UserName != viewModel.Username)
        {
            user.UserName = viewModel.Username;
            await _userManager.UpdateAsync(user);
            await _userManager.SetUserNameAsync(user, viewModel.Username);
        }
        if (!string.IsNullOrWhiteSpace(viewModel.NickName) & user.NickName != viewModel.NickName)
        {
            user.NickName = viewModel.NickName;
            await _userManager.UpdateAsync(user);
        }
        return RedirectToAction(nameof(Profile));
    }
}
