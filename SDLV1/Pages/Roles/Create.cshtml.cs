using Common.ApiResult;
using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Store.Core.Security;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.Roles
{
    [PermissionChecker("138")]
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SettingWeb _settingWeb;

        public CreateModel(IHttpClientFactory httpClientFactory,IOptions<SettingWeb> options)
        {
            _httpClientFactory = httpClientFactory;
            _settingWeb = options.Value;
        }
        [BindProperty]
        public RoleDto Role { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }


                var Client=_httpClientFactory.CreateClient(_settingWeb.ClinetName);
                var token = User.FindFirst(_settingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_settingWeb.TokenType, token);
                var Json=JsonConvert.SerializeObject(Role);
                var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                var Result = Client.PostAsync("api/Role/Create", Content).Result;
                if (Result.IsSuccessStatusCode)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    if (Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {

                        return RedirectToAction("SignOut", "Account");
                    }
                    else if (Result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var Error = Result.Content.ReadFromJsonAsync<ResponceApi>();
                        ModelState.AddModelError("CreateError", Error.Result.Message);
                        return Page();
                    }
                    else
                    {
                        return RedirectToAction("ErrorPage", "Home");
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

    }
}
