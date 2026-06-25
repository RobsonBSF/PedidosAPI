using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PedidosAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumeroPedido = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteNome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AtualizadoEm", "ClienteNome", "CriadoEm", "NumeroPedido", "Status", "ValorTotal" },
                values: new object[,]
                {
                    { new Guid("10a0dd53-3759-4e51-a943-aee9194fca72"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ana Silva", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PED-0001", 0, 250.00m },
                    { new Guid("6df72602-3a6e-4fb7-a597-6cd737c664a9"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fernanda Lima", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PED-0003", 4, 89.90m },
                    { new Guid("ac2ec4fc-cd6d-4952-bc8c-20e34314a3db"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Carlos Souza", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PED-0002", 2, 1340.00m },
                    { new Guid("b1435725-ee0c-494c-af0e-8fe917b331b8"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ricardo Mendes", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PED-0004", 5, 499.00m },
                    { new Guid("e4677994-bb91-4d4e-a00a-62d7425df5ea"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Juliana Costa", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PED-0005", 6, 720.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
