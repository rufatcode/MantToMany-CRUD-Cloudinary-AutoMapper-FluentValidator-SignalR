using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab10FrontToBack.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserTableAddLastDisconnectedTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85689ac3-894e-4880-ae17-cc3646394a29");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b7abd85e-79e9-4c77-8372-d724a87f42a0", "5535ab69-14b3-435e-9243-0fd2ea15bc3f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2b8afb68-5db0-49da-b232-dc7c9b441400", "69268eb2-2d9c-49d1-bc54-9e1f354a548d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b8afb68-5db0-49da-b232-dc7c9b441400");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7abd85e-79e9-4c77-8372-d724a87f42a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5535ab69-14b3-435e-9243-0fd2ea15bc3f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69268eb2-2d9c-49d1-bc54-9e1f354a548d");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDisconnectedTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03d23889-9741-49e4-99fd-bd7ceb2e69d7", null, "SupperAdmin", "SUPPERADMIN" },
                    { "8e518596-52cd-4980-8615-badf204202d9", null, "User", "USER" },
                    { "e02978e6-97c9-4e01-99a5-69238d6fdad5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Created", "Email", "EmailConfirmed", "FullName", "IsActive", "IsDeleted", "LastDisconnectedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "Removed", "SecurityStamp", "TwoFactorEnabled", "Updated", "UserName", "isOnline" },
                values: new object[,]
                {
                    { "1013b5aa-2060-4a24-89a4-db47c9715e1e", 0, "f062e6fe-4d42-4f55-a2dc-1754f432960a", null, new DateTime(2024, 6, 14, 9, 55, 11, 312, DateTimeKind.Local).AddTicks(2880), "rufatri@code.edu.az", true, "Rufat Azerbaijan", true, false, null, false, null, "RUFATRI@CODE.EDU.AZ", "RUFATCODE", "AQAAAAIAAYagAAAAEOoEYeb+fbi0G/eDfxDSKeXpAEozhGrOlJAbjTa6sRy5zj+2gwa3XRwxIvPvrK9n8Q==", "+994513004484", true, null, null, "a1c21d0f-e623-42c3-992f-54cf207af4a5", false, null, "RufatCode", false },
                    { "b00536e8-b8e3-4f13-89f5-9f2d1d45d5ca", 0, "10329a07-9eff-4f09-a410-512fc66c21eb", null, new DateTime(2024, 6, 14, 9, 55, 11, 312, DateTimeKind.Local).AddTicks(2930), "rft.smayilov@bk.ru", true, "Rufat Code", true, false, null, false, null, "RFT.SMAYILOV@BK.RU", "RUFAT_2003", "AQAAAAIAAYagAAAAENFUJlbVs1j1yYLFeb26WGeqdjqmf3Em12jUHx3HTk4H7NGimHvTTSrFfatdpEb5/Q==", "+994513004484", true, null, null, "568411c3-a2fa-4108-bb91-9e2f01720fed", false, null, "Rufat_2003", false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e02978e6-97c9-4e01-99a5-69238d6fdad5", "1013b5aa-2060-4a24-89a4-db47c9715e1e" },
                    { "03d23889-9741-49e4-99fd-bd7ceb2e69d7", "b00536e8-b8e3-4f13-89f5-9f2d1d45d5ca" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e518596-52cd-4980-8615-badf204202d9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e02978e6-97c9-4e01-99a5-69238d6fdad5", "1013b5aa-2060-4a24-89a4-db47c9715e1e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "03d23889-9741-49e4-99fd-bd7ceb2e69d7", "b00536e8-b8e3-4f13-89f5-9f2d1d45d5ca" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03d23889-9741-49e4-99fd-bd7ceb2e69d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e02978e6-97c9-4e01-99a5-69238d6fdad5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1013b5aa-2060-4a24-89a4-db47c9715e1e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b00536e8-b8e3-4f13-89f5-9f2d1d45d5ca");

            migrationBuilder.DropColumn(
                name: "LastDisconnectedTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b8afb68-5db0-49da-b232-dc7c9b441400", null, "SupperAdmin", "SUPPERADMIN" },
                    { "85689ac3-894e-4880-ae17-cc3646394a29", null, "User", "USER" },
                    { "b7abd85e-79e9-4c77-8372-d724a87f42a0", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Created", "Email", "EmailConfirmed", "FullName", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "Removed", "SecurityStamp", "TwoFactorEnabled", "Updated", "UserName", "isOnline" },
                values: new object[,]
                {
                    { "5535ab69-14b3-435e-9243-0fd2ea15bc3f", 0, "d0626576-6d39-4e9b-a161-d0e7a2f1a688", null, new DateTime(2024, 6, 13, 20, 39, 43, 71, DateTimeKind.Local).AddTicks(4410), "rufatri@code.edu.az", true, "Rufat Azerbaijan", true, false, false, null, "RUFATRI@CODE.EDU.AZ", "RUFATCODE", "AQAAAAIAAYagAAAAEDU8lqoA62H9bXOVEPQL8vAELjPtWWwS91pBuHVpLo3jgAvS2Raz8XSoToK54A2JrQ==", "+994513004484", true, null, null, "06a8e89d-a1af-447e-8aaf-e7f97c98caa6", false, null, "RufatCode", false },
                    { "69268eb2-2d9c-49d1-bc54-9e1f354a548d", 0, "ae883eff-0e9f-4d23-98e3-cc6e203fcfad", null, new DateTime(2024, 6, 13, 20, 39, 43, 71, DateTimeKind.Local).AddTicks(4450), "rft.smayilov@bk.ru", true, "Rufat Code", true, false, false, null, "RFT.SMAYILOV@BK.RU", "RUFAT_2003", "AQAAAAIAAYagAAAAEIgPS2fuftge+vMpCZg3Qa2uOjYr2J6trzIFtK+88SLcjHTjiMtACIpkXZvw5X4TEQ==", "+994513004484", true, null, null, "4be43e9d-f7d0-41fd-9701-72831fe882bc", false, null, "Rufat_2003", false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b7abd85e-79e9-4c77-8372-d724a87f42a0", "5535ab69-14b3-435e-9243-0fd2ea15bc3f" },
                    { "2b8afb68-5db0-49da-b232-dc7c9b441400", "69268eb2-2d9c-49d1-bc54-9e1f354a548d" }
                });
        }
    }
}
