using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Data
{
    public class RazorFribergContext : DbContext
    {
        public RazorFribergContext (DbContextOptions<RazorFribergContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; } = default!;
        public DbSet<Car> Cars { get; set; }   
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Rent> Rents { get; set; } = default!;

    }
}
