using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class eliminaciondelistadetarjetaenpersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_Persona_Personald",
                table: "Tarjeta");

            migrationBuilder.DropIndex(
                name: "IX_Tarjeta_Personald",
                table: "Tarjeta");

            migrationBuilder.DropColumn(
                name: "Personald",
                table: "Tarjeta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Personald",
                table: "Tarjeta",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_Personald",
                table: "Tarjeta",
                column: "Personald");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_Persona_Personald",
                table: "Tarjeta",
                column: "Personald",
                principalTable: "Persona",
                principalColumn: "Personald");
        }
    }
}
