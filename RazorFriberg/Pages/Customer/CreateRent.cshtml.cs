using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages.Customer
{
    public class CreateRentModel : PageModel
    {
        private readonly ICustomer cusRep;

        public CreateRentModel(Data.Interface.ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }

        [BindProperty]
        public Rent Rent { get; set; } = default!;
        public Data.Models.Customer Customer { get; set; } = default!;
        public Car Car { get; set; } = default!;

        public async Task OnGetAsync(Data.Models.Customer customer)
        {
            Customer = cusRep.GetCustumer(customer.Id);
        }

        public async Task<IActionResult> OnPostAsync(Rent rent, Data.Models.Customer customer)
        {
            rent.Customer = cusRep.GetCustumer(customer.Id);
            var car = cusRep.GetCarById(rent.Car.Id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            rent.Car = car;

            Rent = cusRep.CreateRent(rent);

            return RedirectToPage("BookingConfirmed", new { id = Rent.Id });
        }
    }
}
