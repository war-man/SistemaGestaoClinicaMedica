using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGestaoClinicaMedica.Infra.Data.Migrations
{
    public partial class BancoDeProducao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: false),
                    NomeDaMae = table.Column<string>(maxLength: 500, nullable: false),
                    CPF = table.Column<string>(maxLength: 50, nullable: false),
                    Sexo = table.Column<string>(maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false),
                    Bairro = table.Column<string>(maxLength: 500, nullable: false),
                    Cidade = table.Column<string>(maxLength: 500, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusConsulta",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusConsulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusExame",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusExame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeAtestado",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeAtestado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeExame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeExame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(maxLength: 100, nullable: true),
                    Senha = table.Column<string>(maxLength: 100, nullable: false),
                    CargoId = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    NomeFabrica = table.Column<string>(maxLength: 100, nullable: false),
                    Tarja = table.Column<string>(maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    FabricanteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrador_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DaClinica = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratorio_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CRM = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recepcionista",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepcionista_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 1000, nullable: true),
                    StatusConsultaId = table.Column<string>(nullable: false),
                    PacienteId = table.Column<Guid>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: false),
                    EspecialidadeId = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_StatusConsulta_StatusConsultaId",
                        column: x => x.StatusConsultaId,
                        principalTable: "StatusConsulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorarioDeTrabalho",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiaDaSemana = table.Column<int>(nullable: false),
                    Inicio = table.Column<TimeSpan>(nullable: false),
                    InicioIntervalo = table.Column<TimeSpan>(nullable: false),
                    FimIntervalo = table.Column<TimeSpan>(nullable: false),
                    Fim = table.Column<TimeSpan>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioDeTrabalho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioDeTrabalho_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: false),
                    EspecialidadeId = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atestado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 5000, nullable: true),
                    TipoDeAtestadoId = table.Column<string>(nullable: false),
                    ConsultaId = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atestado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atestado_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atestado_TipoDeAtestado_TipoDeAtestadoId",
                        column: x => x.TipoDeAtestadoId,
                        principalTable: "TipoDeAtestado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoDeExameId = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 5000, nullable: true),
                    StatusExameId = table.Column<string>(nullable: false),
                    LaboratorioRealizouExameId = table.Column<Guid>(nullable: true),
                    ConsultaId = table.Column<Guid>(nullable: false),
                    LinkResultadoExame = table.Column<string>(maxLength: 500, nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exame_Laboratorio_LaboratorioRealizouExameId",
                        column: x => x.LaboratorioRealizouExameId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exame_StatusExame_StatusExameId",
                        column: x => x.StatusExameId,
                        principalTable: "StatusExame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exame_TipoDeExame_TipoDeExameId",
                        column: x => x.TipoDeExameId,
                        principalTable: "TipoDeExame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 5000, nullable: false),
                    ConsultaId = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaMedicamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false),
                    MedicamentoId = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaMedicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceitaMedicamento_Medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaMedicamento_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_UsuarioId",
                table: "Administrador",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Atestado_ConsultaId",
                table: "Atestado",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atestado_TipoDeAtestadoId",
                table: "Atestado",
                column: "TipoDeAtestadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_Id_Nome",
                table: "Cargo",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_EspecialidadeId",
                table: "Consulta",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoId",
                table: "Consulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_StatusConsultaId",
                table: "Consulta",
                column: "StatusConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidade_Id_Nome",
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exame_ConsultaId",
                table: "Exame",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_LaboratorioRealizouExameId",
                table: "Exame",
                column: "LaboratorioRealizouExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_StatusExameId",
                table: "Exame",
                column: "StatusExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_TipoDeExameId",
                table: "Exame",
                column: "TipoDeExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabricante_Nome",
                table: "Fabricante",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDeTrabalho_MedicoId",
                table: "HorarioDeTrabalho",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratorio_UsuarioId",
                table: "Laboratorio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_FabricanteId",
                table: "Medicamento",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_Nome_NomeFabrica",
                table: "Medicamento",
                columns: new[] { "Nome", "NomeFabrica" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medico_CRM",
                table: "Medico",
                column: "CRM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medico_UsuarioId",
                table: "Medico",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_EspecialidadeId",
                table: "MedicoEspecialidade",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_MedicoId",
                table: "MedicoEspecialidade",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_CPF",
                table: "Paciente",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receita_ConsultaId",
                table: "Receita",
                column: "ConsultaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaMedicamento_MedicamentoId",
                table: "ReceitaMedicamento",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaMedicamento_ReceitaId",
                table: "ReceitaMedicamento",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcionista_UsuarioId",
                table: "Recepcionista",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusConsulta_Id_Nome",
                table: "StatusConsulta",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusExame_Id_Nome",
                table: "StatusExame",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeAtestado_Id_Nome",
                table: "TipoDeAtestado",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeExame_Id_Nome",
                table: "TipoDeExame",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CargoId",
                table: "Usuario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Atestado");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "HorarioDeTrabalho");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidade");

            migrationBuilder.DropTable(
                name: "ReceitaMedicamento");

            migrationBuilder.DropTable(
                name: "Recepcionista");

            migrationBuilder.DropTable(
                name: "TipoDeAtestado");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "StatusExame");

            migrationBuilder.DropTable(
                name: "TipoDeExame");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Fabricante");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "StatusConsulta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
