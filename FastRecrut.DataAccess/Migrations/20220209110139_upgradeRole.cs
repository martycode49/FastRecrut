using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastRecrut.DataAccess.Migrations
{
    public partial class upgradeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 9, 12, 1, 38, 640, DateTimeKind.Local).AddTicks(1909), new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(7961) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(9479), new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(9512), new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(9516) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(9521), new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(9524) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(9529), new DateTime(2022, 2, 9, 12, 1, 38, 644, DateTimeKind.Local).AddTicks(9533) });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AgentsId",
                table: "Roles",
                column: "UserId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 8, 19, 58, 31, 304, DateTimeKind.Local).AddTicks(1232), new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(5283) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(6676), new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(6698) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(6704), new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(6707) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(6712), new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(6716) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(6721), new DateTime(2022, 2, 8, 19, 58, 31, 309, DateTimeKind.Local).AddTicks(6724) });
        }
    }
}
