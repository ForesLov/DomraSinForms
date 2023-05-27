using System.Diagnostics;
using DomraSinForms.Application.Users.Queries;
using DomraSinForms.Domain.Identity;
using Forms.Mvc.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Mvc.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SignInManager<User> _signInManager;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, IMediator mediator)
    {
        _logger = logger;
        _signInManager = signInManager;
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction(nameof(Summary));

        return View();
    }
    [Authorize]
    public async Task<IActionResult> Summary()
    {
        var summary = await _mediator.Send(new GetUserActionsSummaryQuery { UserId = _signInManager.UserManager.GetUserId(User)! });

        return View(new UserSummaryViewModel(summary));
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
