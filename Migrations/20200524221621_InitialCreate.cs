﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Codacious.GraphQL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    AllowedSmoking = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(nullable: false),
                    GuestId = table.Column<int>(nullable: false),
                    CheckinDate = table.Column<DateTime>(nullable: false),
                    CheckoutDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Name", "RegisterDate" },
                values: new object[,]
                {
                    { 1, "Alper Ebicoglu", new DateTime(2020, 5, 15, 0, 16, 21, 613, DateTimeKind.Local).AddTicks(3274) },
                    { 2, "George Michael", new DateTime(2020, 5, 20, 0, 16, 21, 617, DateTimeKind.Local).AddTicks(9109) },
                    { 3, "Daft Punk", new DateTime(2020, 5, 24, 0, 16, 21, 617, DateTimeKind.Local).AddTicks(9266) }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AllowedSmoking", "Name", "Number", "Status" },
                values: new object[,]
                {
                    { 1, false, "yellow-room", 101, 1 },
                    { 2, false, "blue-room", 102, 1 },
                    { 3, false, "white-room", 103, 0 },
                    { 4, false, "black-room", 104, 0 },
                    { 5, true, "foggy-room", 105, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckinDate", "CheckoutDate", "GuestId", "RoomId" },
                values: new object[] { 1, new DateTime(2020, 5, 23, 0, 16, 21, 618, DateTimeKind.Local).AddTicks(2559), new DateTime(2020, 5, 28, 0, 16, 21, 618, DateTimeKind.Local).AddTicks(2576), 1, 3 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckinDate", "CheckoutDate", "GuestId", "RoomId" },
                values: new object[] { 2, new DateTime(2020, 5, 24, 0, 16, 21, 618, DateTimeKind.Local).AddTicks(5876), new DateTime(2020, 5, 29, 0, 16, 21, 618, DateTimeKind.Local).AddTicks(5894), 2, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestId",
                table: "Reservations",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}