﻿using System;
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
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgentParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgent = table.Column<int>(type: "int", nullable: false),
                    datecreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuestionQty = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentParticipants_Agents_AgentsId",
                        column: x => x.AgentsId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agent_Id = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ParticipantDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuizQuestionId = table.Column<int>(type: "int", nullable: false),
                    QuizParticipId = table.Column<int>(type: "int", nullable: false),
                    QuizValidAnswer = table.Column<int>(type: "int", nullable: false),
                    QuizQstart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuizQend = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuizCommentPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizFreeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizValidFreeAnswer = table.Column<bool>(type: "bit", nullable: true),
                    AgentParticipantsId = table.Column<int>(type: "int", nullable: true),
                    AgentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantDatas_AgentParticipants_AgentParticipantsId",
                        column: x => x.AgentParticipantsId,
                        principalTable: "AgentParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantDatas_Agents_AgentsId",
                        column: x => x.AgentsId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantDatas_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Civility", "CreatedAt", "Email", "Firstname", "IsActive", "IsAdmin", "LastLogin", "Lastname", "PasswordHash", "PasswordSalt", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, "M.", new DateTime(2022, 2, 9, 20, 18, 53, 303, DateTimeKind.Local).AddTicks(5407), "m.leblanc@exemple.com", "Matt", true, true, new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(5053), "LeBlanc", null, null, "0102030405", "Agent" },
                    { 2, "M.", new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7029), "m.perry@exemple.com", "Matthew", true, true, new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7061), "Perry", null, null, "0102030405", "Agent" },
                    { 3, "M.", new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7074), "c.cox@exemple.com", "Courteney", true, false, new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7080), "Cox", null, null, "0102030405", "Agent" },
                    { 4, "M.", new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7092), "np.harris@exemple.com", "Neil Patrick", true, false, new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7098), "Harris", null, null, "0102030405", "Agent" },
                    { 5, "M.", new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7107), "w.miller@exemple.com", "Wentworth", true, false, new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7113), "Miller", null, null, "0102030405", "Agent" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Agent_Id", "AgentsId", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, null, "Admin" },
                    { 2, 11, null, "Admin" },
                    { 3, 11, null, "Agent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentParticipants_AgentsId",
                table: "AgentParticipants",
                column: "AgentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDatas_AgentParticipantsId",
                table: "ParticipantDatas",
                column: "AgentParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDatas_AgentsId",
                table: "ParticipantDatas",
                column: "AgentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDatas_QuizId",
                table: "ParticipantDatas",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AgentsId",
                table: "Roles",
                column: "AgentsId");
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