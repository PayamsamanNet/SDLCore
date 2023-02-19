using Common.ApiResult;
using Common.Setting;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.Branch
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
        public BranchDto Branch { get; set; }

        #region Relations

        public List<BranchManagerDto> BranchManagers { get; set; }

        public List<BankDto> Banks { get; set; }

        public List<DegreeDto> Degrees { get; set; }


        public List<RegionCodeDto> Regions { get; set; }

        public List<CityDto> Cities { get; set; }

        #endregion
        #region Static
        public static List<BranchManagerDto> BranchManagersStatic { get; set; }
        public static List<BankDto> BanksStatic { get; set; }
        public static List<DegreeDto> DegreesStatic { get; set; }
        public static List<RegionCodeDto> RegionsStatic { get; set; }
        public static List<CityDto> CitiesStatic { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(string Id)
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/Branches/GetById?Id=" + Id + "").Result;
                var ResultBank = Client.GetAsync("api/Banks/GetAll").Result;
                var ResultBranchManager = Client.GetAsync("api/BranchManagers/GetAll").Result;
                var ResultDegree = Client.GetAsync("api/Degress/GetAll").Result;
                var ResultRegionCodes = Client.GetAsync("api/RegionCodes/GetAll").Result;
                var ResultCity = Client.GetAsync("api/Cities/GetAll").Result;
                if (Result.IsSuccessStatusCode)
                {

                    Branch = Result.Content.ReadFromJsonAsync<BranchDto>().Result;
                    BranchManagers = ResultBranchManager.Content.ReadFromJsonAsync<List<BranchManagerDto>>().Result;
                    BranchManagersStatic = BranchManagers;

                    Banks = ResultBank.Content.ReadFromJsonAsync<List<BankDto>>().Result;
                    BanksStatic = Banks;

                    Degrees = ResultDegree.Content.ReadFromJsonAsync<List<DegreeDto>>().Result;
                    DegreesStatic = Degrees;

                    Regions = ResultRegionCodes.Content.ReadFromJsonAsync<List<RegionCodeDto>>().Result;
                    RegionsStatic = Regions;

                    Cities = ResultCity.Content.ReadFromJsonAsync<List<CityDto>>().Result;
                    CitiesStatic = Cities;
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
                        return RedirectToPage("Index");
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




        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BranchManagers = BranchManagersStatic;
                    Banks = BanksStatic;
                    Degrees = DegreesStatic;
                    Regions = RegionsStatic;
                    Cities = CitiesStatic;
                    return Page();
                }
                else
                {
                    var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                    var token = User.FindFirst(_SettingWeb.TokenName).Value;
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                    var Json = JsonConvert.SerializeObject(Branch);
                    var Content = new StringContent(Json, Encoding.UTF8, "application/json");
                    var Result = Client.PutAsync("api/Branches/Update", Content).Result;
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
                            ModelState.AddModelError("EditError", Error.Result.Message);
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
            BranchManagersStatic.Clear();
            BanksStatic.Clear();
            DegreesStatic.Clear();
            RegionsStatic.Clear();
            CitiesStatic.Clear();
        }

    }
}
