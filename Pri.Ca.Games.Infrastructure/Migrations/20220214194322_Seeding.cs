using Microsoft.EntityFrameworkCore.Migrations;

namespace Pri.Ca.Games.Infrastructure.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fifa2008" },
                    { 2, "Skyrim" },
                    { 3, "Halo" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Shooter" },
                    { 3, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesId", "GenresId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GamesId", "GenresId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
