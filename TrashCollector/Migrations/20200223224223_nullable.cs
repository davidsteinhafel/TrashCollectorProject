using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

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

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84cd3746-57d9-4d2c-9279-be795e5eea68", "7e55dba3-5b83-4a01-a7fa-ffb1ede85c38", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c98bfb20-2875-4340-91b5-63719ac05225", "4b02fabe-cbc0-4b2c-92ae-8aff09fd3889", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19b5141d-467a-45bf-964c-30b9c3a66c2c", "7d254072-c191-404b-9b22-549327e30d26", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19b5141d-467a-45bf-964c-30b9c3a66c2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84cd3746-57d9-4d2c-9279-be795e5eea68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c98bfb20-2875-4340-91b5-63719ac05225");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
