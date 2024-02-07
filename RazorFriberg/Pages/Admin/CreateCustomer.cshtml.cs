using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages.Admin
{
    public class CreateCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public CreateCustomerModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IActionResult OnGet(int id)
        {
            Admin = adminRep.GetAdmin(id);
            return Page();
        }

        [BindProperty]
        public Data.Models.Customer Customer { get; set; } = default!;
        [BindProperty]
        public Data.Models.Admin Admin { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Data.Models.Customer customer, Data.Models.Admin admin)
        {
            Admin = adminRep.GetAdmin(admin.Id);
            adminRep.AddCustomer(customer);
            return RedirectToPage("./Index", Admin);
        }
    }
}
