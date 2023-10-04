using DomraSinForms.Application;
using DomraSinForms.Domain.Identity;
using DomraSinForms.Persistence;
using Forms.Mvc.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddPersistence(connectionString);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = true;
    options.Lockout.MaxFailedAccessAttempts = 700;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.MinValue;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services
    .AddControllersWithViews()
    .AddViewLocalization();

builder.Services
    .AddLocalization()
    .AddDataAnnotationsPortableObjectLocalization()
    .AddApplication()
    .AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");

builder.Logging.AddConsole();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

ConfigLocalization(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


void ConfigLocalization(WebApplication application)
{
    var supportedCultures = Localization.SupportedLanguages.Select(i => i.Key).ToArray();
    var options = new RequestLocalizationOptions()
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures)
        .SetDefaultCulture(supportedCultures[0]);

    application.UseRequestLocalization(options);
}
