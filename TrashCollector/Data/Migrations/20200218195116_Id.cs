using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d47a729-6270-4563-b15d-0732bfb72a25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "994fef01-5688-482a-866b-4f859e5665a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0a243fc-1af8-468c-8116-6c741fbddafd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edda59d4-6b0e-4fa6-ac1f-72d6a5493d3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "8a64ba68-bb7d-4487-9008-7d6371b7bf2c", "Admin", "ADMIN" },
                    { "2", "b1f2f4fb-caf9-4cda-a86c-2d9b44608457", "User", "USER" },
                    { "3", "d7cb634f-a688-46aa-b1d2-425bfaa663ed", "Customer", "CUSTOMER" },
                    { "4", "121007dd-810d-47c5-bcc4-baa50875eb0d", "Employee", "EMPLOYEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "994fef01-5688-482a-866b-4f859e5665a2", "2f0966b0-8920-4af2-a443-96d960a55d2a", "Admin", "ADMIN" },
                    { "edda59d4-6b0e-4fa6-ac1f-72d6a5493d3c", "15846ad7-a8e8-4cad-ad90-e8342e04816e", "User", "USER" },
                    { "4d47a729-6270-4563-b15d-0732bfb72a25", "83b43526-ac0f-418c-a3b8-71a066d71fd3", "Customer", "CUSTOMER" },
                    { "a0a243fc-1af8-468c-8116-6c741fbddafd", "b53a81bd-445e-4d69-b33c-b7fc286c0d4b", "Employee", "EMPLOYEE" }
                });
        }
    }
}
