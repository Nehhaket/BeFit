using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Data.Migrations
{
    public partial class fixIdentityUserIdtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AspNetUsers_IdentityUserId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdentityUserId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59fc3cd1-0b5f-4b0a-a83a-ae9ef9310bee", "AQAAAAEAACcQAAAAEBGhDREZLWhjh3qxmka2FLQUoEGeLTrNI3Nv278l29cBmmg4JIvGfXH1ZNyBkbIYQQ==", "80619c78-2fdd-469d-a8ab-473594aa8565" });

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityUserId",
                table: "User",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_AspNetUsers_IdentityUserId",
                table: "User",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AspNetUsers_IdentityUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdentityUserId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityUserId",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "502422f8-b808-4b6a-921b-9f30c0c6bc02", "AQAAAAEAACcQAAAAEJR84Mq+GaVBY8KXVNv1QRrXaOAoE/sqoh2R+rmWrV/sYLlccCIlzWDH4ULfnASt8A==", "22a6045b-0517-4d0a-9111-37a43af2cbc9" });

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityUserId1",
                table: "User",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_AspNetUsers_IdentityUserId1",
                table: "User",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
