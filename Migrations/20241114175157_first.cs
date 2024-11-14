using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarTrackerAPIs.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    IdEstabelecimento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_estabelecimento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.IdEstabelecimento);
                });

            migrationBuilder.CreateTable(
                name: "PlacaSolares",
                columns: table => new
                {
                    idPlacaSolar = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_placa_solar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    st_placa_solar = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id_estabelecimento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacaSolares", x => x.idPlacaSolar);
                });

            migrationBuilder.CreateTable(
                name: "RegistroEnergias",
                columns: table => new
                {
                    idRegistroEnergia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_registro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    nr_consumo_kwh = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nr_geracao_kwh = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nr_temperatura = table.Column<int>(name: "nr_temperatura ", type: "NUMBER(10)", nullable: false),
                    Id_PlacaSolar = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroEnergias", x => x.idRegistroEnergia);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cd_senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "PlacaSolares");

            migrationBuilder.DropTable(
                name: "RegistroEnergias");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
