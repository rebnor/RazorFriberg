using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Interface;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Data.Repository
{
    public class AdminRepository : IAdmin
    {
        private readonly RazorFribergContext appDBctx;
        public AdminRepository(RazorFribergContext appDBctx)
        {
            this.appDBctx = appDBctx;
        }


        public Car GetCarById(int? id)
        {
            return appDBctx.Cars.FirstOrDefault(c => c.Id == id);
        }
        public Task<List<Car>> GetAllCarsAsync()
        {
            return appDBctx.Cars.OrderBy(c => c.Brand).ToListAsync();
        }
        public Car AddCar(Car car)
        {
            appDBctx.Add(car);
            appDBctx.SaveChanges();
            return car;
        }
        public Car UpdateCar(Car car)
        {
            appDBctx.Update(car);
            appDBctx.SaveChanges();
            return car;
        }
        public void RemoveCar(Car car)
        {
            appDBctx.Remove(car);
            appDBctx.SaveChanges();
        }


        public Customer GetCustomerById(int id)
        {
            return appDBctx.Customers.FirstOrDefault(c => c.Id == id);
        }
        // TODO: Varför blir det att jag måste skriva in interface här?
        Task<List<Customer>> IAdmin.GetAllCustomersAsync()
        {
            return appDBctx.Customers.OrderBy(c => c.Id).ToListAsync();
        }
        public Customer AddCustomer(Customer customer)
        {
            appDBctx.Add(customer);
            appDBctx.SaveChanges();
            return customer;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            appDBctx.Update(customer);
            appDBctx.SaveChanges();
            return customer;
        }
        public void RemoveCustomer(Customer customer)
        {
            appDBctx.Remove(customer);
            appDBctx.SaveChanges();
        }




        public Rent GetRent(int id)
        {
            return appDBctx.Rents.Include(r=>r.Car).Include(r=>r.Customer).FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<Rent> GetRents()
        {
            return appDBctx.Rents.Include(r=>r.Car).Include(r=>r.Customer).OrderBy(r => r.Id);
        }
        public void RemoveRent(Rent rent) 
        {
            appDBctx.Remove(rent);
            appDBctx.SaveChanges();
        }

        public Admin GetAdmin(int id)
        {
            return appDBctx.Admins.FirstOrDefault(a => a.Id == id);
        }

    }
}
