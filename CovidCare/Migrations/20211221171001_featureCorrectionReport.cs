using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidCare.Migrations
{
    public partial class featureCorrectionReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BP",
                table: "Report",
                newName: "BP_low");

            migrationBuilder.AddColumn<double>(
                name: "BP_high",
                table: "Report",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BP_high",
                table: "Report");

            migrationBuilder.RenameColumn(
                name: "BP_low",
                table: "Report",
                newName: "BP");
        }
    }
}
