using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;

namespace RazorFriberg.Pages.Admin
{
    public class EditCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public EditCustomerModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        [BindProperty]
        public Data.Models.Customer Customer { get; set; } = default!;
        [BindProperty]
        public Data.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, int adminId)
        {
            Customer = adminRep.GetCustomerById(id);
            Admin = adminRep.GetAdmin(adminId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        { 
            adminRep.UpdateCustomer(Customer);
            return RedirectToPage("ListCustomer", Admin);
        }
    }
}
