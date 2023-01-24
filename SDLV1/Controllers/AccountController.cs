using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace SDLV1.Controllers
{
    public class AccountController : Controller
    {
        //private IHttpClientFactory _HttpClientFactory;
        //private SettingWeb _SettingWeb;

        //public AccountController(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options)
        //{
        //    _HttpClientFactory = httpClientFactory;
        //    _SettingWeb = options.Value;
        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            try
            {
                //var Client=_HttpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var Json=JsonConvert.SerializeObject(loginDto);
                var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                //var Result = Client.PostAsync("api/Account/Login", Content).Result;
                //if (Result.IsSuccessStatusCode )
                //{

                //}

            }
            catch (Exception)
            {

                throw;
            }


            return View();
        }
    }
}
