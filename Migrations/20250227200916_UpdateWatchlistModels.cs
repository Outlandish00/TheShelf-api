using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheShelf_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWatchlistModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "WatchListMedias",
                newName: "MovieId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83f767da-21cf-4ebd-b726-dc262b6fe755", "AQAAAAIAAYagAAAAEC6BAdU1g+Jjx11hMtpF4S9gmreuSLqNWEuMLkjNKCdTK3qkp0M2l2Hko1qg0hmhng==", "e4c38533-7866-47c6-9eaf-b8f1cc01174e" });

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedias_MovieId",
                table: "WatchListMedias",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchListMedias_WatchListId",
                table: "WatchListMedias",
                column: "WatchListId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedias_Movies_MovieId",
                table: "WatchListMedias",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListMedias_Watchlists_WatchListId",
                table: "WatchListMedias",
                column: "WatchListId",
                principalTable: "Watchlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedias_Movies_MovieId",
                table: "WatchListMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchListMedias_Watchlists_WatchListId",
                table: "WatchListMedias");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedias_MovieId",
                table: "WatchListMedias");

            migrationBuilder.DropIndex(
                name: "IX_WatchListMedias_WatchListId",
                table: "WatchListMedias");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "WatchListMedias",
                newName: "MediaId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25e4911d-0f0b-42a1-94db-cb2ebd119aa0", "AQAAAAIAAYagAAAAECVoAV+PCa9xp1BMII1Pej0256ii/RUfblkD+5BjlR+Xamc1lEz/datGMjQXZxyPBA==", "c5f48bba-7761-4876-a635-1a036e28919a" });
        }
    }
}
