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

namespace RazorFriberg.Pages.Admin
{
    public class DeleteRentModel : PageModel
    {
        private readonly IAdmin adminRep;

        public DeleteRentModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        [BindProperty]
        public Rent Rent { get; set; } = default!;
        [BindProperty]
        public Data.Models.Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id, int adminid)
        {
            Rent = adminRep.GetRent(id);
            Admin = adminRep.GetAdmin(adminid);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, int adminid)
        {
            Rent = adminRep.GetRent(id);
            adminRep.RemoveRent(Rent);
            Admin = adminRep.GetAdmin(adminid);
            return RedirectToPage("./Index", Admin);
        }
    }
}
