using SDLV1.Configuration;
using Common.Setting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Service.ServiceFile;
using Service.EmailService;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<SDLDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SDLConnectionString"));
//});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<SDLDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.RegisterLocalization();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.Configure<SettingWeb>(builder.Configuration.GetSection("SettingWeb"));
SettingWeb? _SettingWeb = builder.Configuration.GetSection("SettingWeb").Get<SettingWeb>();



builder.Services.AddHttpClient(_SettingWeb.ClinetName, client =>
{
    client.BaseAddress = new Uri(_SettingWeb.BaseAddress);
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(_SettingWeb.ExpireTimeSpan);
        options.Cookie.MaxAge = options.ExpireTimeSpan;
        options.SlidingExpiration = true;
        options.LoginPath = _SettingWeb.LoginPath;
        options.LogoutPath = _SettingWeb.LogoutPath;
        options.Cookie.Name = _SettingWeb.Name;
        options.AccessDeniedPath = _SettingWeb.AccessDeniedPath;
    });


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
    options.HttpOnly = HttpOnlyPolicy.None;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
var supportedCulture = new[] { "en", "fa"};
var locatiozationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCulture[0])
    .AddSupportedCultures(supportedCulture)
    .AddSupportedUICultures(supportedCulture);

app.UseRequestLocalization(locatiozationOptions);

app.UseHttpsRedirection();
app.MapRazorPages();

app.UseRouting();

app.MapRazorPages();

app.UseAuthentication();;

app.UseAuthorization();
app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
