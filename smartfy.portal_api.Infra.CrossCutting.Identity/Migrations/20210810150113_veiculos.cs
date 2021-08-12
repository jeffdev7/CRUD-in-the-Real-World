using Microsoft.EntityFrameworkCore.Migrations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Migrations
{
    public partial class veiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Tipo_de_veículo_TipoVeiculoId",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipo_de_veículo",
                table: "Tipo_de_veículo");

            migrationBuilder.RenameTable(
                name: "Veiculo",
                newName: "Veiculos");

            migrationBuilder.RenameTable(
                name: "Tipo_de_veículo",
                newName: "TipoVeiculos");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculo_TipoVeiculoId",
                table: "Veiculos",
                newName: "IX_Veiculos_TipoVeiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoVeiculos",
                table: "TipoVeiculos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TipoVeiculos_TipoVeiculoId",
                table: "Veiculos",
                column: "TipoVeiculoId",
                principalTable: "TipoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TipoVeiculos_TipoVeiculoId",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoVeiculos",
                table: "TipoVeiculos");

            migrationBuilder.RenameTable(
                name: "Veiculos",
                newName: "Veiculo");

            migrationBuilder.RenameTable(
                name: "TipoVeiculos",
                newName: "Tipo_de_veículo");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_TipoVeiculoId",
                table: "Veiculo",
                newName: "IX_Veiculo_TipoVeiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo",
                column: "Id");

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
    }
}
