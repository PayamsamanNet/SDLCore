using Common.ApiResult;
using Common.Setting;
using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace SDLV1.Pages.Roles
{
    public class ManageRoleModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SettingWeb _SettingWeb;

        public ManageRoleModel(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options)
        {
            _httpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
        }

        public List<PermissionDto> Permissions { get; set; }    

        public async Task<IActionResult> OnGet(string Id)
        {
			try
			{
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/Permission/GetRoleByPerMission?RoleId=" + Id + "").Result;
                if (Result.IsSuccessStatusCode)
                {
                    Permissions = Result.Content.ReadFromJsonAsync<List<PermissionDto>>().Result;
                    return Page();
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
                        ModelState.AddModelError("EditError", Error.Result.Message);
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
                return Page();
            }
        }
    }
}
