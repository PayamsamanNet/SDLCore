using Common.ApiResult;
using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.Branch
{
    public class CreateModel : PageModel
    {
        private IHttpClientFactory _httpClientFactory;
        private SettingWeb _SettingWeb;
        public CreateModel(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options)
        {
            _httpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
        }
        [ViewData]
        public List<BranchManagerDto> BranchManagers { get; set; }

        [ViewData]
        public List<BankDto> Banks { get; set; }
        public BranchDto BranchDto { get; set; }
        public async Task<IActionResult> OnGet()
        {
			try
			{
                var Client=_httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var ResultBank = Client.GetAsync("api/Banks/GetAll").Result;
                var ResultBranchManager = Client.GetAsync("api/BranchManagers/GetAll").Result;
                if (ResultBranchManager.IsSuccessStatusCode)
                {
                    BranchManagers = ResultBranchManager.Content.ReadFromJsonAsync<List<BranchManagerDto>>().Result;
                    Banks = ResultBank.Content.ReadFromJsonAsync<List<BankDto>>().Result;
                    return RedirectToPage("Index");
                }
                else
                {
                    if (ResultBranchManager.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {

                        return RedirectToAction("SignOut", "Account");
                    }
                    else if (ResultBranchManager.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var Error = ResultBranchManager.Content.ReadFromJsonAsync<ResponceApi>();
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

				throw;
			}
        }
    }
}
