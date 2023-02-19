using Common.ApiResult;
using Common.Setting;
using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Service.ServiceFile;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.Repositories
{
    public class CreateModel : PageModel
    {
        private IHttpClientFactory _httpClientFactory;
        private SettingWeb _SettingWeb;
        private readonly IFileService _fileService;

        public CreateModel(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
            _fileService = fileService;
        }
        public List<BankDto> Banks { get; set; }
        public static List<BankDto> BanksStatic { get; set; }


        public List<DegreeDto> Degrees { get; set; }
        public static List<DegreeDto> DegreesStatic { get; set; }

        public List<CityDto> Cities { get; set; }
        public static List<CityDto> CitiesStatic { get; set; }


        [BindProperty]
        public RepositoryDto RepositoryModel { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var ResultBank = Client.GetAsync("api/Banks/GetAll").Result;
                var ResultDegress = Client.GetAsync("api/Degress/GetAll").Result;
                var ResultCity = Client.GetAsync("api/Cities/GetAll").Result;
                if (ResultBank.IsSuccessStatusCode)
                {
                    Banks = ResultBank.Content.ReadFromJsonAsync<List<BankDto>>().Result;
                    BanksStatic = Banks;
                    Degrees = ResultDegress.Content.ReadFromJsonAsync<List<DegreeDto>>().Result;
                    DegreesStatic = Degrees;
                    Cities = ResultCity.Content.ReadFromJsonAsync<List<CityDto>>().Result;
                    CitiesStatic = Cities;
                    return Page();
                }
                else
                {

                    if (ResultBank.StatusCode == System.Net.HttpStatusCode.Unauthorized)
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
                return RedirectToAction("ErrorPage", "Home");
            }


        }


        public async Task<IActionResult> OnPost(IFormFile File)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    Banks = BanksStatic;
                    Degrees = DegreesStatic;
                    Cities = CitiesStatic;
                    return Page();
                }
                else
                {

                    var savefile = _fileService.Save(File, "Repositories");
                    if (savefile == null)
                    {
                        ModelState.AddModelError("TopPlanImage", "در ثبت فایل  رخ داده است ");
                        Banks = BanksStatic;
                        Degrees = DegreesStatic;
                        Cities = CitiesStatic;
                        return Page();
                    }
                    RepositoryModel.TopPlanImage = savefile;
                    RepositoryModel.Bank = null;
                    RepositoryModel.Degree = null;

                    var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                    var token = User.FindFirst(_SettingWeb.TokenName).Value;
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                    var Json = JsonConvert.SerializeObject(RepositoryModel);
                    var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                    var Result = Client.PostAsync("api/Repositories/Create", Content).Result;
                    if (Result.IsSuccessStatusCode)
                    {
                        ClearStatic();
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        if (Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            ClearStatic();
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
                            ClearStatic();
                            return RedirectToAction("ErrorPage", "Home");
                        }
                    }
                }
            }
            catch (Exception)
            {
                return Page();
                throw;
            }


        }

        private void ClearStatic()
        {
            BanksStatic.Clear();
            DegreesStatic.Clear();
            CitiesStatic.Clear();

        }
    }
}
