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

namespace RazorFriberg.Pages
{
    public class DetailsCarModel : PageModel
    {
        private readonly IHome homeRep;

        public DetailsCarModel(IHome homeRep)
        {
            this.homeRep = homeRep;
        }

        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var car = homeRep.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }
    }
}
