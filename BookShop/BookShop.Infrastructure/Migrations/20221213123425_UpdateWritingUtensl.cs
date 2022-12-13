using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class UpdateWritingUtensl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WritingUtensilTypeId",
                table: "WritingUtensils");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WritingUtensilTypeId",
                table: "WritingUtensils",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
