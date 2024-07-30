using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inscripciones.Migrations
{
    /// <inheritdoc />
    public partial class addDetallesMesasExamenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detallesmesasexamenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MesaExamenId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    TipoIntegrante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallesmesasexamenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallesmesasexamenes_docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallesmesasexamenes_mesasexamenes_MesaExamenId",
                        column: x => x.MesaExamenId,
                        principalTable: "mesasexamenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "detallesmesasexamenes",
                columns: new[] { "Id", "DocenteId", "MesaExamenId", "TipoIntegrante" },
                values: new object[,]
                {
                    { 1, 1, 1, 0 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_detallesmesasexamenes_DocenteId",
                table: "detallesmesasexamenes",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesmesasexamenes_MesaExamenId",
                table: "detallesmesasexamenes",
                column: "MesaExamenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallesmesasexamenes");
        }
    }
}
