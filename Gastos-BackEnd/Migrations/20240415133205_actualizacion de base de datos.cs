using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class actualizaciondebasededatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Categoriald = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__F35292A991230A17", x => x.Categoriald);
                });

            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    Ingresold = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ingreso__DBF5AF368BA5BEE0", x => x.Ingresold);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Personald = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Persona__7C35C71847E88CC5", x => x.Personald);
                });

            migrationBuilder.CreateTable(
                name: "TipoGasto",
                columns: table => new
                {
                    TipoGastold = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoGast__C00FC16A74B21049", x => x.TipoGastold);
                });

            migrationBuilder.CreateTable(
                name: "IngresoPorPersona",
                columns: table => new
                {
                    Ingresold = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Personald = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresoPorPersona", x => new { x.Ingresold, x.Personald });
                    table.ForeignKey(
                        name: "FK__IngresoPo__Ingre__45F365D3",
                        column: x => x.Ingresold,
                        principalTable: "Ingreso",
                        principalColumn: "Ingresold");
                    table.ForeignKey(
                        name: "FK__IngresoPo__Perso__46E78A0C",
                        column: x => x.Personald,
                        principalTable: "Persona",
                        principalColumn: "Personald");
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    TarjetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Personald = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tarjeta__C8250776213C208B", x => x.TarjetaId);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Persona_Personald",
                        column: x => x.Personald,
                        principalTable: "Persona",
                        principalColumn: "Personald");
                });

            migrationBuilder.CreateTable(
                name: "Gasto",
                columns: table => new
                {
                    GastoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    NombreGasto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Personald = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Categoriald = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoGastold = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Gasto__815BB0F042970835", x => x.GastoId);
                    table.ForeignKey(
                        name: "FK__Gasto__Categoria__35BCFE0A",
                        column: x => x.Categoriald,
                        principalTable: "Categoria",
                        principalColumn: "Categoriald");
                    table.ForeignKey(
                        name: "FK__Gasto__Personald__34C8D9D1",
                        column: x => x.Personald,
                        principalTable: "Persona",
                        principalColumn: "Personald");
                    table.ForeignKey(
                        name: "FK__Gasto__TipoGasto__36B12243",
                        column: x => x.TipoGastold,
                        principalTable: "TipoGasto",
                        principalColumn: "TipoGastold");
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    Periodold = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NombrePeriodo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TarjetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Periodo__0ADCD0AC013116D5", x => x.Periodold);
                    table.ForeignKey(
                        name: "FK_Periodo_Tarjeta_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "TarjetaId");
                });

            migrationBuilder.CreateTable(
                name: "PersonaPorTarjeta",
                columns: table => new
                {
                    PersonaPorTarjetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarjetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaPorTarjeta", x => x.PersonaPorTarjetaId);
                    table.ForeignKey(
                        name: "FK_PersonaPorTarjeta_Persona",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Personald");
                    table.ForeignKey(
                        name: "FK_PersonaPorTarjeta_Tarjeta",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "TarjetaId");
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Movimientold = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    GastoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movimien__BF912077B5AA5E24", x => x.Movimientold);
                    table.ForeignKey(
                        name: "FK__Movimient__Gasto__3B75D760",
                        column: x => x.GastoId,
                        principalTable: "Gasto",
                        principalColumn: "GastoId");
                });

            migrationBuilder.CreateTable(
                name: "PeriodoPorGasto",
                columns: table => new
                {
                    Periodold = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GastoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoPorGasto", x => new { x.Periodold, x.GastoId });
                    table.ForeignKey(
                        name: "FK__PeriodoPo__Gasto__440B1D61",
                        column: x => x.GastoId,
                        principalTable: "Gasto",
                        principalColumn: "GastoId");
                    table.ForeignKey(
                        name: "FK__PeriodoPo__Perio__4316F928",
                        column: x => x.Periodold,
                        principalTable: "Periodo",
                        principalColumn: "Periodold");
                });

            migrationBuilder.CreateTable(
                name: "TarjetaPorPeriodo",
                columns: table => new
                {
                    TarjetaId = table.Column<Guid>(name: "TarjetaId ", type: "uniqueidentifier", nullable: false),
                    Periodold = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoutasTotales = table.Column<int>(type: "int", nullable: true),
                    CoutaActual = table.Column<int>(type: "int", nullable: true),
                    GastoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TarjetaPorPeriodo_Gasto",
                        column: x => x.GastoId,
                        principalTable: "Gasto",
                        principalColumn: "GastoId");
                    table.ForeignKey(
                        name: "FK__TarjetaPo__Perio__412EB0B6",
                        column: x => x.Periodold,
                        principalTable: "Periodo",
                        principalColumn: "Periodold");
                    table.ForeignKey(
                        name: "FK__TarjetaPo__Tarje__403A8C7D",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "TarjetaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_Categoriald",
                table: "Gasto",
                column: "Categoriald");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_Personald",
                table: "Gasto",
                column: "Personald");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_TipoGastold",
                table: "Gasto",
                column: "TipoGastold");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoPorPersona_Personald",
                table: "IngresoPorPersona",
                column: "Personald");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_GastoId",
                table: "Movimiento",
                column: "GastoId");

            migrationBuilder.CreateIndex(
                name: "IX_Periodo_TarjetaId",
                table: "Periodo",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoPorGasto_GastoId",
                table: "PeriodoPorGasto",
                column: "GastoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaPorTarjeta_PersonaId",
                table: "PersonaPorTarjeta",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaPorTarjeta_TarjetaId",
                table: "PersonaPorTarjeta",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_Personald",
                table: "Tarjeta",
                column: "Personald");

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaPorPeriodo_GastoId",
                table: "TarjetaPorPeriodo",
                column: "GastoId");

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaPorPeriodo_Periodold",
                table: "TarjetaPorPeriodo",
                column: "Periodold");

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaPorPeriodo_TarjetaId ",
                table: "TarjetaPorPeriodo",
                column: "TarjetaId ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngresoPorPersona");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "PeriodoPorGasto");

            migrationBuilder.DropTable(
                name: "PersonaPorTarjeta");

            migrationBuilder.DropTable(
                name: "TarjetaPorPeriodo");

            migrationBuilder.DropTable(
                name: "Ingreso");

            migrationBuilder.DropTable(
                name: "Gasto");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "TipoGasto");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
