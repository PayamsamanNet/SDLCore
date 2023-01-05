using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Microsoft.Extensions.Options;
using SDLV1.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SDLDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SDLConnectionString"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SDLDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.RegisterLocalization();

builder.Services.AddRazorPages();

builder.Services.AddHttpClient("webclient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5017");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

var supportedCulture = new[] { "en-Us", "fa-IR", "ar-EG", "de-DE" };
var locatiozationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCulture[0])
    .AddSupportedCultures(supportedCulture)
    .AddSupportedUICultures(supportedCulture);

app.UseRequestLocalization(locatiozationOptions);

app.MapRazorPages();
app.UseRouting();


app.UseAuthentication();;

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
