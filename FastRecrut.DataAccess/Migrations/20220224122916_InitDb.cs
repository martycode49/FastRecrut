using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastRecrut.DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Civility = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rep1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rep2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rep3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rep4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ValidQuestion = table.Column<int>(type: "int", nullable: false),
                    CommentFalse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                });

            migrationBuilder.CreateTable(
                name: "AgentParticipants",
                columns: table => new
                {
                    AgtPartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    datecreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuestionQty = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentParticipants", x => x.AgtPartId);
                    table.ForeignKey(
                        name: "FK_AgentParticipants_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agent_Id = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AgentsAgentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Agents_AgentsAgentId",
                        column: x => x.AgentsAgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgtPartId = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    QuizValidAnswer = table.Column<int>(type: "int", nullable: false),
                    QuizQstart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuizQend = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuizCommentPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizFreeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizValidFreeAnswer = table.Column<bool>(type: "bit", nullable: true),
                    AgentParticipantsAgtPartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantDatas_AgentParticipants_AgentParticipantsAgtPartId",
                        column: x => x.AgentParticipantsAgtPartId,
                        principalTable: "AgentParticipants",
                        principalColumn: "AgtPartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantDatas_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantDatas_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "AgentId", "Civility", "CreatedAt", "Email", "Firstname", "IsActive", "IsAdmin", "LastLogin", "Lastname", "PasswordHash", "PasswordSalt", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, "M.", new DateTime(2022, 2, 24, 13, 29, 15, 71, DateTimeKind.Local).AddTicks(8343), "m.leblanc@exemple.com", "Matt", true, true, new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(7574), "LeBlanc", null, null, "0102030405", "Agent" },
                    { 2, "M.", new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(9440), "m.perry@exemple.com", "Matthew", true, true, new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(9472), "Perry", null, null, "0102030405", "Agent" },
                    { 3, "M.", new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(9483), "c.cox@exemple.com", "Courteney", true, false, new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(9489), "Cox", null, null, "0102030405", "Agent" },
                    { 4, "M.", new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(9497), "np.harris@exemple.com", "Neil Patrick", true, false, new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(9501), "Harris", null, null, "0102030405", "Agent" },
                    { 5, "M.", new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(9509), "w.miller@exemple.com", "Wentworth", true, false, new DateTime(2022, 2, 24, 13, 29, 15, 77, DateTimeKind.Local).AddTicks(9514), "Miller", null, null, "0102030405", "Agent" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Agent_Id", "AgentsAgentId", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, null, "Admin" },
                    { 2, 11, null, "Admin" },
                    { 3, 11, null, "Agent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentParticipants_AgentId",
                table: "AgentParticipants",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDatas_AgentId",
                table: "ParticipantDatas",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDatas_AgentParticipantsAgtPartId",
                table: "ParticipantDatas",
                column: "AgentParticipantsAgtPartId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDatas_QuizId",
                table: "ParticipantDatas",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AgentsAgentId",
                table: "Roles",
                column: "AgentsAgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantDatas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AgentParticipants");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
