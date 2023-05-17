using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCare.PatientProfileManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasicInformation_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicInformation_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicInformation_DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasicInformation_Gender = table.Column<int>(type: "int", nullable: false),
                    ContactInfo_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo_Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo_Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo_Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo_Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo_Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalInfo_BloodType = table.Column<int>(type: "int", nullable: false),
                    MedicalInfo_BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalInfo_BloodSugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalInfo_Cholesterol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProfiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientProfiles");
        }
    }
}
