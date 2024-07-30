using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inscripciones.Migrations
{
    /// <inheritdoc />
    public partial class addDocentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "docentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "docentes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "M. Aimar" },
                    { 2, "E. Albaristo" },
                    { 3, "A. Alesso" },
                    { 4, "M. Alesso" },
                    { 5, "P. Arnolfo" },
                    { 6, "D. Bazan" },
                    { 7, "Blanche" },
                    { 8, "J. Bogni" },
                    { 9, "D. Brondino" },
                    { 10, "G. Brussa" },
                    { 11, "MB. Buceta" },
                    { 12, "F. Bueno" },
                    { 13, "G. Cainero" },
                    { 14, "M. Calvo Tobias" },
                    { 15, "J. Cavallini" },
                    { 16, "L. Chauderón" },
                    { 17, "V. Chelini" },
                    { 18, "R. Corradi" },
                    { 19, "C. Dalesio" },
                    { 20, "C. Dellaferrera" },
                    { 21, "O. Degiorgio" },
                    { 22, "M. Della Rosa" },
                    { 23, "M. Doglioli" },
                    { 24, "C. Duran" },
                    { 25, "F. Espru" },
                    { 26, "M. Ferrero" },
                    { 27, "N. Ferri" },
                    { 28, "M. Ferreyra" },
                    { 29, "JP. Gaido" },
                    { 30, "M. Galmes" },
                    { 31, "A. Genero" },
                    { 32, "V. Gomez" },
                    { 33, "L. Gongora" },
                    { 34, "MC. Gretter" },
                    { 35, "S. Grosso" },
                    { 36, "R. Imhof" },
                    { 37, "M. Imperiale" },
                    { 38, "L. Lodi" },
                    { 39, "F. Lovino" },
                    { 40, "J. Mancilla" },
                    { 41, "S. Manattini" },
                    { 42, "A. Marenoni" },
                    { 43, "G. Martinez" },
                    { 44, "M. Mendoza" },
                    { 45, "A. Miñoz" },
                    { 46, "T. Molina" },
                    { 47, "MI. Monzón" },
                    { 48, "R. Nasimbera" },
                    { 49, "L. Ortiz" },
                    { 50, "M. Paredes" },
                    { 51, "F. Pedrazzoli" },
                    { 52, "S. Pereyra" },
                    { 53, "S. Peressin" },
                    { 54, "C. Prida" },
                    { 55, "D. Puccio" },
                    { 56, "E. Quaglia" },
                    { 57, "RA. Ramirez" },
                    { 58, "D. Renteria" },
                    { 59, "J. Rodriguez Quain" },
                    { 60, "E. Rosso" },
                    { 61, "R. Sanchez" },
                    { 62, "P. Sandoval" },
                    { 63, "I. Sancho" },
                    { 64, "J. Sara" },
                    { 65, "J. Strada" },
                    { 66, "C. Tovar" },
                    { 67, "V. Travesani" },
                    { 68, "C. Tregnaghi" },
                    { 69, "MR. Tschopp" },
                    { 70, "A. Verzzali" },
                    { 71, "E. Vigniatti" },
                    { 72, "MF. Villa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "docentes");
        }
    }
}
