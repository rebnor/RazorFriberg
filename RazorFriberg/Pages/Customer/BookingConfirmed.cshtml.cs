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

        [BindProperty]
        public Rent Rent { get; set; } = default!;
        public Data.Models.Customer Customer { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            ViewData["TotalPrice"] = "";
            var rent = await cusRep.GetRentById(id);
            var customer = cusRep.GetCustumer(rent.Customer.Id);

            Rent = rent;
            Customer = customer;
            ViewData["TotalPrice"] = $"{(Rent.RenturnDate.Date - Rent.StartDate.Date).TotalDays * Rent.Car.PricePerDay}";
        }
    }
}
