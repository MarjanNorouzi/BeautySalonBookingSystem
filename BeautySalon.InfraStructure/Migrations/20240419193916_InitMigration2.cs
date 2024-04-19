using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalon.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ae3eeda-c45f-4307-b749-50276bfc37e1"),
                column: "ConcurrencyStamp",
                value: "66630827-3a85-49bc-bb07-1d49f8cd5381");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5209521b-738a-44db-9771-fbb29d1a321a"),
                column: "ConcurrencyStamp",
                value: "4298b909-6511-4ca7-977a-c6d4629d854e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a039fb2-86d2-401d-bdf4-7c5d325c38b4"),
                column: "ConcurrencyStamp",
                value: "42b079e1-f854-4516-9e19-3976f995791d");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ae3eeda-c45f-4307-b749-50276bfc37e1"),
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5209521b-738a-44db-9771-fbb29d1a321a"),
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a039fb2-86d2-401d-bdf4-7c5d325c38b4"),
                column: "ConcurrencyStamp",
                value: null);
        }
    }
}
