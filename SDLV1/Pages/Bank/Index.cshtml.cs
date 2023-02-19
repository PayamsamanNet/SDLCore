using Common.ApiResult;
using Common.Pagination;
using Common.Setting;
using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace SDLV1.Pages.Bank
{
    public class IndexModel : PageModel
    {
        private IHttpClientFactory _httpClientFactory;
        private SettingWeb _SettingWeb;
        public IndexModel(IHttpClientFactory httpClientFactory, IOptions<SettingWeb> options)
        {
            _httpClientFactory = httpClientFactory;
            _SettingWeb = options.Value;
        }
        //GetByPagination(PagedResponse<BankDto> pagedResponse)
        public PagedResponse<List<BankDto>> Banks { get; set; }
        public PagedResponse<BankDto> paged { get; set; } = new PagedResponse<BankDto>(0, 0, null);


        public async Task<IActionResult> OnGet()
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Js = JsonConvert.SerializeObject(paged);

                var Content = new StringContent(Js, Encoding.UTF8, "application/json");
                var Result = Client.PostAsync("api/Banks/GetByPagination", Content).Result;
                if (Result.IsSuccessStatusCode)
                {
                    var Model = Result.Content.ReadFromJsonAsync<PagedResponse<List<BankDto>>>();
                    Banks = Model.Result;
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
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<IActionResult> OnGetPagintion(int Pagenumber)
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                paged.PageNumber = Pagenumber;
                var Js = JsonConvert.SerializeObject(paged);
                var Content = new StringContent(Js, Encoding.UTF8, "application/json");
                var Result = Client.PostAsync("api/Banks/GetByPagination", Content).Result;
                if (Result.IsSuccessStatusCode)
                {
                    var Model = Result.Content.ReadFromJsonAsync<PagedResponse<List<BankDto>>>();
                    Banks = Model.Result;
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
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        public IActionResult OnPostDelete(string Id)
        {
            try
            {
                var Client = _httpClientFactory.CreateClient(_SettingWeb.ClinetName);
                var token = User.FindFirst(_SettingWeb.TokenName).Value;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_SettingWeb.TokenType, token);
                var Result = Client.DeleteAsync("api/Banks/Delete?Id=" + Id + "").Result;
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
                        ModelState.AddModelError("DeleteError", Error.Result.Message);

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
                return RedirectToAction("ErrorPage", "Home");
            }
        }
    }
}
