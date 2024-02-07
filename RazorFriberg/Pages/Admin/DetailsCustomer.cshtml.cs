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
    public class DetailsCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public DetailsCustomerModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public Data.Models.Customer Customer { get; set; } = default!;
        public Data.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, int adminid)
        {
            Customer = adminRep.GetCustomerById(id);
            Admin = adminRep.GetAdmin(adminid);
            return Page();
        }
    }
}
