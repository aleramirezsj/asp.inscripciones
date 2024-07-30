using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inscripciones.Migrations
{
    /// <inheritdoc />
    public partial class addMesasExamenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mesasexamenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Llamado1 = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Llamado2 = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TurnoExamenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesasexamenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mesasexamenes_materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mesasexamenes_turnosexamenes_TurnoExamenId",
                        column: x => x.TurnoExamenId,
                        principalTable: "turnosexamenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "mesasexamenes",
                columns: new[] { "Id", "Horario", "Llamado1", "Llamado2", "MateriaId", "TurnoExamenId" },
                values: new object[] { 1, "18hs", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_mesasexamenes_MateriaId",
                table: "mesasexamenes",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_mesasexamenes_TurnoExamenId",
                table: "mesasexamenes",
                column: "TurnoExamenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mesasexamenes");
        }
    }
}
