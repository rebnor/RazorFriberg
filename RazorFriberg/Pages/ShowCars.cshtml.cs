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
    public class ShowCarsModel : PageModel
    {
        private readonly IHome homeRep;

        public ShowCarsModel(IHome homeRep)
        {
            this.homeRep = homeRep;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await homeRep.GetAllCars();
        }
    }
}
