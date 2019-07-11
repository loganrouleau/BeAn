﻿// <auto-generated />
using System;
using BeAn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeAn.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview4.19216.3");

            modelBuilder.Entity("BeAn.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BeAn.Models.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<double>("MasteryCriteriaCompareTo");

                    b.Property<int>("MasteryCriteriaCompareType");

                    b.Property<int>("MasteryCriteriaConsecutiveSessions");

                    b.Property<string>("Name");

                    b.Property<int>("ProgramComplete");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "words",
                            MasteryCriteriaCompareTo = 2.0299999999999998,
                            MasteryCriteriaCompareType = 2,
                            MasteryCriteriaConsecutiveSessions = 3,
                            Name = "Program B",
                            ProgramComplete = 0,
                            StudentId = -1
                        },
                        new
                        {
                            Id = -2,
                            Description = "morewords",
                            MasteryCriteriaCompareTo = 2.3300000000000001,
                            MasteryCriteriaCompareType = 2,
                            MasteryCriteriaConsecutiveSessions = 4,
                            Name = "Program C",
                            ProgramComplete = 1,
                            StudentId = -2
                        },
                        new
                        {
                            Id = -3,
                            Description = "descwords",
                            MasteryCriteriaCompareTo = 1.0,
                            MasteryCriteriaCompareType = 1,
                            MasteryCriteriaConsecutiveSessions = 5,
                            Name = "Program A",
                            ProgramComplete = 0,
                            StudentId = -1
                        });
                });

            modelBuilder.Entity("BeAn.Models.Prompt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConsecutiveSuccessfulSession");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<int>("Level");

                    b.Property<int>("PromptLevelComplete");

                    b.Property<int?>("TargetId");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.ToTable("Prompt");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ConsecutiveSuccessfulSession = 0,
                            Description = "prompt",
                            Level = 5,
                            PromptLevelComplete = 4,
                            TargetId = -2
                        },
                        new
                        {
                            Id = -2,
                            ConsecutiveSuccessfulSession = 1,
                            Description = "prompt",
                            Level = 4,
                            PromptLevelComplete = 4,
                            TargetId = -2
                        });
                });

            modelBuilder.Entity("BeAn.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<DateTime>("StartDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "session1",
                            StudentId = -3
                        });
                });

            modelBuilder.Entity("BeAn.Models.SessionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Data");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<int?>("ProgramId");

                    b.Property<int?>("SessionId");

                    b.Property<int?>("TargetId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.HasIndex("SessionId");

                    b.HasIndex("TargetId");

                    b.ToTable("SessionDatas");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Data = 1,
                            ProgramId = -2,
                            SessionId = -1,
                            TargetId = -2
                        });
                });

            modelBuilder.Entity("BeAn.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<string>("Remark");

                    b.Property<string>("StudentId");

                    b.Property<string>("StudentInitials");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Remark = "Hi",
                            StudentId = "id1",
                            StudentInitials = "A.A"
                        },
                        new
                        {
                            Id = -2,
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Remark = "Hello",
                            StudentId = "id2",
                            StudentInitials = "B.B"
                        },
                        new
                        {
                            Id = -3,
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Remark = "Bye",
                            StudentId = "id3",
                            StudentInitials = "C.C"
                        });
                });

            modelBuilder.Entity("BeAn.Models.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<int>("MaxTrial");

                    b.Property<int>("MinTrial");

                    b.Property<string>("Name");

                    b.Property<int?>("ProgramId");

                    b.Property<string>("PromptLevel");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Targets");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            MaxTrial = 4,
                            MinTrial = 2,
                            ProgramId = -3,
                            Type = "targettype1"
                        },
                        new
                        {
                            Id = -2,
                            MaxTrial = 5,
                            MinTrial = 1,
                            ProgramId = -2,
                            Type = "targettype2"
                        });
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000);

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .IsRequired();

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200);

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000);

                    b.Property<DateTime?>("Expiration");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Key");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BeAn.Models.Program", b =>
                {
                    b.HasOne("BeAn.Models.Student", "Student")
                        .WithMany("Programs")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("BeAn.Models.Prompt", b =>
                {
                    b.HasOne("BeAn.Models.Target", "Target")
                        .WithMany("Prompts")
                        .HasForeignKey("TargetId");
                });

            modelBuilder.Entity("BeAn.Models.Session", b =>
                {
                    b.HasOne("BeAn.Models.Student", "Student")
                        .WithMany("Sessions")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("BeAn.Models.SessionData", b =>
                {
                    b.HasOne("BeAn.Models.Program", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramId");

                    b.HasOne("BeAn.Models.Session", "Session")
                        .WithMany("SessionData")
                        .HasForeignKey("SessionId");

                    b.HasOne("BeAn.Models.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId");
                });

            modelBuilder.Entity("BeAn.Models.Target", b =>
                {
                    b.HasOne("BeAn.Models.Program", "Program")
                        .WithMany("Targets")
                        .HasForeignKey("ProgramId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BeAn.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BeAn.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeAn.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BeAn.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
