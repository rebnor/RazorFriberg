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
    public class IndexModel : PageModel
    {
        private readonly IAdmin adminRep;

        public IndexModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }
        public RazorFriberg.Data.Models.Admin Admin { get; set; } = default!;

        public async Task OnGetAsync(Data.Models.Admin admin)
        {
            Admin = adminRep.GetAdmin(admin.Id);
            ViewData["User"] = $"{Admin.UserName} - #{Admin.Id}";
        }
    }
}
