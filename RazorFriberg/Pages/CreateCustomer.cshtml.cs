using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorFriberg.Data;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages
{
    public class CreateCustomerModel : PageModel
    {
        private readonly IHome homeRep;

        public CreateCustomerModel(IHome homeRep)
        {
            this.homeRep = homeRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Data.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customer = homeRep.AddCustomer(Customer);

            return RedirectToPage("NewCustomerConfirmed", customer);
        }
    }
}
