using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laywer_web.Migrations
{
    /// <inheritdoc />
    public partial class appoint_bookedusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tbl_bokedappointment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tbl_bokedappointment");
        }
    }
}
