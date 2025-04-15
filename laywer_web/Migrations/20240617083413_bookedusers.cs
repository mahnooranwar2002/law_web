using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laywer_web.Migrations
{
    /// <inheritdoc />
    public partial class bookedusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_bokedappointment",
                columns: table => new
                {
                    Booked_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lawyer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Booked_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Booked_useremail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Booked_usernumber = table.Column<int>(type: "int", nullable: false),
                    slot_time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bokedappointment", x => x.Booked_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_bokedappointment");
        }
    }
}
