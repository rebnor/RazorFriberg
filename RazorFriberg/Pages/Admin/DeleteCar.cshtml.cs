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
    public class DeleteCarModel : PageModel
    {
        private readonly IAdmin adminRep;

        public DeleteCarModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        [BindProperty]
        public Data.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int adminId)
        {

            var car = adminRep.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
                Admin = adminRep.GetAdmin(adminId);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int adminId)
        {
            var car = adminRep.GetCarById(id);
            if (car != null)
            {
                adminRep.RemoveCar(car);
            }
            Admin = adminRep.GetAdmin(adminId); 
            return RedirectToPage("./Index", Admin);
        }
    }
}
