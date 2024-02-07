using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;

namespace RazorFriberg.Pages.Admin
{
    public class ListCustomerModel : PageModel
    {
        private readonly IAdmin adminRep;

        public ListCustomerModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IList<Data.Models.Customer> Customer { get;set; } = default!;
        public Data.Models.Admin Admin { get;set; }

        public async Task OnGetAsync(int id)
        {
            Admin = adminRep.GetAdmin(id);
            Customer = await adminRep.GetAllCustomersAsync();
        }
    }
}
