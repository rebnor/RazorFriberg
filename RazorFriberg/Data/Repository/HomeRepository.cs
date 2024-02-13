using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Data.Repository
{
    public class HomeRepository : IHome
    {
        private readonly RazorFribergContext appDBctx;
        public HomeRepository(RazorFribergContext appDBctx)
        {
            this.appDBctx = appDBctx;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return appDBctx.Customers.FirstOrDefault(c => c.Email == email);
        }
        public Customer GetCustomerPassword(string password)
        {
            return appDBctx.Customers.FirstOrDefault(c => c.Password == password);
        }
        public Customer AddCustomer(Customer customer)
        {
            appDBctx.Add(customer);
            appDBctx.SaveChanges();
            return customer;
        }
        public Customer GetCustomerById(int? id)
        {
            return appDBctx.Customers.FirstOrDefault(c => c.Id == id);
        }


        public Admin GetAdminByUsername(string username)
        {
            return appDBctx.Admins.FirstOrDefault(a => a.UserName == username);
        }
        public Admin GetAdminPassword(string password)
        {
            return appDBctx.Admins.FirstOrDefault(a => a.Password == password);
        }


        public Car GetCarById(int? id)
        {
            return appDBctx.Cars.FirstOrDefault(c => c.Id == id);
        }
        public Task<List<Car>> GetAllCars()
        {
            return appDBctx.Cars.OrderBy(c => c.PricePerDay).ToListAsync();
        }
    }
}
