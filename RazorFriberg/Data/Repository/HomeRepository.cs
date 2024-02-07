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

        public IEnumerable<Car> GetRentableCars()
        {
            return appDBctx.Cars.Where(c=>c.IsRented == false);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return appDBctx.Customers.FirstOrDefault(c=>c.Email == email);
        }

        public Admin GetAdminByUsername(string username)
        {
            return appDBctx.Admins.FirstOrDefault(a=>a.UserName == username);
        }

        public Customer AddCustomer(Customer customer)
        {
            appDBctx.Add(customer);
            appDBctx.SaveChanges();
            return customer;
        }

        public Car GetCarById(int id)
        {
            return appDBctx.Cars.FirstOrDefault(c=>c.Id == id);
        }

        public Rent AddRent(Rent rent)
        {
            appDBctx.Add(rent);
            appDBctx.SaveChanges();
            return rent; 
        }

        public Customer GetCustomerById(int? id)
        {
            return appDBctx.Customers.FirstOrDefault(c=>c.Id == id);
        }

        public Rent GetRentById(int id)
        {
            return appDBctx.Rents.FirstOrDefault(r=>r.Id == id);
        }


        public IEnumerable<Car> GetAllCars()
        {
            return appDBctx.Cars.OrderBy(c => c.Brand);
        }


        public IEnumerable<Customer> GetAllCustomers()
        {
            return appDBctx.Customers.OrderBy(c => c.Id);
        }
        public IEnumerable<Rent> GetRents()
        {
            return appDBctx.Rents.OrderBy(r => r.StartDate);
        }



    }
}
