using Microsoft.EntityFrameworkCore.Migrations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Tipo de veículo_TipoVeiculoId",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipo de veículo",
                table: "Tipo de veículo");

            migrationBuilder.RenameTable(
                name: "Tipo de veículo",
                newName: "Tipo_de_veículo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipo_de_veículo",
                table: "Tipo_de_veículo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Tipo_de_veículo_TipoVeiculoId",
                table: "Veiculo",
                column: "TipoVeiculoId",
                principalTable: "Tipo_de_veículo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Tipo_de_veículo_TipoVeiculoId",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipo_de_veículo",
                table: "Tipo_de_veículo");

            migrationBuilder.RenameTable(
                name: "Tipo_de_veículo",
                newName: "Tipo de veículo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipo de veículo",
                table: "Tipo de veículo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Tipo de veículo_TipoVeiculoId",
                table: "Veiculo",
                column: "TipoVeiculoId",
                principalTable: "Tipo de veículo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
