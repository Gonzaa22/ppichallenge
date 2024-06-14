using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPIChallengeAPI.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoActivoID = table.Column<int>(type: "int", nullable: false),
                    tipoActivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcionEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiposActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposActivos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "TiposActivos");
        }
    }
}
