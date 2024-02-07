using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Data.Interface
{
    public interface ICustomer
    {
        public Task<Rent> GetRentById(int? id);
        public Task<List<Car>> GetRentableCarsAsync();
        public Task<List<Rent>> GetMyRentsAsync(Customer customer);
        public Customer GetCustumer(int? id);
        public Customer UpdateSaveCustomer(Customer customer);
        public void RemoveMembership(Customer customer);
        public Car GetCarById(int id);
        public Rent CreateRent(Rent rent);
        public void RemoveBooking(Rent rent);
    }
}
