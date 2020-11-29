using Microsoft.EntityFrameworkCore.Migrations;

namespace A5WebAPI.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "chatMemberId",
                table: "ChatRoomMember",
                newName: "chatRoomMembersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "chatRoomMembersId",
                table: "ChatRoomMember",
                newName: "chatMemberId");
        }
    }
}
