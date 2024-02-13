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
    public class DeleteRentModel : PageModel
    {
        private readonly ICustomer cusRep;

        public DeleteRentModel(Data.Interface.ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }

        [BindProperty]
        public Rent Rent { get; set; } = default!;
        public Data.Models.Customer Customer { get; set; }

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
                Rent = rent;
                Customer = customer;
                ViewData["TotalPrice"] = $"{(Rent.RenturnDate.Date - Rent.StartDate.Date).TotalDays * Rent.Car.PricePerDay}";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var rent = await cusRep.GetRentById(id);
            var customer = cusRep.GetCustumer(rent.Customer.Id);
            if (rent != null)
            {
                cusRep.RemoveBooking(rent);
            }
            return RedirectToPage("MyRents", customer);
        }
    }
}
