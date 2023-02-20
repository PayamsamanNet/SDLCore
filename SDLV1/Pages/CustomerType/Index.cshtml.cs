using Common.Setting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace SDLV1.Pages.CustomerType
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

        //public async Task<IActionResult> OnGet()
        //{
        //    try
        //    {
        //        var client = _httpClientFactory.CreateClient(_settingWeb.ClinetName);
        //        var token = User.FindFirst(_settingWeb.TokenName).Value;
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_settingWeb.TokenType, token);
        //        var Result= client.GetAsync()


        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
    }
}
