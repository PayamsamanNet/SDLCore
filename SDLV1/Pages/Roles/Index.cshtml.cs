using Common.ApiResult;
using Common.Setting;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Options;
using Data.Dto;

namespace SDLV1.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SettingWeb _settingWeb;

        public IndexModel(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options)
        {
            _httpClientFactory = httpClientFactory;
            _settingWeb = options.Value;
        }

        public List<RoleDto> Roles { get; set; }
        public async Task<IActionResult> OnGet()
        {

            var Client = _httpClientFactory.CreateClient(_settingWeb.ClinetName);
            var token = User.FindFirst(_settingWeb.TokenName).Value;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_settingWeb.TokenType, token);
            var Result = Client.GetAsync("api/Role/GetAll").Result;
            if (Result.IsSuccessStatusCode)
            {
                Roles = Result.Content.ReadFromJsonAsync<List<RoleDto>>().Result;
                
                return Page();
            }
            else
            {
                if (Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {

                    return RedirectToAction("SignOut", "Account");
                }
                else
                {
                    return RedirectToAction("ErrorPage", "Home");
                }
            }
        }
    }
}
