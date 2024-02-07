using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Data.Interface
{
    public interface IHome
    {

        public IEnumerable<Car> GetRentableCars();
        public Car GetCarById(int id);

        public Customer GetCustomerById(int? id);
        public Customer GetCustomerByEmail(string email);
        public Admin GetAdminByUsername(string username);
        public Customer AddCustomer(Customer customer);

        public Rent AddRent(Rent rent);
        public Rent GetRentById(int id);

        IEnumerable<Car> GetAllCars();
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Rent> GetRents();


    }
}
