using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WesternInn_TG_SA_AF.Data.Migrations
{
    public partial class Guest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_RoomID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Room",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Booking",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Booking",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RoomID",
                table: "Booking",
                newName: "IX_Booking_RoomId");

            migrationBuilder.AddColumn<string>(
                name: "GuestEmail",
                table: "Booking",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_GuestEmail",
                table: "Booking",
                column: "GuestEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Guest_GuestEmail",
                table: "Booking",
                column: "GuestEmail",
                principalTable: "Guest",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_RoomId",
                table: "Booking",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Guest_GuestEmail",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_RoomId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Booking_GuestEmail",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "GuestEmail",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Room",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Booking",
                newName: "RoomID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Booking",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RoomId",
                table: "Booking",
                newName: "IX_Booking_RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_RoomID",
                table: "Booking",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID");
        }
    }
}
