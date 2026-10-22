namespace AutoRentManager.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        public string CarInfo { get; set; } = null!;

        public string CustomerName { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = null!;
    }
}
