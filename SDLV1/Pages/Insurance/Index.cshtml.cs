using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

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
                var resualt = client.GetAsync("api/Insurances/GetAll").Result;
                if(resualt.IsSuccessStatusCode)
                {
                    var model=resualt.Content.ReadFromJsonAsync<List<InsuranceDto>>().Result;
                    Insurances = model;
                }
            }
            catch { }
        }
    }
}
