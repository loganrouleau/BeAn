using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeAn.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(nullable: true),
                    StudentInitials = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProgramComplete = table.Column<int>(nullable: false),
                    MasteryCriteriaCompareType = table.Column<int>(nullable: false),
                    MasteryCriteriaCompareTo = table.Column<double>(nullable: false),
                    MasteryCriteriaConsecutiveSessions = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    Reusable = table.Column<bool>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    EndDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PromptLevel = table.Column<string>(nullable: true),
                    MinTrial = table.Column<int>(nullable: false),
                    MaxTrial = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    ProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Targets_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prompts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Level = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PromptLevelComplete = table.Column<int>(nullable: false),
                    ConsecutiveSuccessfulSession = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    TargetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prompts_Targets_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<int>(nullable: false),
                    TrialNumber = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    PromptId = table.Column<int>(nullable: true),
                    SessionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionDatas_Prompts_PromptId",
                        column: x => x.PromptId,
                        principalTable: "Prompts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionDatas_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Remark", "StudentId", "StudentInitials" },
                values: new object[] { -1, "This student is very smart", "id1", "Apple A." });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Remark", "StudentId", "StudentInitials" },
                values: new object[] { -2, "Temporary student until I go on vacation", "id2", "Banana B." });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Remark", "StudentId", "StudentInitials" },
                values: new object[] { -3, "Only schedule on Saturdays", "id3", "Carrot C." });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Description", "MasteryCriteriaCompareTo", "MasteryCriteriaCompareType", "MasteryCriteriaConsecutiveSessions", "Name", "ProgramComplete", "Reusable", "StudentId" },
                values: new object[] { -1, "Dealing with school situations", 80.0, 1, 1, "School", 0, true, -1 });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Description", "MasteryCriteriaCompareTo", "MasteryCriteriaCompareType", "MasteryCriteriaConsecutiveSessions", "Name", "ProgramComplete", "Reusable", "StudentId" },
                values: new object[] { -2, "Dealing with home situations", 80.0, 1, 2, "Home", 1, true, -1 });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Description", "MasteryCriteriaCompareTo", "MasteryCriteriaCompareType", "MasteryCriteriaConsecutiveSessions", "Name", "ProgramComplete", "Reusable", "StudentId" },
                values: new object[] { -3, "Being away from home", 80.0, 1, 3, "Outing", 0, true, -1 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Description", "StudentId" },
                values: new object[] { -1, "session1", -3 });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -1, 4, 2, "Washing hands", -1, null, "trial" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -2, 5, 1, "Making friends", -1, null, "trial" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -3, 4, 2, "Attending class", -1, null, "trial" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -4, 10, 3, "Eating dinner", -2, null, "trial" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -5, 4, 2, "Washing dishes", -2, null, "trial" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -6, 5, 1, "Going to bed", -2, null, "trial" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -7, 10, 3, "Riding the bus", -3, null, "trial" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -8, 4, 2, "Buying groceries", -3, null, "trial" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "MaxTrial", "MinTrial", "Name", "ProgramId", "PromptLevel", "Type" },
                values: new object[] { -9, 6, 1, "Finding an address", -3, null, "trial" });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -1, 0, "Full physical guidance", 1, 0, -1 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -20, 1, "Is able to follow shopping list and checkout", 2, 0, -8 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -19, 3, "Doesn't know what to buy", 1, 1, -8 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -18, 2, "Can ride the bus with guidance", 2, 0, -7 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -17, 1, "Doesn't know how to get on the bus", 1, 0, -7 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -16, 2, "Goes to bed on their own", 2, 1, -6 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -15, 2, "Complains and must be dragged to bed", 1, 1, -6 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -14, 2, "Misses a few spots", 2, 1, -5 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -13, 2, "Needs physical guidance", 1, 1, -5 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -12, 2, "Flawless eater", 3, 1, -4 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -11, 2, "Makes small mistakes and spills food", 2, 1, -4 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -10, 2, "Needs physical guidance with cutlery", 1, 1, -4 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -9, 0, "Usually remembers to attend class", 3, 0, -3 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -8, 1, "Must remind to attend class", 2, 1, -3 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -7, 1, "Won't go to class unless physically guided", 1, 1, -3 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -6, 0, "Will initiate interaction on their own", 3, 0, -2 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -5, 0, "Needs a reminder", 2, 0, -2 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -4, 1, "Requires introduction and prompting", 1, 1, -2 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -3, 0, "No assistance required", 3, 0, -1 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -2, 0, "Demonstration of me washing hands", 2, 0, -1 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -21, 3, "Needs assistance", 1, 1, -9 });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "ConsecutiveSuccessfulSession", "Description", "Level", "PromptLevelComplete", "TargetId" },
                values: new object[] { -22, 0, "Can use Google Maps to find an address", 2, 0, -9 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Programs_StudentId",
                table: "Programs",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_TargetId",
                table: "Prompts",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionDatas_PromptId",
                table: "SessionDatas",
                column: "PromptId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionDatas_SessionId",
                table: "SessionDatas",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_StudentId",
                table: "Sessions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_ProgramId",
                table: "Targets",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "SessionDatas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Prompts");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
