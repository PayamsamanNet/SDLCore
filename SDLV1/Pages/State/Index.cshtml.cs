using Common.Setting;
using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace SDLV1.Pages.State
{
    public class IndexModel : PageModel
    {
        private IHttpClientFactory _httpClientFactory;
        private SettingWeb _SettingWeb;
        public IndexModel(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options)
        {
            _httpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
        }
        public List<StateDto> States { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/States/GetAll").Result;
                if (Result.IsSuccessStatusCode)
                {
                    States = Result.Content.ReadFromJsonAsync<List<StateDto>>().Result;
                    
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
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
    }
}
