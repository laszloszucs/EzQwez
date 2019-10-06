using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "test");

            migrationBuilder.CreateTable(
                name: "Phrases",
                schema: "test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    English = table.Column<string>(nullable: true),
                    Hungarian = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phrases_English",
                schema: "test",
                table: "Phrases",
                column: "English",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phrases_Hungarian",
                schema: "test",
                table: "Phrases",
                column: "Hungarian",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phrases",
                schema: "test");
        }
    }
}
