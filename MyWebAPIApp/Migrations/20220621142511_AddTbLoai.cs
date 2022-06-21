using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPIApp.Migrations
{
    public partial class AddTbLoai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaLoai",
                table: "HangHoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoaiHangHoa",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHangHoa", x => x.MaLoai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_LoaiHangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai",
                principalTable: "LoaiHangHoa",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_LoaiHangHoa_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropTable(
                name: "LoaiHangHoa");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "MaLoai",
                table: "HangHoa");
        }
    }
}
