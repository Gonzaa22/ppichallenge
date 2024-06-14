using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPIChallengeAPI.Migrations
{
    public partial class Version4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposActivos",
                table: "TiposActivos");

            migrationBuilder.RenameTable(
                name: "TiposActivos",
                newName: "TiposActivo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposActivo",
                table: "TiposActivo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposActivo",
                table: "TiposActivo");

            migrationBuilder.RenameTable(
                name: "TiposActivo",
                newName: "TiposActivos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposActivos",
                table: "TiposActivos",
                column: "Id");
        }
    }
}
