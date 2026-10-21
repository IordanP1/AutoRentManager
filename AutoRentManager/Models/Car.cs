using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRentManager.Models
{
    using static Common.ValidationConstants;
    using static Enums.CarCategoryType;
    using static Enums.FuelType;
    using static Enums.TransmissionType;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CarBrandMaxLength,
            MinimumLength = CarBrandMinLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(CarModelMaxLength,
            MinimumLength = CarModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(2010,2026)]
        public int Year { get; set; }

        [Required]
        public CarCategoryTypes Category { get; set; }

        [StringLength(CarDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [StringLength(CarImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(CarRegistrationNumberLength)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), CarPricePerDayMinValue, CarPricePerDayMaxValue)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PricePerDay { get; set; }

        [Required]
        public FuelTypes FuelType { get; set; }

        [Required]
        public TransmissionTypes TransmissionType { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
            = new List<Reservation>();
    }
}
