using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages
{
    public class ShowCarsModel : PageModel
    {
        private readonly RazorFriberg.Data.RazorFribergContext _context;

        public ShowCarsModel(RazorFriberg.Data.RazorFribergContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Cars.OrderBy(c=>c.PricePerDay).ToListAsync();
        }
    }
}
