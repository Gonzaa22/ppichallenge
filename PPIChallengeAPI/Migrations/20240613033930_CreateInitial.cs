using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPIChallengeAPI.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cuentaID = table.Column<int>(type: "int", nullable: false),
                    activoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    operacion = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    estadoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    montoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordenes");
        }
    }
}
