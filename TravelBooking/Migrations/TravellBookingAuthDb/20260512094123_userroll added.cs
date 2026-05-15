using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelBooking.Migrations.TravellBookingAuthDb
{
    /// <inheritdoc />
    public partial class userrolladded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e22e6375-f61f-4e17-b849-c8becf64d143", "e22e6375-f61f-4e17-b849-c8becf64d143", "Writer", "WRITER" },
                    { "ed9fdccd-ae48-4287-81b1-82a6f5d9553f", "ed9fdccd-ae48-4287-81b1-82a6f5d9553f", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e22e6375-f61f-4e17-b849-c8becf64d143");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed9fdccd-ae48-4287-81b1-82a6f5d9553f");
        }
    }
}
