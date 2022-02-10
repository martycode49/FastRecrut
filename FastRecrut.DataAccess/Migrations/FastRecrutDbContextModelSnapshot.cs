﻿// <auto-generated />
using System;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FastRecrut.DataAccess.Migrations
{
    [DbContext(typeof(FastRecrutDbContext))]
    partial class FastRecrutDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FastRecrut.Entities.Concrete.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Civility")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Civility = "M.",
                            CreatedAt = new DateTime(2022, 2, 9, 20, 18, 53, 303, DateTimeKind.Local).AddTicks(5407),
                            Email = "m.leblanc@exemple.com",
                            Firstname = "Matt",
                            IsActive = true,
                            IsAdmin = true,
                            LastLogin = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(5053),
                            Lastname = "LeBlanc",
                            Phone = "0102030405",
                            Status = "Agent"
                        },
                        new
                        {
                            Id = 2,
                            Civility = "M.",
                            CreatedAt = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7029),
                            Email = "m.perry@exemple.com",
                            Firstname = "Matthew",
                            IsActive = true,
                            IsAdmin = true,
                            LastLogin = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7061),
                            Lastname = "Perry",
                            Phone = "0102030405",
                            Status = "Agent"
                        },
                        new
                        {
                            Id = 3,
                            Civility = "M.",
                            CreatedAt = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7074),
                            Email = "c.cox@exemple.com",
                            Firstname = "Courteney",
                            IsActive = true,
                            IsAdmin = false,
                            LastLogin = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7080),
                            Lastname = "Cox",
                            Phone = "0102030405",
                            Status = "Agent"
                        },
                        new
                        {
                            Id = 4,
                            Civility = "M.",
                            CreatedAt = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7092),
                            Email = "np.harris@exemple.com",
                            Firstname = "Neil Patrick",
                            IsActive = true,
                            IsAdmin = false,
                            LastLogin = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7098),
                            Lastname = "Harris",
                            Phone = "0102030405",
                            Status = "Agent"
                        },
                        new
                        {
                            Id = 5,
                            Civility = "M.",
                            CreatedAt = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7107),
                            Email = "w.miller@exemple.com",
                            Firstname = "Wentworth",
                            IsActive = true,
                            IsAdmin = false,
                            LastLogin = new DateTime(2022, 2, 9, 20, 18, 53, 310, DateTimeKind.Local).AddTicks(7113),
                            Lastname = "Miller",
                            Phone = "0102030405",
                            Status = "Agent"
                        });
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.AgentParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgentsId")
                        .HasColumnType("int");

                    b.Property<int>("IdAgent")
                        .HasColumnType("int");

                    b.Property<int>("QuestionQty")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("datecreate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgentsId");

                    b.ToTable("AgentParticipants");
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.ParticipantData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgentParticipantsId")
                        .HasColumnType("int");

                    b.Property<int?>("AgentsId")
                        .HasColumnType("int");

                    b.Property<string>("QuizCommentPart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuizFreeAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("QuizParticipId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("QuizQend")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("QuizQstart")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuizQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuizValidAnswer")
                        .HasColumnType("int");

                    b.Property<bool?>("QuizValidFreeAnswer")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AgentParticipantsId");

                    b.HasIndex("AgentsId");

                    b.HasIndex("QuizId");

                    b.ToTable("ParticipantDatas");
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentFalse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rep1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rep2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rep3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rep4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValidQuestion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Agent_Id")
                        .HasColumnType("int");

                    b.Property<int?>("AgentsId")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AgentsId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Agent_Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Agent_Id = 11,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Agent_Id = 11,
                            RoleName = "Agent"
                        });
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.AgentParticipant", b =>
                {
                    b.HasOne("FastRecrut.Entities.Concrete.Agent", "Agents")
                        .WithMany("AgentParticipants")
                        .HasForeignKey("AgentsId");

                    b.Navigation("Agents");
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.ParticipantData", b =>
                {
                    b.HasOne("FastRecrut.Entities.Concrete.AgentParticipant", "AgentParticipants")
                        .WithMany("ParticipantDatas")
                        .HasForeignKey("AgentParticipantsId");

                    b.HasOne("FastRecrut.Entities.Concrete.Agent", "Agents")
                        .WithMany()
                        .HasForeignKey("AgentsId");

                    b.HasOne("FastRecrut.Entities.Concrete.Quiz", "Quizzes")
                        .WithMany("ParticipantDatas")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgentParticipants");

                    b.Navigation("Agents");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.Role", b =>
                {
                    b.HasOne("FastRecrut.Entities.Concrete.Agent", "Agents")
                        .WithMany("Roles")
                        .HasForeignKey("AgentsId");

                    b.Navigation("Agents");
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.Agent", b =>
                {
                    b.Navigation("AgentParticipants");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.AgentParticipant", b =>
                {
                    b.Navigation("ParticipantDatas");
                });

            modelBuilder.Entity("FastRecrut.Entities.Concrete.Quiz", b =>
                {
                    b.Navigation("ParticipantDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
