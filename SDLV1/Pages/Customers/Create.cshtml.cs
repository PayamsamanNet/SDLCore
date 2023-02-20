using Common.Utilities;
using Core.Enum;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SDLV1.Pages.Customers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CustomerDto Customer { get; set; }

        #region Models
        [BindProperty]
        public RealCustomerCrud RealCustomer { get; set; }
        [BindProperty]
        public ForeignCustomerDto ForeignCustomer { get; set; }
        [BindProperty]
        public LegalCustomerDto LegalCustomerDto { get; set; }
        #endregion


        public List<EnumModel> GenderList { get; set; }
        [ViewData]
        public string customerType { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {







                GenderList = EnumExtensions.GetEnumlist<GenderType>();
                return Page();
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        public async Task<IActionResult> OnPostRealCustomer(string CustomerType)
        {
            try
            {
                var properties = RealCustomer.GetType().GetProperties();
                var isvalid = true;
                foreach (var item in properties)
                {
                    var values = item.GetValue(RealCustomer);
                    var _RequiredAttribute = item.GetCustomAttribute(typeof(RequiredAttribute)) as RequiredAttribute;
                    if (_RequiredAttribute != null && values == "" || values != null)
                    {
                        isvalid = false;
                    }

                }
                return Page();
            }
            catch (Exception)
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostForeignNatioan(string CustomerType)
        {
            try
            {
                if (CustomerType == "RealCustomer")
                {
                    var VlidateProperty = OthersExtensions.ValidateClass(Customer.RealCustomer);
                    if (VlidateProperty.Count != 0)
                    {
                        Customer.TypeCustomer = "RealCustomer";
                        return Page();
                    }

                }
                else if (CustomerType == "ForeignNatioan")
                {

                }
                else if (CustomerType == "LegalCustomer")
                {

                }
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
        public async Task<IActionResult> OnPostLegalCustomer(string CustomerType)
        {
            try
            {
                if (CustomerType == "RealCustomer")
                {
                    var VlidateProperty = OthersExtensions.ValidateClass(Customer.RealCustomer);
                    if (VlidateProperty.Count != 0)
                    {
                        Customer.TypeCustomer = "RealCustomer";
                        return Page();
                    }

                }
                else if (CustomerType == "ForeignNatioan")
                {

                }
                else if (CustomerType == "LegalCustomer")
                {

                }
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
