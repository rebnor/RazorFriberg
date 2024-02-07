using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorFriberg.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [MinLength(3)]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
