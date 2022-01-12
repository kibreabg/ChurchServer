using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchServer.Infrastructure.Data.Migrations
{
    public partial class AddMembersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    WeddingDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BaptizedHere = table.Column<bool>(type: "bit", maxLength: 10, nullable: false),
                    PreviousChurch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MembershipDate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiscipleshipTeacher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsServing = table.Column<bool>(type: "bit", maxLength: 10, nullable: false),
                    EducationLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsInHomeCell = table.Column<bool>(type: "bit", maxLength: 10, nullable: false),
                    HomeCellId = table.Column<int>(type: "int", nullable: false),
                    NotInHomeCellReason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermitHomeForHomeCell = table.Column<bool>(type: "bit", maxLength: 10, nullable: false),
                    IsInChurchSocialService = table.Column<bool>(type: "bit", maxLength: 10, nullable: false),
                    HasJob = table.Column<bool>(type: "bit", maxLength: 10, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Responsibility = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OtherAbilities = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpouseTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSpouseBeliever = table.Column<bool>(type: "bit", nullable: false),
                    SpouseChurch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseMaxEducationalLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FemaleBelieverChildren = table.Column<int>(type: "int", nullable: false),
                    MaleBelieverChildren = table.Column<int>(type: "int", nullable: false),
                    FemaleNonBelieverChildren = table.Column<int>(type: "int", nullable: false),
                    MaleNonBelieverChildren = table.Column<int>(type: "int", nullable: false),
                    AgeOneToSeven = table.Column<int>(type: "int", nullable: false),
                    AgeEightToThirteen = table.Column<int>(type: "int", nullable: false),
                    AgeFourteenToThirty = table.Column<int>(type: "int", nullable: false),
                    EduKgToSix = table.Column<int>(type: "int", nullable: false),
                    EduSevenToTwelve = table.Column<int>(type: "int", nullable: false),
                    EduCollage = table.Column<int>(type: "int", nullable: false),
                    EduUniversity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
