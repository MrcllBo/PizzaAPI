using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaAPI.Migrations
{
    public partial class ModelDoughAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoughId",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dough",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsGlutenFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dough", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_DoughId",
                table: "Pizza",
                column: "DoughId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Dough_DoughId",
                table: "Pizza",
                column: "DoughId",
                principalTable: "Dough",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Dough_DoughId",
                table: "Pizza");

            migrationBuilder.DropTable(
                name: "Dough");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_DoughId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "DoughId",
                table: "Pizza");
        }
    }
}
