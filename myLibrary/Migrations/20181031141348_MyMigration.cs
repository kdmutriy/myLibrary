using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myLibrary.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameAuthor = table.Column<string>(nullable: true),
                    YearBirth = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameBook = table.Column<string>(nullable: true),
                    YearPublish = table.Column<int>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    CountPage = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "NameAuthor", "YearBirth" },
                values: new object[] { 1, "Россия", "Пушкин Александр Сергеевич", 1799 });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "NameAuthor", "YearBirth" },
                values: new object[] { 2, "Россия", "Лермонтов Михаил Юрьевич", 1838 });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "NameAuthor", "YearBirth" },
                values: new object[] { 3, "Россия", "Булгаков Михаил Афанасьевич", 1891 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CountPage", "NameBook", "Publisher", "YearPublish" },
                values: new object[,]
                {
                    { 1, 1, 160, "Капитанская дочька", "НИГМА", 1836 },
                    { 2, 1, 24, "Полтава", "Художественный фонд", 1829 },
                    { 3, 2, 224, "Герой нашего времени", "Азбука", 1985 },
                    { 4, 3, 480, "Мастер и Маргарита", "Азбука", 1960 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
