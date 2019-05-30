using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarCinema.Migrations
{
    public partial class ChangedMovieCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Movies",
                newName: "TrailerUrl");

            migrationBuilder.AddColumn<bool>(
                name: "Is3D",
                table: "Movies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is3D",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "TrailerUrl",
                table: "Movies",
                newName: "PhotoUrl");
        }
    }
}
