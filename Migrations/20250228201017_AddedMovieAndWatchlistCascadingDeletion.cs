using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheShelf_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedMovieAndWatchlistCascadingDeletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07515986-2a6b-4d52-afea-d3995793f747", "AQAAAAIAAYagAAAAEE+rUACNqILbRxQFXTwtJIQ1pTmOt1PHojWu+gAYHnPqav7F3m5f1+UHB7O1B1MIhg==", "2481840f-7978-4cf1-878c-4e339d67a7c4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "204f7a94-5348-438e-8594-5129c9222348", "AQAAAAIAAYagAAAAEJXPGlS3huTlvyJJoXSe5KvuC/z9rIkCYdvCwy5WiRQzIJUdlswMvw2mschgWi1f8A==", "c50cbdb0-eb48-4390-b5db-186c020e31c5" });
        }
    }
}
