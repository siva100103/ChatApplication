using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IP = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    LastSeen = table.Column<DateTime>(nullable: false),
                    Port = table.Column<int>(nullable: false),
                    ProfilePath = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UnseenMessages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IP);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FromIP = table.Column<string>(nullable: true),
                    ReceiverIP = table.Column<string>(nullable: true),
                    Msg = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Seen = table.Column<bool>(nullable: false),
                    ClientIP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Clients_ClientIP",
                        column: x => x.ClientIP,
                        principalTable: "Clients",
                        principalColumn: "IP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_ClientIP",
                table: "Message",
                column: "ClientIP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
