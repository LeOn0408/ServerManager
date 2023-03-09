using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerManager.Migrations
{
    /// <inheritdoc />
    public partial class PublicInfoAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicIP",
                table: "sm_serverPublicInfo",
                newName: "Version");

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "sm_serverPublicInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "sm_serverPublicInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "sm_serverPublicInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
