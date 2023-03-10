using Common.ApiResult;
using Common.Setting;
using Common.Utilities.ClassUtilities;
using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

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
        public static string RoleId { get; set; }
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
                    RoleId = Id;
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

        public async Task<IActionResult> OnPostAddPermission(string ids)
        {
            try
            {
                List<RolePermissionDto> Models = new List<RolePermissionDto>();
                if (ids == "" || ids == null)
                {
                    Models.Add(new RolePermissionDto
                    {
                        RoleId = RoleId,
                        PermissionId = Guid.Empty
                    }) ;
                }
                else
                {

                    var ListPermission = ids.Split("/");
                    foreach (var item in ListPermission)
                    {
                        if (item != "")
                        {
                            Models.Add(new RolePermissionDto
                            {
                                RoleId = RoleId,
                                PermissionId = new Guid(item.ToString())
                            });
                        }
                    }
                }
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Json = JsonConvert.SerializeObject(Models);
                var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                var Result = Client.PostAsync("api/Permission/AddRolePermission", Content).Result;
                if (Result.IsSuccessStatusCode)
                {
                    var Error = Result.Content.ReadFromJsonAsync<ResponceApi>();
                    return new JsonResult(Error
                        );
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
