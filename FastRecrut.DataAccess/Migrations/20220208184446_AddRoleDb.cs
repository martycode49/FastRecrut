using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastRecrut.DataAccess.Migrations
{
    public partial class AddRoleDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AgentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Agents_AgentsId",
                        column: x => x.AgentsId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });


            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "AgentsId", "RoleName", "UserId" },
                values: new object[] { 1, null, "Admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AgentsId",
                table: "Roles",
                column: "AgentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 11, 48, 162, DateTimeKind.Local).AddTicks(249), new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(2399), new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(2421) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(2429), new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(2433) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(2439), new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(2443) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(2449), new DateTime(2022, 2, 6, 13, 11, 48, 180, DateTimeKind.Local).AddTicks(2452) });
        }
    }
}
