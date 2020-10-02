using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPortfolio.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Sertificates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sertificates",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Content", "Images", "ShortDescription", "Title" },
                values: new object[] { 1, "This is a test content for the project with <a href='google.com'>link</a>", "imgs\\projects\\test.jpg", "Shortly", "Title" });

            migrationBuilder.InsertData(
                table: "Sertificates",
                columns: new[] { "Id", "Name", "Url", "Year" },
                values: new object[,]
                {
                    { 10, "Sertificate of Completion English Upper-Intermediate level from Simpler", "https://simpler.link/c/JmQM", 2018 },
                    { 9, "c++ Tutorial course from SoloLearn", "https://www.sololearn.com/Certificate/1051-5118349/pdf/", 2018 },
                    { 8, "Python 3 Tutorial course from SoloLearn", "https://www.sololearn.com/Certificate/1073-5118349/pdf/", 2018 },
                    { 7, "Java Tutorial course from SoloLearn", "https://www.sololearn.com/Certificate/1068-5118349/pdf/", 2018 },
                    { 6, "SQL Fundamentals course from SoloLearn", "https://www.sololearn.com/Certificate/1060-5118349/pdf/", 2018 },
                    { 11, "Participant of 5th student hackathon from First Line Software", null, 2018 },
                    { 4, "C# tutorial from SoloLearn", "https://www.sololearn.com/Certificate/1080-5118349/pdf/", 2019 },
                    { 3, "English Upper-Intermediate", null, 2019 },
                    { 2, "Self presentation course: public performance skills in 21 century.", null, 2019 },
                    { 1, "Android app development on Kotlin", "https://stepik.org/cert/330993", 2020 },
                    { 5, "c++ programming course from Computer Science Center", "https://stepik.org/cert/113782", 2018 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "Progress", "Type" },
                values: new object[,]
                {
                    { 10, "HTML", 80, null },
                    { 1, "Android with Kotlin", 40, null },
                    { 2, "ASP.NET Core 3.1", 35, null },
                    { 3, "QT with C++", 20, null },
                    { 4, "Unity", 15, null },
                    { 5, "Git", 55, null },
                    { 6, "C#", 60, null },
                    { 7, "C++", 60, null },
                    { 8, "Java", 60, null },
                    { 9, "Python, Jupiter", 60, null },
                    { 11, "CSS", 75, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sertificates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Sertificates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sertificates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
