using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class PlayersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "BlokYukseklik",
                table: "Players",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Boy",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KadinMi",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Kilo",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SagElMi",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "SmacYukseklik",
                table: "Players",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BlokYukseklik",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Boy",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "KadinMi",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Kilo",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SagElMi",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SmacYukseklik",
                table: "Players");
        }
    }
}
