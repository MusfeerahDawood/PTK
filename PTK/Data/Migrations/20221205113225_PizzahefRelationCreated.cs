using Microsoft.EntityFrameworkCore.Migrations;

namespace PTK.Data.Migrations
{
    public partial class PizzahefRelationCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChefID",
                table: "Pizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_ChefID",
                table: "Pizza",
                column: "ChefID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Chef_ChefID",
                table: "Pizza",
                column: "ChefID",
                principalTable: "Chef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Chef_ChefID",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_ChefID",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ChefID",
                table: "Pizza");
        }
    }
}
