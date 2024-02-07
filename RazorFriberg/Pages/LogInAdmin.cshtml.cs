using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data;

namespace RazorFriberg.Pages
{
    public class LogInAdminModel : PageModel
    {
        private readonly RazorFribergContext _context;

        public LogInAdminModel(RazorFribergContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Data.Models.Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Data.Models.Admin admin)
        {

            if (admin != null)
            {
                ViewData["Wrong"] = "";
                var theAdmin = new Data.Models.Admin();
                if (!UserNameExists(admin.UserName)) // letar username
                {
                    ViewData["Wrong"] = "Fel Användarnamn!";
                    return Page();
                }
                if (!PasswordExists(admin.Password)) // letar password
                { 
                    ViewData["Wrong"] = "Fel Lösenord!";
                    return Page();
                }
                var ap = new Data.Models.Admin();
                var au = new Data.Models.Admin();
                ap = _context.Admins.FirstOrDefault(a=>a.Password == admin.Password); // hämtar användare med lösen
                au = _context.Admins.FirstOrDefault(a=>a.UserName == admin.UserName); // hämtar användare med username
                if (ap == au) // kollar att de är samma 
                {
                    theAdmin = au;
                    return RedirectToPage("./Admin/Index", theAdmin); // loggas in
                }
            }
            return Page();
        }

        private bool UserNameExists(string username)
        {
            return _context.Admins.Any(e => e.UserName == username);
        }
        private bool PasswordExists(string password)
        {
            return _context.Admins.Any(e => e.Password == password);
        }
    }
}
