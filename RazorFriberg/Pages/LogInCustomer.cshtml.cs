using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorFriberg.Pages
{
    public class LogInCustomerModel : PageModel
    {
        private readonly RazorFriberg.Data.RazorFribergContext _context;

        public LogInCustomerModel(RazorFriberg.Data.RazorFribergContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Data.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Data.Models.Customer customer)
        {
            if (customer != null)
            {
                ViewData["Wrong"] = "";
                var theCustomer = new Data.Models.Customer();
                if (!EmailExists(customer.Email)) // letar email
                {
                    ViewData["Wrong"] = "Fel Email!";
                    return Page();
                }
                if (!PasswordExists(customer.Password))
                {
                    ViewData["Wrong"] = "Fel Lösenord!";
                    return Page();
                }
                var cp = new Data.Models.Customer();
                var ce = new Data.Models.Customer();
                cp = _context.Customers.FirstOrDefault(a => a.Password == customer.Password);
                ce = _context.Customers.FirstOrDefault(a => a.Email == customer.Email);
                if (cp == ce)
                {
                    theCustomer = ce;
                    return RedirectToPage("Customer/Index", theCustomer);
                }
                else
                {
                    ViewData["Wrong"] = "Fel Email eller Lösenord!";
                }
            }
            return Page();

        }

        private bool EmailExists(string email)
        {
            return _context.Customers.Any(e => e.Email == email);
        }
        private bool PasswordExists(string password)
        {
            return _context.Customers.Any(e => e.Password == password);
        }

    }
}
