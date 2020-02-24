using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

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

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12e89d07-629d-47ea-aa5c-bfc79deb3374", "2c8efda5-c210-41cd-a997-57c4c4c73340", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fdffa0e1-47e3-47c1-8d0f-679547b934d2", "b055a398-a57f-4bea-9b2e-5361f1ee9939", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad22ae46-867a-4d18-bbad-8fe19e7f9117", "d9345fb9-cf5e-4e23-a925-2bfbcc5c7f60", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12e89d07-629d-47ea-aa5c-bfc79deb3374");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad22ae46-867a-4d18-bbad-8fe19e7f9117");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdffa0e1-47e3-47c1-8d0f-679547b934d2");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
