using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages.Customer
{
    public class MyRentsModel : PageModel
    {
        private readonly ICustomer cusRep;

        public MyRentsModel(Data.Interface.ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }
        public IList<Rent> Rent { get; set; } = default!;
        public Data.Models.Customer Customer { get; set; } = default!;
        public async Task OnGetAsync(Data.Models.Customer customer)
        {
            if (customer.FirstName == null)
            {
                customer = cusRep.GetCustumer(customer.Id);
            }
            Rent = await cusRep.GetMyRentsAsync(customer);
            Customer = customer;
        }
    }
}
