using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class _9thMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasta_id",
                table: "ziyaretler");

            migrationBuilder.AddColumn<int>(
                name: "ziyaret_id",
                table: "hastalar",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_hastalar_ziyaret_id",
                table: "hastalar",
                column: "ziyaret_id");

            migrationBuilder.AddForeignKey(
                name: "FK_hastalar_ziyaretler_ziyaret_id",
                table: "hastalar",
                column: "ziyaret_id",
                principalTable: "ziyaretler",
                principalColumn: "ziyaret_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hastalar_ziyaretler_ziyaret_id",
                table: "hastalar");

            migrationBuilder.DropIndex(
                name: "IX_hastalar_ziyaret_id",
                table: "hastalar");

            migrationBuilder.DropColumn(
                name: "ziyaret_id",
                table: "hastalar");

            migrationBuilder.AddColumn<int>(
                name: "hasta_id",
                table: "ziyaretler",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
