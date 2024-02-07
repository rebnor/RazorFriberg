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
    public class DetailsCarModel : PageModel
    {
        private readonly IAdmin adminRep;

        public DetailsCarModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public Car Car { get; set; } = default!;
        public Data.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int adminId)
        {
            var car = adminRep.GetCarById(id);
            var admin = adminRep.GetAdmin(adminId);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            Admin = admin;
            return Page();
        }
    }
}
