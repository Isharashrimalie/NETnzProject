using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdatafptdifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2e503a55-8cd6-4002-887b-8d8d025211bf"), "Easy" },
                    { new Guid("3535f08a-e81b-4b43-8a0a-14a525b9b9d8"), "Medium" },
                    { new Guid("c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("607ebf8f-c366-44e2-b179-b013032e6d89"), "NI", "North Island", "https://example.com/north-island.jpg" },
                    { new Guid("78220e2c-7d7b-4599-92a2-ceba96037fb7"), "AU", "Australia", "https://example.com/australia.jpg" },
                    { new Guid("aa4c7097-4c1b-4521-8864-2af5f4ca738d"), "SI", "South Island", "https://example.com/south-island.jpg" },
                    { new Guid("c4c75b77-ee43-4393-b1c4-c98db8052516"), "OT", "Other Island", "https://example.com/other-island.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2e503a55-8cd6-4002-887b-8d8d025211bf"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3535f08a-e81b-4b43-8a0a-14a525b9b9d8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("607ebf8f-c366-44e2-b179-b013032e6d89"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("78220e2c-7d7b-4599-92a2-ceba96037fb7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("aa4c7097-4c1b-4521-8864-2af5f4ca738d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c4c75b77-ee43-4393-b1c4-c98db8052516"));
        }
    }
}
