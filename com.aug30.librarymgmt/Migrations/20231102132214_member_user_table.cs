using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace com.aug30.librarymgmt.Migrations
{
    /// <inheritdoc />
    public partial class member_user_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ContactNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberInformations");

            migrationBuilder.DropTable(
                name: "UserInformations");
        }
    }
}
