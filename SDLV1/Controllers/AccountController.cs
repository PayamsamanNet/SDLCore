using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SDLV1.Controllers
{
    public class AccountController : Controller
    {
        private IHttpClientFactory _HttpClientFactory;
        private SettingWeb _SettingWeb;

        public AccountController(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options)
        {
            _HttpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    return View(login);
                }
                else
                {
                    var Client = _HttpClientFactory.CreateClient(_SettingWeb.ClinetName);
                    var Json = JsonConvert.SerializeObject(login);
                    var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                    var Result = Client.PostAsync("api/Account/Login", Content).Result;
                    if (Result.IsSuccessStatusCode)
                    {
                        var Model = Result.Content.ReadFromJsonAsync<ResponseAccount<UserDto>>();
                        if (Model.Result.Token != "")
                        {
                            List<Claim> Cliams = new List<Claim>();
                            foreach (var item in Model.Result.Roles)
                            {
                                var Cliam = new Claim(ClaimTypes.Role, item);
                                Cliams.Add(Cliam);
                            }
                            foreach (var item in Model.Result.Roles)
                            {
                                var Cliam = new Claim(ClaimTypes.Role, item);
                                Cliams.Add(Cliam);
                            }

                            //var ImageUser = new ClaimsIdentityOptions().SecurityStampClaimType;


                            Cliams.Add(new Claim(ClaimTypes.Name, Model.Result.data.Name +""+ Model.Result.data.Family));
                            Cliams.Add(new Claim(ClaimTypes.NameIdentifier, login.UserName));
                            Cliams.Add(new Claim("ImageUser", Model.Result.data.ImageUser.ToString()));
                            Cliams.Add(new Claim(_SettingWeb.TokenName, Model.Result.Token));
                            var Identity = new ClaimsIdentity(Cliams, CookieAuthenticationDefaults.AuthenticationScheme);
                            var perencipal = new ClaimsPrincipal(Identity);
                            var Properties = new AuthenticationProperties
                            {
                                IsPersistent = true,
                                AllowRefresh = true,
                            };
                            await HttpContext.SignInAsync(perencipal, Properties);
                            return RedirectToAction("Index", "Home");
                        }

                    }
                    else
                    {

                    }


                    return View();
                }

                
            }
            catch (Exception)
            {

                throw;
            }


            
        }

    }
}
