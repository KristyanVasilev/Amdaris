using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class RenameWtritingYtesil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WritingUtensils_WritingUtensilstypes_WritingUtensilsTypeId",
                table: "WritingUtensils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WritingUtensilstypes",
                table: "WritingUtensilstypes");

            migrationBuilder.RenameTable(
                name: "WritingUtensilstypes",
                newName: "WritingUtensilsTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WritingUtensilsTypes",
                table: "WritingUtensilsTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WritingUtensils_WritingUtensilsTypes_WritingUtensilsTypeId",
                table: "WritingUtensils",
                column: "WritingUtensilsTypeId",
                principalTable: "WritingUtensilsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WritingUtensils_WritingUtensilsTypes_WritingUtensilsTypeId",
                table: "WritingUtensils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WritingUtensilsTypes",
                table: "WritingUtensilsTypes");

            migrationBuilder.RenameTable(
                name: "WritingUtensilsTypes",
                newName: "WritingUtensilstypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WritingUtensilstypes",
                table: "WritingUtensilstypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WritingUtensils_WritingUtensilstypes_WritingUtensilsTypeId",
                table: "WritingUtensils",
                column: "WritingUtensilsTypeId",
                principalTable: "WritingUtensilstypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
