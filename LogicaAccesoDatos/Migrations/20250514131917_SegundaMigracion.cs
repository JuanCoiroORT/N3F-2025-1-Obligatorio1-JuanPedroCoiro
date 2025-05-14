using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionPostal = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnviosUrgentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionPostal = table.Column<int>(type: "int", nullable: false),
                    Eficiente = table.Column<bool>(type: "bit", nullable: false),
                    NumTracking = table.Column<double>(type: "float", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviosUrgentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnviosUrgentes_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosUrgentes_Usuarios_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnviosComunes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenciaId = table.Column<int>(type: "int", nullable: false),
                    NumTracking = table.Column<double>(type: "float", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviosComunes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnviosComunes_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosComunes_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosComunes_Usuarios_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    ComunId = table.Column<int>(type: "int", nullable: true),
                    UrgenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimientos_EnviosComunes_ComunId",
                        column: x => x.ComunId,
                        principalTable: "EnviosComunes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seguimientos_EnviosUrgentes_UrgenteId",
                        column: x => x.UrgenteId,
                        principalTable: "EnviosUrgentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seguimientos_Usuarios_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnviosComunes_AgenciaId",
                table: "EnviosComunes",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosComunes_ClienteId",
                table: "EnviosComunes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosComunes_EmpleadoId",
                table: "EnviosComunes",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosUrgentes_ClienteId",
                table: "EnviosUrgentes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosUrgentes_EmpleadoId",
                table: "EnviosUrgentes",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_ComunId",
                table: "Seguimientos",
                column: "ComunId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_EmpleadoId",
                table: "Seguimientos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_UrgenteId",
                table: "Seguimientos",
                column: "UrgenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguimientos");

            migrationBuilder.DropTable(
                name: "EnviosComunes");

            migrationBuilder.DropTable(
                name: "EnviosUrgentes");

            migrationBuilder.DropTable(
                name: "Agencias");
        }
    }
}
