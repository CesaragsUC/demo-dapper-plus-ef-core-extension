using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDapperPlus.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(120)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(80)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(80)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documento_Bairro",
                table: "Documento",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_PessoaId",
                table: "Documento",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documento_UF",
                table: "Documento",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Bairro",
                table: "Endereco",
                column: "Bairro");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Cep",
                table: "Endereco",
                column: "Cep");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Cidade_Estado",
                table: "Endereco",
                columns: new[] { "Cidade", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Complemento",
                table: "Endereco",
                column: "Complemento");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Logradouro",
                table: "Endereco",
                column: "Logradouro");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Numero",
                table: "Endereco",
                column: "Numero");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaId",
                table: "Endereco",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Idade",
                table: "Pessoa",
                column: "Idade");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Name",
                table: "Pessoa",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
