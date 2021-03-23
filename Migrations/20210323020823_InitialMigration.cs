using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    NumeroSerie = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alarmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Classificacao = table.Column<int>(type: "int", nullable: false),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarmes_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlarmesAtuados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoAlarme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoEquipamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false),
                    AlarmeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmesAtuados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlarmesAtuados_Alarmes_AlarmeId",
                        column: x => x.AlarmeId,
                        principalTable: "Alarmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlarmesAtuados_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarmes_EquipamentoId",
                table: "Alarmes",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmesAtuados_AlarmeId",
                table: "AlarmesAtuados",
                column: "AlarmeId");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmesAtuados_EquipamentoId",
                table: "AlarmesAtuados",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_NumeroSerie",
                table: "Equipamentos",
                column: "NumeroSerie",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmesAtuados");

            migrationBuilder.DropTable(
                name: "Alarmes");

            migrationBuilder.DropTable(
                name: "Equipamentos");
        }
    }
}
