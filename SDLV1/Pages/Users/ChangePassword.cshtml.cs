using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using Common.Setting;
using Microsoft.Extensions.Options;
using Common.ApiResult;
using Service.EmailService;

namespace SDLV1.Pages.Users
{
    public class ChangePasswordModel : PageModel
    {

        private IHttpClientFactory _httpClientFactory;
        private IEmailService _EmailService;
        private SettingWeb _SettingWeb;
        public ChangePasswordModel(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options, IEmailService EmailService)
        {
            _httpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
            _EmailService = EmailService;
        }


        [BindProperty]
        public ChangePassword ChangePassword { get; set; }=new ChangePassword();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                return Page();
            }
            catch (Exception)
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostVerifyUser()
        {
            try
            {
              
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/Users/GetUserByUserName?UserName=" + ChangePassword.UserName + "").Result;
                if (Result.IsSuccessStatusCode)
                {
                    /// Genarate Code Verifiy 
                    var User=Result.Content.ReadFromJsonAsync<UserDto>().Result;
                    //_EmailService.Execute();


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

                return Page();
            }
            catch (Exception)
            {
                return Page();
            }

        }
    }
}
