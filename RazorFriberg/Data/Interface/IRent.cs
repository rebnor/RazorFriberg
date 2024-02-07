using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFriberg.Data.Models;

namespace FribergTest.Data.Interface
{
    public interface IRent
    {
        public Rent AddRent(Car car, Customer customer);

    }
}
