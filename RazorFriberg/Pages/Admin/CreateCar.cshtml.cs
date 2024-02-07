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
    public class CreateCarModel : PageModel
    {
        private readonly IAdmin adminRep;

        public CreateCarModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IActionResult OnGet(int id)
        {
            Admin = adminRep.GetAdmin(id);
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        [BindProperty]
        public Data.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnPostAsync(Car car, Data.Models.Admin admin)
        {
            Admin = adminRep.GetAdmin(admin.Id);
            Car.Picture = $"~/css/Pictures/{car.Picture}.jpg";
            adminRep.AddCar(Car);
            return RedirectToPage("./Index", Admin);
        }
    }
}
