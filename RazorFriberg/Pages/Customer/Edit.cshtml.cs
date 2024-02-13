using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;

namespace RazorFriberg.Pages.Customer
{
    public class EditModel : PageModel
    {

        private readonly ICustomer cusRep;
        public EditModel(Data.Interface.ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }

        [BindProperty]
        public Data.Models.Customer Customer { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = cusRep.GetCustumer(id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }
        // TODO: Gör spara knappen osynlig tills person ändrat något
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            cusRep.UpdateSaveCustomer(Customer);
            return RedirectToPage("./Index", Customer);
        }

    }
}
