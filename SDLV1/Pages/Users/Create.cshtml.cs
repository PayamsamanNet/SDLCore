using Common.ApiResult;
using Common.Setting;
using Common.Utilities;
using Core.Enum;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.Users
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
        public UserDto UserDto { get; set; }

        public List<RepositoryDto> Repositories { get; set; }
        public static List<RepositoryDto> RepositoriesStatic { get; set; }
        public List<BranchDto> Branches { get; set; }
        public static List<BranchDto> BranchesStatic { get; set; }
        public List<RoleDto> Roles { get; set; }
        public static List<RoleDto> RolesStatic { get; set; }

        public List<EnumModel> Genders { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var ResultRepo = Client.GetAsync("api/Repositories/GetAll").Result;
                var ResultBranch = Client.GetAsync("api/Branches/GetAll").Result;
                var ResultRole = Client.GetAsync("api/Role/GetAll").Result;
                Genders = EnumExtensions.GetEnumlist<GenderType>();

                if (ResultRepo.IsSuccessStatusCode)
                {
                    Repositories = ResultRepo.Content.ReadFromJsonAsync<List<RepositoryDto>>().Result;
                    RepositoriesStatic = Repositories;
                    Branches = ResultBranch.Content.ReadFromJsonAsync<List<BranchDto>>().Result;
                    BranchesStatic = Branches;
                    Roles = ResultRole.Content.ReadFromJsonAsync<List<RoleDto>>().Result;
                    RolesStatic = Roles;
                    return Page();
                }
                else
                {
                    if (ResultRepo.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {

                        return RedirectToAction("SignOut", "Account");
                    }
                    else if (ResultRepo.StatusCode == System.Net.HttpStatusCode.BadRequest)
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

                throw;
            }

        }



        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Genders = EnumExtensions.GetEnumlist<GenderType>();
                    Repositories = RepositoriesStatic;
                    Branches = BranchesStatic;
                    Roles = RolesStatic;
                    return Page();
                }
                if (UserDto.BranchId != null && UserDto.RepositoryId != null)
                {
                    Genders = EnumExtensions.GetEnumlist<GenderType>();
                    Repositories = RepositoriesStatic;
                    Branches = BranchesStatic;
                    Roles = RolesStatic;
                    ModelState.AddModelError("CreateError", "انتخاب کاربر هم زمان برای شعبه و مخزن امکان پذیر نمیباشد ");
                    return Page();
                }

                else
                {
                    var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                    var token = User.FindFirst(_SettingWeb.TokenName).Value;
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                    var Js = JsonConvert.SerializeObject(UserDto);
                    var Content = new StringContent(Js, Encoding.UTF8, "application/json");
                    var Result = Client.PostAsync("api/Users/Create", Content).Result;
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
                            Genders = EnumExtensions.GetEnumlist<GenderType>();
                            Repositories = RepositoriesStatic;
                            Branches = BranchesStatic;
                            Roles = RolesStatic;
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
    }
}
