using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheShelf_api.Migrations
{
    /// <inheritdoc />
    public partial class MovieModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PosterLink",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rated",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseYear",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cadd4953-ddea-4a6c-aa00-be001d286c6b", "AQAAAAIAAYagAAAAEOW0U88PFIIvMlVddTGzs7UA++OMOUJvl6w9WWrhQxu/u5dAu/qbI06dkD9J28LGrQ==", "13c329c3-e14d-46b0-b1e2-3d15cb40d8be" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Actors", "Director", "PosterLink", "Rated", "Rating", "ReleaseYear" },
                values: new object[] { "A lot of them", "John McHohnatan", "https://m.media-amazon.com/images/M/MV5BMjk3MmFmNGItOGI1NS00NzNiLWFiMmItOWMyZjE1MmE4N2M2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", "R", "7/10", "2021" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PosterLink",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rated",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83f767da-21cf-4ebd-b726-dc262b6fe755", "AQAAAAIAAYagAAAAEC6BAdU1g+Jjx11hMtpF4S9gmreuSLqNWEuMLkjNKCdTK3qkp0M2l2Hko1qg0hmhng==", "e4c38533-7866-47c6-9eaf-b8f1cc01174e" });
        }
    }
}
