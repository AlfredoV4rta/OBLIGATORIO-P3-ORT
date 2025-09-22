using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEmpresa.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Agregandodatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Equipos_EquipoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EquipoId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "EquipoId",
                table: "Usuarios",
                newName: "IdEquipo");

            migrationBuilder.AddColumn<string>(
                name: "Email_Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_Email",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "IdEquipo",
                table: "Usuarios",
                newName: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EquipoId",
                table: "Usuarios",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Equipos_EquipoId",
                table: "Usuarios",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
