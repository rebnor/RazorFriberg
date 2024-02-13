using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages
{
    public class NewCustomerConfirmedModel : PageModel
    {
        private readonly IHome homeRep;

        public NewCustomerConfirmedModel(IHome homeRep)
        {
            this.homeRep = homeRep;
        }

        public Data.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var customer = homeRep.GetCustomerById(id);
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
    }
}
