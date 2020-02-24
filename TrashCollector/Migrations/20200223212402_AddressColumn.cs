using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class AddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22f4e57b-8e0b-4a22-921f-4558ad5f1a9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca79320-353e-441d-a75a-8ea5123a7fd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd3aa238-7dda-4ebf-8072-f25b4d521be4");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Address");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ca79320-353e-441d-a75a-8ea5123a7fd7", "848fb83e-2fd6-4adc-ae39-839b00527fd2", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd3aa238-7dda-4ebf-8072-f25b4d521be4", "65923a61-8e35-4c28-aad7-c7cd75105fe1", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22f4e57b-8e0b-4a22-921f-4558ad5f1a9a", "037e8223-7d1d-463a-9ecb-de167c8ae928", "Admin", "ADMIN" });
        }
    }
}
