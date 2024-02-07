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

namespace RazorFriberg.Pages.Customer
{
    public class BookingConfirmedModel : PageModel
    {
        private readonly ICustomer cusRep;

        public BookingConfirmedModel(ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }

        public Rent Rent { get; set; } = default!;
        public Data.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["TotalPrice"] = "";
            var rent = await cusRep.GetRentById(id);
            var customer = cusRep.GetCustumer(rent.Customer.Id);
            if (rent == null)
            {
                return NotFound();
            }
            else
            {
                // TODO: Totalpris blir med tid 00:00:00 ? 
                Rent = rent;
                Customer = customer;
                ViewData["TotalPrice"] = $"{(Rent.RenturnDate.Date.Date - Rent.StartDate.Date.Date) * Rent.Car.PricePerDay}";
            }
            return Page();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var rent = await _context.Rents.FirstOrDefaultAsync(m => m.Id == id);
            //if (rent == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    Rent = rent;
            //}
            //return Page();
        }
    }
}
