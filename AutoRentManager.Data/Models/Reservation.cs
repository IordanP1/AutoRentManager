using System.ComponentModel.DataAnnotations;

namespace AutoRentManager.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using static AutoRentManager.Data.Common.ValidationConstants;
    using static AutoRentManager.Data.Enums.ReservationStatus;

    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(typeof(decimal), TotalPriceMinValue,
            TotalPriceMaxValue)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalPrice { get; set; }
        public ReservationStatuses Status { get; set; }
        = ReservationStatuses.Pending;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
