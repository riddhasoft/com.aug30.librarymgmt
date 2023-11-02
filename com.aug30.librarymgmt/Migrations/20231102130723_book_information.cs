using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace com.aug30.librarymgmt.Migrations
{
    /// <inheritdoc />
    public partial class book_information : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Publication = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Barcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Edition = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    BookCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookInformations_BookCategories_BookCategoryId",
                        column: x => x.BookCategoryId,
                        principalTable: "BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookInformations_BookCategoryId",
                table: "BookInformations",
                column: "BookCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInformations");
        }
    }
}
