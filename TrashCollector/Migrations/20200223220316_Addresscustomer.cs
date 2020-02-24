using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class Addresscustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "063e8f18-7eaf-4d1e-aa0d-7a63ea18cbdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b1bd7c7-a5bb-4af5-9739-6beb65db6740");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d052400d-ef6f-4b00-9a60-9e03467075e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba2b1e31-4ef1-4e5f-92a1-ba841817ec28", "4b25d9d0-c0cf-445a-b73b-49c46c020b9c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "832072a5-49e7-4d5d-a0dd-5e313496c67e", "af0f5dce-e910-4d57-9fca-7db44b8e14ab", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "256bb699-b004-4ecf-b36a-02f0b3e9a3fc", "4d66777d-eb68-49f2-8790-9f39bbe8d54c", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "256bb699-b004-4ecf-b36a-02f0b3e9a3fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832072a5-49e7-4d5d-a0dd-5e313496c67e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba2b1e31-4ef1-4e5f-92a1-ba841817ec28");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "063e8f18-7eaf-4d1e-aa0d-7a63ea18cbdf", "18a59fb8-baef-4ed8-9365-537ed65f996d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b1bd7c7-a5bb-4af5-9739-6beb65db6740", "1a094f74-ecda-4c65-b4eb-84c0e64897cd", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d052400d-ef6f-4b00-9a60-9e03467075e0", "4ee9098e-6681-467b-87c3-d96fbb104610", "Admin", "ADMIN" });
        }
    }
}
