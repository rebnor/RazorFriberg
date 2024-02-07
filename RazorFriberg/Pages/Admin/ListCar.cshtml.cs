using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages.Admin
{
    public class ListCarModel : PageModel
    {
        private readonly IAdmin adminRepo;

        public ListCarModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public IList<Car> Car { get;set; } = default!;
        public Data.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) // TODO: Varför blir int null här?
        {
            Admin = adminRepo.GetAdmin(id);
            Car = await adminRepo.GetAllCarsAsync();
            return Page();

        }
    }
}
