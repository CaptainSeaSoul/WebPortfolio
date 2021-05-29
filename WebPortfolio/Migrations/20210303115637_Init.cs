using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPortfolio.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Message = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Images = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Progress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Progress = table.Column<int>(nullable: false),
                    CertificateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "Progress", "CertificateId" },
                values: new object[,]
                {
                    { 1, "Russian", 100, null },
                    { 2, "English", 70, null },
                    { 3, "Spanish", 8, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Content", "Images", "ShortDescription", "Title" },
                values: new object[] { 1, "This is a test content for the project with <a href='google.com'>link</a>", "imgs\\projects\\test.jpg", "Shortly", "Title" });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Name", "Url", "Year" },
                values: new object[,]
                {
                    { 11, "Participant of 5th student hackathon from First Line Software", null, 2018 },
                    { 10, "Certificate of Completion English Upper-Intermediate level from Simpler", "https://simpler.link/c/JmQM", 2018 },
                    { 8, "Python 3 Tutorial course from SoloLearn", "https://www.sololearn.com/Certificate/1073-5118349/pdf/", 2018 },
                    { 7, "Java Tutorial course from SoloLearn", "https://www.sololearn.com/Certificate/1068-5118349/pdf/", 2018 },
                    { 6, "SQL Fundamentals course from SoloLearn", "https://www.sololearn.com/Certificate/1060-5118349/pdf/", 2018 },
                    { 9, "c++ Tutorial course from SoloLearn", "https://www.sololearn.com/Certificate/1051-5118349/pdf/", 2018 },
                    { 4, "C# tutorial from SoloLearn", "https://www.sololearn.com/Certificate/1080-5118349/pdf/", 2019 },
                    { 3, "English Upper-Intermediate", null, 2019 },
                    { 2, "Self presentation course: public performance skills in 21 century.", null, 2019 },
                    { 1, "Android app development on Kotlin", "https://stepik.org/cert/330993", 2020 },
                    { 5, "c++ programming course from Computer Science Center", "https://stepik.org/cert/113782", 2018 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "Progress" },
                values: new object[,]
                {
                    { 10, "HTML", 80 },
                    { 1, "Android with Kotlin", 40 },
                    { 2, "ASP.NET Core 3.1", 35 },
                    { 3, "QT with C++", 20 },
                    { 4, "Unity", 15 },
                    { 5, "Git", 55 },
                    { 6, "C#", 60 },
                    { 7, "C++", 60 },
                    { 8, "Java", 60 },
                    { 9, "Python, Jupiter", 60 },
                    { 11, "CSS", 75 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CertificateId",
                table: "Languages",
                column: "CertificateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Certificates");
        }
    }
}
