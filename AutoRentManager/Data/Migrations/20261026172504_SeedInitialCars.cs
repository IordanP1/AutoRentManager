using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoRentManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        SET IDENTITY_INSERT [Cars] ON;

        IF NOT EXISTS (SELECT 1 FROM [Cars] WHERE [Id] = 2)
            INSERT INTO [Cars] ([Id], [Brand], [Category], [Description], [FuelType], [ImageUrl], [Model], [PricePerDay], [RegistrationNumber], [TransmissionType], [Year])
            VALUES (2, 'BMW', 1, 'fast', 0, '/images/cars/bmw760l.jpg', '760L', 299.00, 'CB0000AA', 1, 2024);

        IF NOT EXISTS (SELECT 1 FROM [Cars] WHERE [Id] = 3)
            INSERT INTO [Cars] ([Id], [Brand], [Category], [Description], [FuelType], [ImageUrl], [Model], [PricePerDay], [RegistrationNumber], [TransmissionType], [Year])
            VALUES (3, 'bmw', 3, 'fast', 0, '/images/cars/bmw340i.jpg', '340i', 190.00, 'CB0000AA', 1, 2025);

        IF NOT EXISTS (SELECT 1 FROM [Cars] WHERE [Id] = 4)
            INSERT INTO [Cars] ([Id], [Brand], [Category], [Description], [FuelType], [ImageUrl], [Model], [PricePerDay], [RegistrationNumber], [TransmissionType], [Year])
            VALUES (4, 'Bmw', 2, 'Suv', 0, '/images/cars/bmwX5m.jpg', 'X5m', 340.00, 'CB0030AA', 1, 2025);

        IF NOT EXISTS (SELECT 1 FROM [Cars] WHERE [Id] = 5)
            INSERT INTO [Cars] ([Id], [Brand], [Category], [Description], [FuelType], [ImageUrl], [Model], [PricePerDay], [RegistrationNumber], [TransmissionType], [Year])
            VALUES (5, 'Van', 4, 'Van you can drive around with all of your friends', 2, '/images/cars/van.jpg', 'Exotic', 189.00, 'CB0040AA', 1, 2025);

        IF NOT EXISTS (SELECT 1 FROM [Cars] WHERE [Id] = 6)
            INSERT INTO [Cars] ([Id], [Brand], [Category], [Description], [FuelType], [ImageUrl], [Model], [PricePerDay], [RegistrationNumber], [TransmissionType], [Year])
            VALUES (6, 'BMW', 3, 'Best 5-series', 0, '/images/cars/bmwM5Comp.jpg', 'M5comp', 450.00, 'CB1133AA', 1, 2022);

        IF NOT EXISTS (SELECT 1 FROM [Cars] WHERE [Id] = 8)
            INSERT INTO [Cars] ([Id], [Brand], [Category], [Description], [FuelType], [ImageUrl], [Model], [PricePerDay], [RegistrationNumber], [TransmissionType], [Year])
            VALUES (8, 'BMW', 3, 'Track beast', 0, '/images/cars/bmwM4.jpg', 'M4', 359.00, 'CB0000AA', 1, 2025);

        SET IDENTITY_INSERT [Cars] OFF;
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
