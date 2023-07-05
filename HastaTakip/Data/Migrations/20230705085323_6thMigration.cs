using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class _6thMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ziyaretler_hastalar_hasta_id",
                table: "ziyaretler");

            migrationBuilder.DropIndex(
                name: "IX_ziyaretler_hasta_id",
                table: "ziyaretler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ziyaretler_hasta_id",
                table: "ziyaretler",
                column: "hasta_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ziyaretler_hastalar_hasta_id",
                table: "ziyaretler",
                column: "hasta_id",
                principalTable: "hastalar",
                principalColumn: "hasta_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
