using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class _4thMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ziyaret_",
                table: "ziyaretler",
                newName: "ziyaret_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ziyaret_id",
                table: "ziyaretler",
                newName: "ziyaret_");
        }
    }
}
