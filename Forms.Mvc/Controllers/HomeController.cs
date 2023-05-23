using System.Diagnostics;
using DomraSinForms.Domain.Identity;
using Forms.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SignInManager<User> _signInManager;

    public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager)
    {
        _logger = logger;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction(nameof(Summary));

        return View();
    }
    public async Task<IActionResult> Summary()
    {
        return View();
    }
    [HttpPost]
    public IActionResult SetLanguage(string language, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return Redirect(returnUrl);
        //LocalRedirect(returnUrl);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
