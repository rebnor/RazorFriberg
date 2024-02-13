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
using RazorFriberg.Data.Repository;

namespace RazorFriberg.Pages
{
    public class LogInAdminModel : PageModel
    {
        private readonly IHome homeRep;

        public LogInAdminModel(IHome homeRep)
        {
            this.homeRep = homeRep;
        }

        [BindProperty]
        public Data.Models.Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Data.Models.Admin admin)
        {

            if (admin != null)
            {
                ViewData["Wrong"] = "";
                var theAdmin = new Data.Models.Admin();
                var au = homeRep.GetAdminByUsername(admin.UserName); // letar username
                var ap = homeRep.GetAdminPassword(admin.Password); // letar password

                if (au == null)
                {
                    ViewData["Wrong"] = "Fel Användarnamn!";
                    return Page();
                }
                if (ap == null)
                { 
                    ViewData["Wrong"] = "Fel Lösenord!";
                    return Page();
                }

                if (ap == au) // kollar att de är samma 
                {
                    theAdmin = au;
                    return RedirectToPage("./Admin/Index", theAdmin); // loggas in
                }
            }
            return Page();
        }
    }
}
