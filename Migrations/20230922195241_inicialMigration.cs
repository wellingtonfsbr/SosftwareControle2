using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosftwareControle2.Migrations
{
    /// <inheritdoc />
    public partial class inicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    RelatorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.RelatorioId);
                });

            migrationBuilder.CreateTable(
                name: "Ferramentas",
                columns: table => new
                {
                    FerramentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RelatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferramentas", x => x.FerramentaId);
                    table.ForeignKey(
                        name: "FK_Ferramentas_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "RelatorioId");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdministrador = table.Column<bool>(type: "bit", nullable: false),
                    RelatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "RelatorioId");
                });

            migrationBuilder.CreateTable(
                name: "Admnistradores",
                columns: table => new
                {
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RelatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admnistradores", x => x.AdministradorId);
                    table.ForeignKey(
                        name: "FK_Admnistradores_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "RelatorioId");
                    table.ForeignKey(
                        name: "FK_Admnistradores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CriarOrdem",
                columns: table => new
                {
                    CriarOrdemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FerramentaId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrazoMaximo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelUrgencia = table.Column<int>(type: "int", nullable: false),
                    RelatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriarOrdem", x => x.CriarOrdemId);
                    table.ForeignKey(
                        name: "FK_CriarOrdem_Ferramentas_FerramentaId",
                        column: x => x.FerramentaId,
                        principalTable: "Ferramentas",
                        principalColumn: "FerramentaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CriarOrdem_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "RelatorioId");
                    table.ForeignKey(
                        name: "FK_CriarOrdem_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict  );
                });

            migrationBuilder.CreateTable(
                name: "OrdensFeitas",
                columns: table => new
                {
                    OrdensFeitasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FerramentaId = table.Column<int>(type: "int", nullable: false),
                    CriarOrdemId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensFeitas", x => x.OrdensFeitasId);
                    table.ForeignKey(
                        name: "FK_OrdensFeitas_CriarOrdem_CriarOrdemId",
                        column: x => x.CriarOrdemId,
                        principalTable: "CriarOrdem",
                        principalColumn: "CriarOrdemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdensFeitas_Ferramentas_FerramentaId",
                        column: x => x.FerramentaId,
                        principalTable: "Ferramentas",
                        principalColumn: "FerramentaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdensFeitas_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "RelatorioId");
                    table.ForeignKey(
                        name: "FK_OrdensFeitas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admnistradores_RelatorioId",
                table: "Admnistradores",
                column: "RelatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Admnistradores_UsuarioId",
                table: "Admnistradores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CriarOrdem_FerramentaId",
                table: "CriarOrdem",
                column: "FerramentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CriarOrdem_RelatorioId",
                table: "CriarOrdem",
                column: "RelatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_CriarOrdem_UsuarioId",
                table: "CriarOrdem",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferramentas_RelatorioId",
                table: "Ferramentas",
                column: "RelatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensFeitas_CriarOrdemId",
                table: "OrdensFeitas",
                column: "CriarOrdemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensFeitas_FerramentaId",
                table: "OrdensFeitas",
                column: "FerramentaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensFeitas_RelatorioId",
                table: "OrdensFeitas",
                column: "RelatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensFeitas_UsuarioId",
                table: "OrdensFeitas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RelatorioId",
                table: "Usuarios",
                column: "RelatorioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admnistradores");

            migrationBuilder.DropTable(
                name: "OrdensFeitas");

            migrationBuilder.DropTable(
                name: "CriarOrdem");

            migrationBuilder.DropTable(
                name: "Ferramentas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Relatorios");
        }
    }
}
