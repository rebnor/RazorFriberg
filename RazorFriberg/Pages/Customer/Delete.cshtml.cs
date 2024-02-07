using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;

namespace RazorFriberg.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomer cusRep;

        public DeleteModel(Data.Interface.ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }

        [BindProperty]
        public Data.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var customer = cusRep.GetCustumer(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var customer = cusRep.GetCustumer(id);
            if (customer != null)
            {
                cusRep.RemoveMembership(customer);
            }

            return RedirectToPage("/Index");
        }
    }
}
