using Common.ApiResult;
using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.CustomerType
{
    public class EditModel : PageModel
    {
        private IHttpClientFactory _httpClientFactory;
        private SettingWeb _SettingWeb;
        public EditModel(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options)
        {
            _httpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
        }
        public static List<BankDto> BanksStatic { get; set; }
        public List<BankDto> Banks { get; set; }
        [BindProperty]
        public CustomerTypeDto CustomerType { get; set; }
        public async Task<IActionResult> OnGet(string Id)
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/CustomerTypes/GetById?Id=" + Id + "").Result;
                var ResultBank = Client.GetAsync("api/Banks/GetAll").Result;
                if (Result.IsSuccessStatusCode)
                {
                    CustomerType = Result.Content.ReadFromJsonAsync<CustomerTypeDto>().Result;
                    Banks = ResultBank.Content.ReadFromJsonAsync<List<BankDto>>().Result;
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
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    Banks = BanksStatic;

                    return Page();
                }
                else
                {
                    var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                    var token = User.FindFirst(_SettingWeb.TokenName).Value;
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                    var Json = JsonConvert.SerializeObject(CustomerType);
                    var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                    var Result = Client.PutAsync("api/CustomerTypes/Update", Content).Result;
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
            }
            catch (Exception)
            {
                return Page();
                
            }


        }
    }
}
