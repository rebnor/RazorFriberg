using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FribergTest.Data.Interface;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Models;

namespace RazorFriberg.Data.Repository
{
    public class RentRepository : IRent
    {
        public Rent AddRent(Car car, Customer customer)
        {
            Rent rent = new Rent();
            rent.Car = car;
            rent.Customer = customer;   
            return rent;
        }
    }
}
