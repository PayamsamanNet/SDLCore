using Common.ApiResult;
using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace SDLV1.Pages.Insurance
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SettingWeb _settingWeb;


        public IndexModel(IHttpClientFactory httpClientFactory,IOptions<SettingWeb> options)
        {
            _httpClientFactory = httpClientFactory;
            _settingWeb= options.Value;
        }


        public List<InsuranceDto> Insurances { get; set; }
        public void OnGet()
        {

            try
            {
                var client=_httpClientFactory.CreateClient("WebClinet");
                var token = User.FindFirst(_settingWeb.TokenName).Value;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_settingWeb.TokenType, token);
                var resualt = client.GetAsync("api/Insurances/GetAll").Result;
                if(resualt.IsSuccessStatusCode)
                {
                    var model=resualt.Content.ReadFromJsonAsync<List<InsuranceDto>>().Result;
                    Insurances = model;
                }
            }
            catch { }
        }

        public IActionResult OnPostDelete(string Id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("WebClinet");
                var token = User.FindFirst(_settingWeb.TokenName).Value;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_settingWeb.TokenType, token);
                var Result = client.DeleteAsync("api/Insurances/Delete?Id=" + Id + "").Result;
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
