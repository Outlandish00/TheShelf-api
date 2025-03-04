using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheShelf_api.Migrations
{
    /// <inheritdoc />
    public partial class ExternalApiRefactoringForMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Genre",
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "imbdId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad9c7832-b28d-4d68-b27b-9e79a625f5c7", "AQAAAAIAAYagAAAAEGEOnVRkPsG6zoIJxzo7EYhsHz15/syg+WfSWMkAuusixsTWsTvk4u+QrI+UqMYgWw==", "670ad3ec-3505-4757-a052-60d5cfe9bf1a" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "imbdId",
                value: "tt0322802");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "imbdId" },
                values: new object[] { 2, "tt0499549" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "imbdId",
                table: "Movies",
                newName: "Title");

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
                name: "Genre",
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

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07515986-2a6b-4d52-afea-d3995793f747", "AQAAAAIAAYagAAAAEE+rUACNqILbRxQFXTwtJIQ1pTmOt1PHojWu+gAYHnPqav7F3m5f1+UHB7O1B1MIhg==", "2481840f-7978-4cf1-878c-4e339d67a7c4" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Actors", "Director", "Genre", "PosterLink", "Rated", "Rating", "ReleaseYear", "Title", "UserId" },
                values: new object[] { "A lot of them", "John McHohnatan", "Horror", "https://m.media-amazon.com/images/M/MV5BMjk3MmFmNGItOGI1NS00NzNiLWFiMmItOWMyZjE1MmE4N2M2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", "R", "7/10", "2021", "Stream", 1 });
        }
    }
}
