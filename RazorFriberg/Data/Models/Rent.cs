using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorFriberg.Data.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public Car Car { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RenturnDate { get; set; }
    }
}
