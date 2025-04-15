using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laywer_web.Migrations
{
    /// <inheritdoc />
    public partial class mylawyers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "lawyer_dis",
                table: "tbL_lawyersdetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lawyer_dis",
                table: "tbL_lawyersdetail");
        }
    }
}
