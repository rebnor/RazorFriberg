using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Data.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly RazorFribergContext appDBctx;
        public CustomerRepository(RazorFribergContext appDBctx)
        {
            this.appDBctx = appDBctx;
        }

        public Task<List<Car>> GetRentableCarsAsync()
        {
            return appDBctx.Cars.Where(c => c.IsRented == false).ToListAsync();

        }
        public Task<List<Rent>> GetMyRentsAsync(Customer customer)
        {
            return appDBctx.Rents.Where(r => r.Customer == customer).Include(r => r.Car).Include(r => r.Customer).OrderByDescending(r=>r.StartDate).ToListAsync();
        }
        public Task<Rent> GetRentById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var rent = appDBctx.Rents.Include(r => r.Car).Include(r=>r.Customer).FirstOrDefaultAsync(m => m.Id == id);
            return rent;
        }
        public Customer GetCustumer(int? id)
        {
            return appDBctx.Customers.FirstOrDefault(c => c.Id == id);
        }
        public Customer UpdateSaveCustomer(Customer customer)
        {
            appDBctx.Attach(customer).State = EntityState.Modified;
            appDBctx.SaveChanges();
            return customer;
        }
        public void RemoveMembership(Customer customer)
        {
            appDBctx.Remove(customer);
            appDBctx.SaveChanges();
        }
        public Car GetCarById(int id)
        {
            return appDBctx.Cars.FirstOrDefault(c=>c.Id == id);
        }
        public Rent CreateRent(Rent rent) 
        {
            appDBctx.Rents.Add(rent);
            //appDBctx.SaveChangesAsync();
            appDBctx.SaveChanges();

            return rent;
        }
        public void RemoveBooking(Rent rent) 
        {
            appDBctx.Rents.Remove(rent);
            appDBctx.SaveChangesAsync();
        }






    }
}
