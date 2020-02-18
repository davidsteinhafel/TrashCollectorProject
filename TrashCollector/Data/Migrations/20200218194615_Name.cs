using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24d3a50e-d0bf-4fe0-b773-44fdb2335f47");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "24d3a50e-d0bf-4fe0-b773-44fdb2335f47", "b78d8d3e-1f54-4644-ba17-ef1ff82dd543", "Admin", "ADMIN" });
        }
    }
}
