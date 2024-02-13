using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;

namespace RazorFriberg.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomer cusRep;

        public IndexModel(Data.Interface.ICustomer cusRep)
        {
            this.cusRep = cusRep;
        }

        public Data.Models.Customer Customer { get; set; } = default!;

        public async Task OnGetAsync(Data.Models.Customer customer) 
        {
            if (customer.Id == 0)
            {
                RedirectToPage("./Pages/Index");
            }
            if (customer.FirstName == null)
            {
                var c = cusRep.GetCustumer(customer.Id);
                customer = c;
            }
            ViewData["User"] = $"{customer.FirstName} {customer.LastName}";
            Customer = customer;
        }
    }
}
