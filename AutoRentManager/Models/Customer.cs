using System.ComponentModel.DataAnnotations;

namespace AutoRentManager.Models
{
    using static Common.ValidationConstants;
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CustomerFirstNameMaxLength,
            MinimumLength = CustomerFirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(CustomerLastNameMaxLength,
            MinimumLength = CustomerLastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(CustomerEmailMaxLength,
            MinimumLength = CustomerEmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(CustomerPhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Reservation> Reservations { get; set; }
            = new List<Reservation>();
    }
}
