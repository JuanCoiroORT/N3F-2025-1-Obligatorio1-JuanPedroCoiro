using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyCascades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnviosComunes_Usuarios_ClienteId",
                table: "EnviosComunes");

            migrationBuilder.DropForeignKey(
                name: "FK_EnviosComunes_Usuarios_EmpleadoId",
                table: "EnviosComunes");

            migrationBuilder.DropForeignKey(
                name: "FK_EnviosUrgentes_Usuarios_ClienteId",
                table: "EnviosUrgentes");

            migrationBuilder.DropForeignKey(
                name: "FK_EnviosUrgentes_Usuarios_EmpleadoId",
                table: "EnviosUrgentes");

            migrationBuilder.AddForeignKey(
                name: "FK_EnviosComunes_Usuarios_ClienteId",
                table: "EnviosComunes",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnviosComunes_Usuarios_EmpleadoId",
                table: "EnviosComunes",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnviosUrgentes_Usuarios_ClienteId",
                table: "EnviosUrgentes",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); // <- modificamos aquí

            migrationBuilder.AddForeignKey(
                name: "FK_EnviosUrgentes_Usuarios_EmpleadoId",
                table: "EnviosUrgentes",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); // <- y aquí también
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnviosComunes_Usuarios_ClienteId",
                table: "EnviosComunes");

            migrationBuilder.DropForeignKey(
                name: "FK_EnviosComunes_Usuarios_EmpleadoId",
                table: "EnviosComunes");

            migrationBuilder.DropForeignKey(
                name: "FK_EnviosUrgentes_Usuarios_ClienteId",
                table: "EnviosUrgentes");

            migrationBuilder.DropForeignKey(
                name: "FK_EnviosUrgentes_Usuarios_EmpleadoId",
                table: "EnviosUrgentes");

            migrationBuilder.AddForeignKey(
                name: "FK_EnviosComunes_Usuarios_ClienteId",
                table: "EnviosComunes",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnviosComunes_Usuarios_EmpleadoId",
                table: "EnviosComunes",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnviosUrgentes_Usuarios_ClienteId",
                table: "EnviosUrgentes",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); // <- como en Up

            migrationBuilder.AddForeignKey(
                name: "FK_EnviosUrgentes_Usuarios_EmpleadoId",
                table: "EnviosUrgentes",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); // <- como en Up
        }

    }
}
