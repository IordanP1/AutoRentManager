namespace AutoRentManager.Common
{
    public class ValidationConstants
    {
        // Car

        public const int CarBrandMinLength = 2;
        public const int CarBrandMaxLength = 50;

        public const int CarModelMinLength = 2;
        public const int CarModelMaxLength = 50;

        public const int CarDescriptionMaxLength = 500;

        public const int CarImageUrlMaxLength = 2048;

        public const int CarRegistrationNumberLength = 8;

        public const string CarPricePerDayMinValue = "0.01";
        public const string CarPricePerDayMaxValue = "10000";

        //Customer
        public const int CustomerFirstNameMinLength = 2;
        public const int CustomerFirstNameMaxLength = 50;

        public const int CustomerLastNameMinLength = 2;
        public const int CustomerLastNameMaxLength = 50;

        public const int CustomerEmailMinLength = 5;
        public const int CustomerEmailMaxLength = 100;

        public const int CustomerPhoneNumberLength = 10;

        //Reservation
        public const string TotalPriceMinValue = "0.01";
        public const string TotalPriceMaxValue = "100000";

    }
}
