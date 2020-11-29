using Microsoft.EntityFrameworkCore.Migrations;

namespace A5WebAPI.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChatRoomMember",
                newName: "chatMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "chatMemberId",
                table: "ChatRoomMember",
                newName: "Id");
        }
    }
}
