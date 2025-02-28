using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheShelf_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "204f7a94-5348-438e-8594-5129c9222348", "AQAAAAIAAYagAAAAEJXPGlS3huTlvyJJoXSe5KvuC/z9rIkCYdvCwy5WiRQzIJUdlswMvw2mschgWi1f8A==", "c50cbdb0-eb48-4390-b5db-186c020e31c5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cadd4953-ddea-4a6c-aa00-be001d286c6b", "AQAAAAIAAYagAAAAEOW0U88PFIIvMlVddTGzs7UA++OMOUJvl6w9WWrhQxu/u5dAu/qbI06dkD9J28LGrQ==", "13c329c3-e14d-46b0-b1e2-3d15cb40d8be" });
        }
    }
}
