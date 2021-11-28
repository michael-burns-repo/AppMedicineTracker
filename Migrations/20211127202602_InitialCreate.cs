using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppMedicineTracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Dose = table.Column<string>(nullable: true),
                    Form = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    PrescribedBy = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    DaysOn = table.Column<int>(nullable: true),
                    DaysOff = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Supply = table.Column<int>(nullable: false),
                    Refills = table.Column<int>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    Suspend = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicine");
        }
    }
}
