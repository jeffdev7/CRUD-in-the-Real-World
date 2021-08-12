using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Veiculo");

            migrationBuilder.AddColumn<Guid>(
                name: "TipoVeiculoId",
                table: "Veiculo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Tipo de veículo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    Modelo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo de veículo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_TipoVeiculoId",
                table: "Veiculo",
                column: "TipoVeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Tipo de veículo_TipoVeiculoId",
                table: "Veiculo",
                column: "TipoVeiculoId",
                principalTable: "Tipo de veículo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Tipo de veículo_TipoVeiculoId",
                table: "Veiculo");

            migrationBuilder.DropTable(
                name: "Tipo de veículo");

            migrationBuilder.DropIndex(
                name: "IX_Veiculo_TipoVeiculoId",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "TipoVeiculoId",
                table: "Veiculo");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Veiculo",
                nullable: true);
        }
    }
}
