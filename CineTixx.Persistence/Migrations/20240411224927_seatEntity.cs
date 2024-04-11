using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineTixx.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seatEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasIMAX",
                table: "CinemaRooms");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "CinemaRooms",
                newName: "NumberOfSeats");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CinemaRooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "CinemaRooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    SeatRow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CinemaRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_CinemaRooms_CinemaRoomId",
                        column: x => x.CinemaRoomId,
                        principalTable: "CinemaRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CinemaRoomId",
                table: "Seats",
                column: "CinemaRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.RenameColumn(
                name: "NumberOfSeats",
                table: "CinemaRooms",
                newName: "Capacity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CinemaRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "CinemaRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasIMAX",
                table: "CinemaRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
