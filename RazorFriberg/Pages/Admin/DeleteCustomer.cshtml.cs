using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;

namespace RazorFriberg.Pages.Admin
{
    public class DeleteCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public DeleteCustomerModel(IAdmin adminRep)
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

        public async Task<IActionResult> OnPostAsync(int id, int adminId)
        {
            Admin = adminRep.GetAdmin(adminId);
            Customer = adminRep.GetCustomerById(id);
            adminRep.RemoveCustomer(Customer);
            return RedirectToPage("./ListCustomer", Admin);
        }
    }
}
