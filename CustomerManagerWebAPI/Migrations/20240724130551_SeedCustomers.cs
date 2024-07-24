using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerManagerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailPermission = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobilePhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmsPermission = table.Column<bool>(type: "bit", nullable: false),
                    CallPermission = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilePhones_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 13, 16, 5, 51, 31, DateTimeKind.Local).AddTicks(5147), new DateTime(2024, 7, 14, 16, 5, 51, 31, DateTimeKind.Local).AddTicks(5114) });

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 2, 16, 5, 51, 31, DateTimeKind.Local).AddTicks(5153), new DateTime(2024, 8, 3, 16, 5, 51, 31, DateTimeKind.Local).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "John", "Doe" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Jane", "Smith" });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "CustomerId", "EmailAddress", "EmailPermission" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", true },
                    { 2, 2, "jane.smith@example.com", false },
                    { 3, 1, "johnny.doe@example.com", true },
                    { 4, 2, "Example@example.com", true }
                });

            migrationBuilder.UpdateData(
                table: "LoyaltyPrograms",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 1, 24, 16, 5, 51, 31, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "LoyaltyPrograms",
                keyColumn: "Id",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2024, 4, 24, 16, 5, 51, 31, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.InsertData(
                table: "MobilePhones",
                columns: new[] { "Id", "CallPermission", "CustomerId", "PhoneNumber", "SmsPermission" },
                values: new object[,]
                {
                    { 1, true, 1, "123-456-7890", true },
                    { 2, false, 2, "987-654-3210", false },
                    { 3, true, 1, "555-555-5555", false }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "admin");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_CustomerId",
                table: "Emails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhones_CustomerId",
                table: "MobilePhones",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "MobilePhones");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "Email");

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 10, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7250), new DateTime(2024, 7, 11, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7217) });

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 30, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7253), new DateTime(2024, 7, 31, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7252) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "john.doe@example.com", "John Doe" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "jane.smith@example.com", "Jane Smith" });

            migrationBuilder.UpdateData(
                table: "LoyaltyPrograms",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 1, 21, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "LoyaltyPrograms",
                keyColumn: "Id",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2024, 4, 21, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "Admin");
        }
    }
}
