using Common.ApiResult;
using Common.Setting;
using Common.Utilities.ClassUtilities;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.Permission
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


        [BindProperty]
        //public InsuranceDto Insurance { get; set; }
        public PermissionDto Permission { get; set; }

        public List<ControllerModel> Controllers { get; set; }
        public static List<ControllerModel> StaticControllers { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/Permission/GetAllAcessProject").Result;

                if (Result.IsSuccessStatusCode)
                {
                   var Acess = Result.Content.ReadFromJsonAsync<List<ControllerModel>>().Result;
                    Controllers = Acess.Where(a => a.IsMenu == true).ToList();
                    StaticControllers = Controllers;
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
                throw;
            }
        }

        public async Task<IActionResult> OnPost(string typeMenu)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    PermissionDto model = new PermissionDto();
                    if (typeMenu == "MainMenu")
                    {
                        var num = Convert.ToInt32(Permission.Title);
                        model.SubCode = num;
                        model.Code = num;
                        model.Title = StaticControllers.FirstOrDefault(s => s.Number == num).Title;
                        model.Url = Permission.Url;
                        model.IsMenu = true;   
                    }
                    else
                    {
                        var num = Convert.ToInt32(Permission.Title);
                        var controller=StaticControllers.FirstOrDefault(s => s.Number == num);
                        model.SubCode = controller.Number;
                        model.Code =Convert.ToInt32(Permission.SubCode);
                        model.Title = controller.Actions.FirstOrDefault(d=>d.Number == Permission.SubCode).Title;
                        model.Url = Permission.Url;
                        model.IsMenu = false;
                    }
                    var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                    var token = User.FindFirst(_SettingWeb.TokenName).Value;
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                    var Json = JsonConvert.SerializeObject(model);
                    var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                    var Result = Client.PostAsync("api/Permission/Create", Content).Result;
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
                return RedirectToAction("ErrorPage", "Home");
            }


        }

        public async Task<IActionResult> OnPostGetActions(string code)
        {
            try
            {
                var num=Convert.ToInt32(code);
                var ListActions = StaticControllers.FirstOrDefault(d => d.Number == num).Actions;
                return new JsonResult(ListActions);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
