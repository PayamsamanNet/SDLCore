using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using Common.Setting;
using Microsoft.Extensions.Options;
using Common.ApiResult;

namespace SDLV1.Pages.BranchManager
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

        public List<BranchManagerDto> BranchManagers { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/BranchManagers/GetAll").Result;
                if (Result.IsSuccessStatusCode)
                {
                    var Model = Result.Content.ReadFromJsonAsync<List<BranchManagerDto>>();
                    BranchManagers = Model.Result;
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


        public IActionResult OnPostDelete(string Id)
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.DeleteAsync("api/BranchManagers/Delete?Id=" + Id + "").Result;
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
                        ModelState.AddModelError("DeleteError", Error.Result.Message);

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
