using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaTakip.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ziyaretler",
                columns: table => new
                {
                    hasta_id = table.Column<int>(type: "integer", nullable: false),
                    ziyaret_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    doktor_adi = table.Column<string>(type: "text", nullable: false),
                    sikayet = table.Column<string>(type: "text", nullable: false),
                    tedavi_sekli = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ziyaretler_hastalar_hasta_id",
                        column: x => x.hasta_id,
                        principalTable: "hastalar",
                        principalColumn: "hasta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ziyaretler_hasta_id",
                table: "ziyaretler",
                column: "hasta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ziyaretler");
        }
    }
}
