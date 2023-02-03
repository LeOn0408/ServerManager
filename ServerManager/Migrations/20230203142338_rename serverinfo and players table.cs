using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerManager.Migrations
{
    /// <inheritdoc />
    public partial class renameserverinfoandplayerstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_sm_server_ServerId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_ServersAdminInfo_sm_server_ServerId",
                table: "ServersAdminInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ServersPublicInfo_sm_server_ServerId",
                table: "ServersPublicInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServersPublicInfo",
                table: "ServersPublicInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServersAdminInfo",
                table: "ServersAdminInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "ServersPublicInfo",
                newName: "sm_serverPublicInfo");

            migrationBuilder.RenameTable(
                name: "ServersAdminInfo",
                newName: "sm_serverAdminInfo");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "sm_players");

            migrationBuilder.RenameIndex(
                name: "IX_ServersPublicInfo_ServerId",
                table: "sm_serverPublicInfo",
                newName: "IX_sm_serverPublicInfo_ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_ServersAdminInfo_ServerId",
                table: "sm_serverAdminInfo",
                newName: "IX_sm_serverAdminInfo_ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_ServerId",
                table: "sm_players",
                newName: "IX_sm_players_ServerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sm_serverPublicInfo",
                table: "sm_serverPublicInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sm_serverAdminInfo",
                table: "sm_serverAdminInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sm_players",
                table: "sm_players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sm_players_sm_server_ServerId",
                table: "sm_players",
                column: "ServerId",
                principalTable: "sm_server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sm_serverAdminInfo_sm_server_ServerId",
                table: "sm_serverAdminInfo",
                column: "ServerId",
                principalTable: "sm_server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sm_serverPublicInfo_sm_server_ServerId",
                table: "sm_serverPublicInfo",
                column: "ServerId",
                principalTable: "sm_server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sm_players_sm_server_ServerId",
                table: "sm_players");

            migrationBuilder.DropForeignKey(
                name: "FK_sm_serverAdminInfo_sm_server_ServerId",
                table: "sm_serverAdminInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_sm_serverPublicInfo_sm_server_ServerId",
                table: "sm_serverPublicInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sm_serverPublicInfo",
                table: "sm_serverPublicInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sm_serverAdminInfo",
                table: "sm_serverAdminInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sm_players",
                table: "sm_players");

            migrationBuilder.RenameTable(
                name: "sm_serverPublicInfo",
                newName: "ServersPublicInfo");

            migrationBuilder.RenameTable(
                name: "sm_serverAdminInfo",
                newName: "ServersAdminInfo");

            migrationBuilder.RenameTable(
                name: "sm_players",
                newName: "Players");

            migrationBuilder.RenameIndex(
                name: "IX_sm_serverPublicInfo_ServerId",
                table: "ServersPublicInfo",
                newName: "IX_ServersPublicInfo_ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_sm_serverAdminInfo_ServerId",
                table: "ServersAdminInfo",
                newName: "IX_ServersAdminInfo_ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_sm_players_ServerId",
                table: "Players",
                newName: "IX_Players_ServerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServersPublicInfo",
                table: "ServersPublicInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServersAdminInfo",
                table: "ServersAdminInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_sm_server_ServerId",
                table: "Players",
                column: "ServerId",
                principalTable: "sm_server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServersAdminInfo_sm_server_ServerId",
                table: "ServersAdminInfo",
                column: "ServerId",
                principalTable: "sm_server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServersPublicInfo_sm_server_ServerId",
                table: "ServersPublicInfo",
                column: "ServerId",
                principalTable: "sm_server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
