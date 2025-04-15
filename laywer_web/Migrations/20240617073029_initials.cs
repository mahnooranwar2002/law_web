using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laywer_web.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_admin",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_admin", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_admindetails",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_admindetails", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_contact",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_sub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_msg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contact", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_lawyers",
                columns: table => new
                {
                    lawyer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lawyer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lawyer_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lawyer_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_lawyers", x => x.lawyer_id);
                });

            migrationBuilder.CreateTable(
                name: "tbL_lawyersdetail",
                columns: table => new
                {
                    lawyer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lawyer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lawyer_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lawyer_Number = table.Column<int>(type: "int", nullable: false),
                    lawyer_dealed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lawyer_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lawyer_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbL_lawyersdetail", x => x.lawyer_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mycountrry",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mycountrry", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mycitiyes",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coun_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mycitiyes", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_tbl_mycitiyes_tbl_mycountrry_coun_id",
                        column: x => x.coun_id,
                        principalTable: "tbl_mycountrry",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mycitiyes_coun_id",
                table: "tbl_mycitiyes",
                column: "coun_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_admin");

            migrationBuilder.DropTable(
                name: "tbl_admindetails");

            migrationBuilder.DropTable(
                name: "tbl_contact");

            migrationBuilder.DropTable(
                name: "tbl_lawyers");

            migrationBuilder.DropTable(
                name: "tbL_lawyersdetail");

            migrationBuilder.DropTable(
                name: "tbl_mycitiyes");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "tbl_mycountrry");
        }
    }
}
