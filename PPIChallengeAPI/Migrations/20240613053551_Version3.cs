using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPIChallengeAPI.Migrations
{
    public partial class Version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoActivoID",
                table: "Activos");

            migrationBuilder.AlterColumn<int>(
                name: "tipoActivo",
                table: "Activos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tipoActivo",
                table: "Activos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "tipoActivoID",
                table: "Activos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
