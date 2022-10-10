using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WesternInn_TG_SA_AF.Data.Migrations
{
    public partial class Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Guest_GuestEmail",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_RoomId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GuestEmail",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Guest_GuestEmail",
                table: "Booking",
                column: "GuestEmail",
                principalTable: "Guest",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_RoomId",
                table: "Booking",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Guest_GuestEmail",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_RoomId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Booking",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "GuestEmail",
                table: "Booking",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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
    }
}
