using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laywer_web.Migrations
{
    /// <inheritdoc />
    public partial class userss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tbl_user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "updatedstatus",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "updatedstatus",
                table: "tbl_user");
        }
    }
}
