using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class PatientDBTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Epilepsy");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Patients",
                newName: "PatientName");

            migrationBuilder.AddColumn<int>(
                name: "DiseaseInformationID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEplepsy",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseaseInformationID",
                table: "Patients",
                column: "DiseaseInformationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_DiseaseInformation_DiseaseInformationID",
                table: "Patients",
                column: "DiseaseInformationID",
                principalTable: "DiseaseInformation",
                principalColumn: "DiseaseID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_DiseaseInformation_DiseaseInformationID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DiseaseInformationID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiseaseInformationID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IsEplepsy",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "Patients",
                newName: "LastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Epilepsy",
                columns: table => new
                {
                    EpilepsyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpilepsyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epilepsy", x => x.EpilepsyID);
                });
        }
    }
}
