using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab10FrontToBack.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserSeedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "082e94b3-0b6d-44a8-8342-be274c708d67", null, "User", "USER" },
                    { "a9f9d6cf-f191-4c91-8c26-72de90cba044", null, "Admin", "ADMIN" },
                    { "ebc713f7-f221-4d8a-ad9e-140efc99404f", null, "SupperAdmin", "SUPPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConnectionId", "Created", "Email", "EmailConfirmed", "FullName", "IsActive", "IsDeleted", "LastDisconnectedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "Removed", "SecurityStamp", "TwoFactorEnabled", "Updated", "UserName", "isOnline" },
                values: new object[,]
                {
                    { "43aeea91-1bfe-4e69-9417-27801e9e2195", 0, "b684139e-fc5f-4de3-8667-91b25b62ea75", null, new DateTime(2024, 6, 14, 10, 50, 59, 34, DateTimeKind.Local).AddTicks(6590), "rft.smayilov@bk.ru", true, "Rufat Code", true, false, null, false, null, "RFT.SMAYILOV@BK.RU", "RUFAT_2003", "AQAAAAIAAYagAAAAEHS30VeDQMR2qXJFyjHhCwzInlFWtTsWcr4aLQBtlI0ByxVThJj3SIBAV6QZIwtVkg==", "+994513004484", true, null, null, "e948e633-e300-4a09-99df-bcc704f16b28", false, null, "Rufat_2003", false },
                    { "4a83301b-5207-4bee-9158-92a5cf5f66d0", 0, "350934ae-2d55-4553-9991-843ffbe362ca", null, new DateTime(2024, 6, 14, 10, 50, 59, 34, DateTimeKind.Local).AddTicks(6620), "ilgar@code.edu.az", true, "Ilgar", true, false, null, false, null, "Ilgar@CODE.EDU.AZ", "Ilgar123", "AQAAAAIAAYagAAAAEHS30VeDQMR2qXJFyjHhCwzInlFWtTsWcr4aLQBtlI0ByxVThJj3SIBAV6QZIwtVkg==", "+994513004484", true, null, null, "3e23686b-e7ff-471b-bc65-8a891a39c9e3", false, null, "Ilgar123", false },
                    { "c4d6c10a-a4c3-4f6f-9aa6-df26aef203dd", 0, "dff31afa-ad2c-44d8-b94f-a0192bf8ae36", null, new DateTime(2024, 6, 14, 10, 50, 59, 34, DateTimeKind.Local).AddTicks(6610), "rashad123@code.edu.az", true, "Rashad", true, false, null, false, null, "RASHAD123@CODE.EDU.AZ", "RASHAD12", "AQAAAAIAAYagAAAAEHS30VeDQMR2qXJFyjHhCwzInlFWtTsWcr4aLQBtlI0ByxVThJj3SIBAV6QZIwtVkg==", "+994513004484", true, null, null, "af009d46-532b-4e86-b199-f087dae840e6", false, null, "Rashad12", false },
                    { "d7f9b21c-dfb6-4a92-849b-059f5ab2f6be", 0, "91f0b078-ac7c-466b-b781-45d6b9bc982f", null, new DateTime(2024, 6, 14, 10, 50, 59, 34, DateTimeKind.Local).AddTicks(6550), "rufatri@code.edu.az", true, "Rufat Azerbaijan", true, false, null, false, null, "RUFATRI@CODE.EDU.AZ", "RUFATCODE", "AQAAAAIAAYagAAAAEIrCpEKm7fnp1M+Qf94DCV4tXPU17ObYchIO1J3QNqi7saT+AtNdJn45WA15KKS0ZQ==", "+994513004484", true, null, null, "d0580463-2ebc-48f4-a1d2-e2d2e094b74e", false, null, "RufatCode", false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ebc713f7-f221-4d8a-ad9e-140efc99404f", "43aeea91-1bfe-4e69-9417-27801e9e2195" },
                    { "a9f9d6cf-f191-4c91-8c26-72de90cba044", "d7f9b21c-dfb6-4a92-849b-059f5ab2f6be" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "082e94b3-0b6d-44a8-8342-be274c708d67");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ebc713f7-f221-4d8a-ad9e-140efc99404f", "43aeea91-1bfe-4e69-9417-27801e9e2195" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a9f9d6cf-f191-4c91-8c26-72de90cba044", "d7f9b21c-dfb6-4a92-849b-059f5ab2f6be" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a83301b-5207-4bee-9158-92a5cf5f66d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4d6c10a-a4c3-4f6f-9aa6-df26aef203dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9f9d6cf-f191-4c91-8c26-72de90cba044");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebc713f7-f221-4d8a-ad9e-140efc99404f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43aeea91-1bfe-4e69-9417-27801e9e2195");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7f9b21c-dfb6-4a92-849b-059f5ab2f6be");

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
    }
}
