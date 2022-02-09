using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeGallery.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    BlobURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpVote = table.Column<int>(type: "int", nullable: true),
                    Other = table.Column<bool>(type: "bit", nullable: false),
                    SupportingLinks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meme", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meme");
        }
    }
}
