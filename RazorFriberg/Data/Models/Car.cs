using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RazorFriberg.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Brand { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string CarModel { get; set; }
        [Required]
        public double PricePerDay { get; set; }
        [Required]
        public bool IsRented { get; set; } = false;

        public string Picture { get; set; }

    }
}
