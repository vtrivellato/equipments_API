using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class ModifiedRelationsclear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarmes_Equipamentos_EquipamentoId",
                table: "Alarmes");

            migrationBuilder.DropIndex(
                name: "IX_Alarmes_EquipamentoId",
                table: "Alarmes");

            migrationBuilder.DropColumn(
                name: "EquipamentoId",
                table: "Alarmes");

            migrationBuilder.AddColumn<string>(
                name: "EquipamentoPK",
                table: "Alarmes",
                type: "nvarchar(32)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Equipamentos_NumeroSerie",
                table: "Equipamentos",
                column: "NumeroSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Alarmes_EquipamentoPK",
                table: "Alarmes",
                column: "EquipamentoPK");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarmes_Equipamentos_EquipamentoPK",
                table: "Alarmes",
                column: "EquipamentoPK",
                principalTable: "Equipamentos",
                principalColumn: "NumeroSerie",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarmes_Equipamentos_EquipamentoPK",
                table: "Alarmes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Equipamentos_NumeroSerie",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Alarmes_EquipamentoPK",
                table: "Alarmes");

            migrationBuilder.DropColumn(
                name: "EquipamentoPK",
                table: "Alarmes");

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoId",
                table: "Alarmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alarmes_EquipamentoId",
                table: "Alarmes",
                column: "EquipamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarmes_Equipamentos_EquipamentoId",
                table: "Alarmes",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
