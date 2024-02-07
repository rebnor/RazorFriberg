using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Pages.Admin
{
    public class ListRentModel : PageModel
    {
        private readonly IAdmin adminRep;

        public ListRentModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IEnumerable<Rent> Rent { get;set; } = default!;
        public Data.Models.Admin Admin { get; set; }


        public async Task OnGetAsync(int id)
        {
            Admin = adminRep.GetAdmin(id);
            Rent = adminRep.GetRents();
        }
    }
}
