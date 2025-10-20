using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profile.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("a3c1781e-b723-4a42-bb43-de08f9845154"));

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "About", "Address", "Age", "Email", "Instagram", "LinkedIn", "Name", "PhoneNumber", "Skills", "Title" },
                values: new object[] { new Guid("5103e5e5-d93f-4a6e-91e8-202dc42162b0"), "~to be edited~", "~to be edited~", 0, "~to be edited~", "~to be edited~", "~to be edited~", "~to be edited~", "~to be edited~", "~to be edited~", "~to be edited~" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("5103e5e5-d93f-4a6e-91e8-202dc42162b0"));

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "About", "Address", "Age", "Email", "Instagram", "LinkedIn", "Name", "PhoneNumber", "Skills", "Title" },
                values: new object[] { new Guid("a3c1781e-b723-4a42-bb43-de08f9845154"), "~to be edited~", "~to be edited~", 0, "~to be edited~", "~to be edited~", "~to be edited~", "~to be edited~", "~to be edited~", "~to be edited~", "~to be edited~" });
        }
    }
}
