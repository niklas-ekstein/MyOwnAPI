using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace A5WebAPI.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatMessagesID = table.Column<int>(type: "int", nullable: false),
                    chatRoomID = table.Column<int>(type: "int", nullable: false),
                    chatMemberID = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    chatRoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chatRoomOwner = table.Column<int>(type: "int", nullable: false),
                    roomName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.chatRoomID);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoomMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chatRoomID = table.Column<int>(type: "int", nullable: false),
                    chatUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomMember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatUserSelect",
                columns: table => new
                {
                    chatUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUserSelect", x => x.chatUserID);
                });

            migrationBuilder.InsertData(
                table: "ChatUserSelect",
                columns: new[] { "chatUserID", "password", "username" },
                values: new object[] { 1, "assignment5", "assignment5" });

            migrationBuilder.InsertData(
                table: "ChatUserSelect",
                columns: new[] { "chatUserID", "password", "username" },
                values: new object[] { 2, "assignment52", "assignment52" });

            migrationBuilder.InsertData(
                table: "ChatUserSelect",
                columns: new[] { "chatUserID", "password", "username" },
                values: new object[] { 3, "assignment53", "assignment53" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "ChatRoomMember");

            migrationBuilder.DropTable(
                name: "ChatUserSelect");
        }
    }
}
