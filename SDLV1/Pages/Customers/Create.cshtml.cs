using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SDLV1.Pages.Customers
{
    public class CreateModel : PageModel
    {

        public CustomerDto Customer { get; set; }
        public async Task<IActionResult> OnGet()
        {

            return Page();
        }
    }
}
