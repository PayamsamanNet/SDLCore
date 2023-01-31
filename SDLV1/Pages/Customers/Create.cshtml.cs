using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SDLV1.Pages.Customers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CustomerDto Customer { get; set; }
        public async Task<IActionResult> OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var dd = Customer;
                if (ModelState.IsValid)
                {

                }

                //!TryValidateModel(Movie, nameof(Movie)


                return Page();
            }
            catch (Exception)
            {
                return Page();
            }

           
        }
    }
}
