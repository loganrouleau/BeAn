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

                    b.Property<bool>("Reusable");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "Dealing with school situations",
                            MasteryCriteriaCompareTo = 80.0,
                            MasteryCriteriaCompareType = 1,
                            MasteryCriteriaConsecutiveSessions = 1,
                            Name = "School",
                            ProgramComplete = 0,
                            Reusable = true,
                            StudentId = -1
                        },
                        new
                        {
                            Id = -2,
                            Description = "Dealing with home situations",
                            MasteryCriteriaCompareTo = 80.0,
                            MasteryCriteriaCompareType = 1,
                            MasteryCriteriaConsecutiveSessions = 2,
                            Name = "Home",
                            ProgramComplete = 1,
                            Reusable = true,
                            StudentId = -1
                        },
                        new
                        {
                            Id = -3,
                            Description = "Being away from home",
                            MasteryCriteriaCompareTo = 80.0,
                            MasteryCriteriaCompareType = 1,
                            MasteryCriteriaConsecutiveSessions = 3,
                            Name = "Outing",
                            ProgramComplete = 0,
                            Reusable = true,
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

                    b.ToTable("Prompts");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ConsecutiveSuccessfulSession = 0,
                            Description = "Full physical guidance",
                            Level = 1,
                            PromptLevelComplete = 0,
                            TargetId = -1
                        },
                        new
                        {
                            Id = -2,
                            ConsecutiveSuccessfulSession = 0,
                            Description = "Demonstration of me washing hands",
                            Level = 2,
                            PromptLevelComplete = 0,
                            TargetId = -1
                        },
                        new
                        {
                            Id = -3,
                            ConsecutiveSuccessfulSession = 0,
                            Description = "No assistance required",
                            Level = 3,
                            PromptLevelComplete = 0,
                            TargetId = -1
                        },
                        new
                        {
                            Id = -4,
                            ConsecutiveSuccessfulSession = 1,
                            Description = "Requires introduction and prompting",
                            Level = 1,
                            PromptLevelComplete = 1,
                            TargetId = -2
                        },
                        new
                        {
                            Id = -5,
                            ConsecutiveSuccessfulSession = 0,
                            Description = "Needs a reminder",
                            Level = 2,
                            PromptLevelComplete = 0,
                            TargetId = -2
                        },
                        new
                        {
                            Id = -6,
                            ConsecutiveSuccessfulSession = 0,
                            Description = "Will initiate interaction on their own",
                            Level = 3,
                            PromptLevelComplete = 0,
                            TargetId = -2
                        },
                        new
                        {
                            Id = -7,
                            ConsecutiveSuccessfulSession = 1,
                            Description = "Won't go to class unless physically guided",
                            Level = 1,
                            PromptLevelComplete = 1,
                            TargetId = -3
                        },
                        new
                        {
                            Id = -8,
                            ConsecutiveSuccessfulSession = 1,
                            Description = "Must remind to attend class",
                            Level = 2,
                            PromptLevelComplete = 1,
                            TargetId = -3
                        },
                        new
                        {
                            Id = -9,
                            ConsecutiveSuccessfulSession = 0,
                            Description = "Usually remembers to attend class",
                            Level = 3,
                            PromptLevelComplete = 0,
                            TargetId = -3
                        },
                        new
                        {
                            Id = -10,
                            ConsecutiveSuccessfulSession = 2,
                            Description = "Needs physical guidance with cutlery",
                            Level = 1,
                            PromptLevelComplete = 1,
                            TargetId = -4
                        },
                        new
                        {
                            Id = -11,
                            ConsecutiveSuccessfulSession = 2,
                            Description = "Makes small mistakes and spills food",
                            Level = 2,
                            PromptLevelComplete = 1,
                            TargetId = -4
                        },
                        new
                        {
                            Id = -12,
                            ConsecutiveSuccessfulSession = 2,
                            Description = "Flawless eater",
                            Level = 3,
                            PromptLevelComplete = 1,
                            TargetId = -4
                        },
                        new
                        {
                            Id = -13,
                            ConsecutiveSuccessfulSession = 2,
                            Description = "Needs physical guidance",
                            Level = 1,
                            PromptLevelComplete = 1,
                            TargetId = -5
                        },
                        new
                        {
                            Id = -14,
                            ConsecutiveSuccessfulSession = 2,
                            Description = "Misses a few spots",
                            Level = 2,
                            PromptLevelComplete = 1,
                            TargetId = -5
                        },
                        new
                        {
                            Id = -15,
                            ConsecutiveSuccessfulSession = 2,
                            Description = "Complains and must be dragged to bed",
                            Level = 1,
                            PromptLevelComplete = 1,
                            TargetId = -6
                        },
                        new
                        {
                            Id = -16,
                            ConsecutiveSuccessfulSession = 2,
                            Description = "Goes to bed on their own",
                            Level = 2,
                            PromptLevelComplete = 1,
                            TargetId = -6
                        },
                        new
                        {
                            Id = -17,
                            ConsecutiveSuccessfulSession = 1,
                            Description = "Doesn't know how to get on the bus",
                            Level = 1,
                            PromptLevelComplete = 0,
                            TargetId = -7
                        },
                        new
                        {
                            Id = -18,
                            ConsecutiveSuccessfulSession = 2,
                            Description = "Can ride the bus with guidance",
                            Level = 2,
                            PromptLevelComplete = 0,
                            TargetId = -7
                        },
                        new
                        {
                            Id = -19,
                            ConsecutiveSuccessfulSession = 3,
                            Description = "Doesn't know what to buy",
                            Level = 1,
                            PromptLevelComplete = 1,
                            TargetId = -8
                        },
                        new
                        {
                            Id = -20,
                            ConsecutiveSuccessfulSession = 1,
                            Description = "Is able to follow shopping list and checkout",
                            Level = 2,
                            PromptLevelComplete = 0,
                            TargetId = -8
                        },
                        new
                        {
                            Id = -21,
                            ConsecutiveSuccessfulSession = 3,
                            Description = "Needs assistance",
                            Level = 1,
                            PromptLevelComplete = 1,
                            TargetId = -9
                        },
                        new
                        {
                            Id = -22,
                            ConsecutiveSuccessfulSession = 0,
                            Description = "Can use Google Maps to find an address",
                            Level = 2,
                            PromptLevelComplete = 0,
                            TargetId = -9
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

                    b.Property<int>("StudentId");

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

                    b.Property<int?>("PromptId");

                    b.Property<int?>("SessionId");

                    b.Property<int>("TrialNumber");

                    b.HasKey("Id");

                    b.HasIndex("PromptId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionDatas");
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
                            Remark = "This student is very smart",
                            StudentId = "id1",
                            StudentInitials = "Apple A."
                        },
                        new
                        {
                            Id = -2,
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Remark = "Temporary student until I go on vacation",
                            StudentId = "id2",
                            StudentInitials = "Banana B."
                        },
                        new
                        {
                            Id = -3,
                            LastUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Remark = "Only schedule on Saturdays",
                            StudentId = "id3",
                            StudentInitials = "Carrot C."
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

                    b.Property<int>("ProgramId");

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
                            Name = "Washing hands",
                            ProgramId = -1,
                            Type = "trial"
                        },
                        new
                        {
                            Id = -2,
                            MaxTrial = 5,
                            MinTrial = 1,
                            Name = "Making friends",
                            ProgramId = -1,
                            Type = "trial"
                        },
                        new
                        {
                            Id = -3,
                            MaxTrial = 4,
                            MinTrial = 2,
                            Name = "Attending class",
                            ProgramId = -1,
                            Type = "trial"
                        },
                        new
                        {
                            Id = -4,
                            MaxTrial = 10,
                            MinTrial = 3,
                            Name = "Eating dinner",
                            ProgramId = -2,
                            Type = "trial"
                        },
                        new
                        {
                            Id = -5,
                            MaxTrial = 4,
                            MinTrial = 2,
                            Name = "Washing dishes",
                            ProgramId = -2,
                            Type = "trial"
                        },
                        new
                        {
                            Id = -6,
                            MaxTrial = 5,
                            MinTrial = 1,
                            Name = "Going to bed",
                            ProgramId = -2,
                            Type = "trial"
                        },
                        new
                        {
                            Id = -7,
                            MaxTrial = 10,
                            MinTrial = 3,
                            Name = "Riding the bus",
                            ProgramId = -3,
                            Type = "trial"
                        },
                        new
                        {
                            Id = -8,
                            MaxTrial = 4,
                            MinTrial = 2,
                            Name = "Buying groceries",
                            ProgramId = -3,
                            Type = "trial"
                        },
                        new
                        {
                            Id = -9,
                            MaxTrial = 6,
                            MinTrial = 1,
                            Name = "Finding an address",
                            ProgramId = -3,
                            Type = "trial"
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
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeAn.Models.SessionData", b =>
                {
                    b.HasOne("BeAn.Models.Prompt", "Prompt")
                        .WithMany()
                        .HasForeignKey("PromptId");

                    b.HasOne("BeAn.Models.Session", "Session")
                        .WithMany("SessionData")
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("BeAn.Models.Target", b =>
                {
                    b.HasOne("BeAn.Models.Program", "Program")
                        .WithMany("Targets")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
