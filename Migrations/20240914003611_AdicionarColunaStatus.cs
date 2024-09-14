using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoletoApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarColunaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Boletos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Boletos");
        }
    }
}
