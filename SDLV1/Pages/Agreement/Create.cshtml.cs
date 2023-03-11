using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SDLV1.Pages.Agreement
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public AgreementDto Agreement { get; set; } 
        public async Task<IActionResult> OnGet()
        {
			try
			{
				return Page();
			}
			catch (Exception ex)
			{
                return Page();
            }

        }
    }
}
