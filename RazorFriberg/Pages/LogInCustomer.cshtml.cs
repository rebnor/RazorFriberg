using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;

namespace RazorFriberg.Pages
{
    public class LogInCustomerModel : PageModel
    {
        private readonly IHome homeRep;

        public LogInCustomerModel(IHome homeRep)
        {
            this.homeRep = homeRep;
        }

        [BindProperty]
        public Data.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Data.Models.Customer customer)
        {
            if (customer != null)
            {
                ViewData["Wrong"] = "";
                var theCustomer = new Data.Models.Customer();
                var ce = homeRep.GetCustomerByEmail(customer.Email); // letar email
                var cp = homeRep.GetCustomerPassword(customer.Password); // letar lösen

                if (ce == null) 
                {
                    ViewData["Wrong"] = "Fel Email!";
                    return Page();
                }

                if (cp == null)
                {
                    ViewData["Wrong"] = "Fel Lösenord!";
                    return Page();
                }

                if (cp == ce) // ser att email och lösen är samma
                {
                    theCustomer = ce;
                    return RedirectToPage("Customer/Index", theCustomer); // loggar in
                }
                else
                {
                    ViewData["Wrong"] = "Fel Email eller Lösenord!";
                }
            }
            return Page();

        }
    }
}
