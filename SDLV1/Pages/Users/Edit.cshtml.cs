using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using Common.Setting;
using Microsoft.Extensions.Options;
using Common.ApiResult;
using Data.Dto;
using Common.Utilities;
using Core.Enum;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using Service.ServiceFile;

namespace SDLV1.Pages.Users
{
    public class EditModel : PageModel
    {
        private IHttpClientFactory _httpClientFactory;
        private SettingWeb _SettingWeb;
        private readonly IFileService _fileService;
        public EditModel(IHttpClientFactory httpClientFactory,IOptions<SettingWeb> options, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
            _fileService = fileService;
        }
        [BindProperty]
        public UserDto UserDto { get; set; }

        public List<RepositoryDto> Repositories { get; set; }
        public static List<RepositoryDto> RepositoriesStatic { get; set; }


        public List<BranchDto> Branches { get; set; }
        public static List<BranchDto> BranchesStatic { get; set; }

        public List<RoleDto> Roles { get; set; }
        public static List<RoleDto> RolesStatic { get; set; }

        public static string OldPassword { get; set; }
        public static string Oldfile { get; set; }
        public List<EnumModel> Genders { get; set; }
        public async Task<IActionResult> OnGet(string Id)
        {
            try
			{
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.GetAsync("api/Users/GetById?Id=" + Id + "").Result;
                var ResultRepo = Client.GetAsync("api/Repositories/GetAll").Result;
                var ResultBranch = Client.GetAsync("api/Branches/GetAll").Result;
                var ResultRole = Client.GetAsync("api/Role/GetAll").Result;
                if (Result.IsSuccessStatusCode)
                {
                    Genders = EnumExtensions.GetEnumlist<GenderType>();
                    UserDto = Result.Content.ReadFromJsonAsync<UserDto>().Result;
                    OldPassword = UserDto.PasswordHash;
                    Oldfile = UserDto.ImageUser;
                    UserDto.PasswordHash = "";
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
            }
            catch (Exception)
			{

				throw;
			}
        }



        public async Task<IActionResult> OnPost(IFormFile File)
        {
            try
            {
                if (UserDto.PasswordHash == null && UserDto.RePassword == null)
                {
                    UserDto.PasswordHash = OldPassword;
                    UserDto.RePassword = OldPassword;
                }
                else
                {
                    UserDto.IsChangePassword = true;
                }
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
                    if (File != null)
                    {
                        var resultDeletefile = _fileService.Delete(Oldfile, "Users");
                        UserDto.ImageUser = _fileService.Save(File, "Users");
                    }
                    var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                    var token = User.FindFirst(_SettingWeb.TokenName).Value;
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                    var Js = JsonConvert.SerializeObject(UserDto);
                    var Content = new StringContent(Js, Encoding.UTF8, "application/json");
                    var Result = Client.PutAsync("api/Users/Update", Content).Result;
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
