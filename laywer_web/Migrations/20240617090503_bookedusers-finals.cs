using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laywer_web.Migrations
{
    /// <inheritdoc />
    public partial class bookedusersfinals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lawyer_id",
                table: "tbl_bokedappointment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lawyer_id",
                table: "tbl_bokedappointment");
        }
    }
}
