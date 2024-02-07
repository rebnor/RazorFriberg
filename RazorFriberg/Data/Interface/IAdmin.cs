using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Models;


namespace RazorFriberg.Data.Interface
{
    public interface IAdmin
    {

        Task<List<Car>> GetAllCarsAsync();
        Car GetCarById(int? id);
        Car AddCar(Car car);
        Car UpdateCar(Car car);
        void RemoveCar(Car car);


        Task<List<Customer>> GetAllCustomersAsync();
        Customer GetCustomerById(int id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);


        IEnumerable<Rent> GetRents();
        Rent GetRent(int id);
        void RemoveRent(Rent rent);


        Admin GetAdmin(int id);
    }
}
