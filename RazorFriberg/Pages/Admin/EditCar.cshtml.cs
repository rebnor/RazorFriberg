using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages.Admin
{
    public class EditCarModel : PageModel
    {
        private readonly IAdmin adminRepo;

        public EditCarModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        [BindProperty]
        public Data.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int adminId)
        {
            var car = adminRepo.GetCarById(id);
            var admin = adminRepo.GetAdmin(adminId);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            Admin = admin;
            return Page();
        }
        public async Task<RedirectToPageResult> OnPostAsync()
        {
            adminRepo.UpdateCar(Car);
            return RedirectToPage("./Index", Admin);
        }

    }
}
