using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPortfolio.Migrations
{
    public partial class language : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Progress = table.Column<int>(nullable: false),
                    SertificateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Sertificates_SertificateId",
                        column: x => x.SertificateId,
                        principalTable: "Sertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "Progress", "SertificateId" },
                values: new object[] { 1, "Russian", 100, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "Progress", "SertificateId" },
                values: new object[] { 2, "English", 70, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "Progress", "SertificateId" },
                values: new object[] { 3, "Spanish", 8, null });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_SertificateId",
                table: "Languages",
                column: "SertificateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
