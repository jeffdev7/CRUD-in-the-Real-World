using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Migrations
{
    public partial class addrelacionamentodepartamentoefuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Funcionario_FuncionarioId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_FuncionarioId",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Departamento");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartamentoId",
                table: "Funcionario",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoId",
                table: "Funcionario",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoId",
                table: "Funcionario",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_DepartamentoId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Funcionario");

            migrationBuilder.AddColumn<Guid>(
                name: "FuncionarioId",
                table: "Departamento",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_FuncionarioId",
                table: "Departamento",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Funcionario_FuncionarioId",
                table: "Departamento",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
