using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SDLV1.Models;
using System.Diagnostics;
using System.Text;

namespace SDLV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserAccountDto userAccount)
        {
            var client = _httpClientFactory.CreateClient("webclient");
            var Js = JsonConvert.SerializeObject(userAccount);
            var Content = new StringContent(Js, Encoding.UTF8, "application/json");
            var res = client.PostAsync("api/Account/GetToken", Content).Result;


            //var res = client.GetStringAsync("api/Account/GetToken?Username="+ userAccount.UserName + "?Password=" + userAccount.Password + " ").Result;
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}