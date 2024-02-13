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
        public Customer GetCustomerById(int? id);
        public Customer GetCustomerByEmail(string email);
        public Customer GetCustomerPassword(string email);
        public Customer AddCustomer(Customer customer);

        public Admin GetAdminByUsername(string username);
        public Admin GetAdminPassword(string password);

        public Car GetCarById(int? id);
        Task<List<Car>> GetAllCars();
    }
}
