using Common.ApiResult;
using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.BoxTypes
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
        [BindProperty]
        public BoxTypeDto BoxType { get; set; }
        public async Task<IActionResult> OnGet(string Id)
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/BoxTypes/GetById?Id=" + Id + "").Result;
                if (Result.IsSuccessStatusCode)
                {
                    BoxType = Result.Content.ReadFromJsonAsync<BoxTypeDto>().Result;
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
                    return Page();
                }
                else
                {
                    var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                    var token = User.FindFirst(_SettingWeb.TokenName).Value;
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                    var Json = JsonConvert.SerializeObject(BoxType);
                    var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                    var Result = Client.PutAsync("api/BoxTypes/Update", Content).Result;
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
                            ModelState.AddModelError("EditError", Error.Result.Message);
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
                return RedirectToAction("ErrorPage", "Home");
            }


        }


    }
}
