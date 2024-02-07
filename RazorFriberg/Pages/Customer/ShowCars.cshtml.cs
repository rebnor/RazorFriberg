﻿using System;
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
    public class ShowCarsModel : PageModel
    {
        private readonly ICustomer cusRep;

        public ShowCarsModel(Data.Interface.ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }

        public IList<Car> TheCars { get;set; } = default!;
        public Data.Models.Customer Customer { get; set; }
        public Data.Models.Car Car { get; set; }
        public Data.Models.Rent Rent { get; set; } = new Rent();


        public async Task OnGetAsync(Data.Models.Customer customer)
        {
            var c = cusRep.GetCustumer(customer.Id);
            TheCars = await cusRep.GetRentableCarsAsync();
            Customer = c;
        }

        // TODO: Får bara in customerID?
        //public async Task<IActionResult> OnPostAsync(Data.Models.Car car, Data.Models.Customer customer)
        //{
        //    var theCar = cusRep.GetCarById(car.Id);
        //    Car = theCar;

        //    var theCustomer = cusRep.GetCustumer(customer.Id);
        //    Customer = theCustomer;

        //    Rent.Customer = Customer;
        //    Rent.Car = theCar;
        //    return RedirectToPage("CreateRent", "WithRent", Rent);
        //}
    }
}
