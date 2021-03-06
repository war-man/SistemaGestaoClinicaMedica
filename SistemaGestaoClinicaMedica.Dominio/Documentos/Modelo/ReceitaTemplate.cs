namespace SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo
{
    public sealed class ReceitaTemplate
    {
        public ReceitaTemplate(string consultaCodigo, string pacienteNome, string pacienteDataNascimento, string pacienteNomeMae, string pacienteSexo, string medicoNome, string medicoCRM, string medicamentos)
        {
            ConsultaCodigo = consultaCodigo;
            PacienteNome = pacienteNome.ToUpper();
            PacienteDataNascimento = pacienteDataNascimento;
            PacienteNomeMae = pacienteNomeMae.ToUpper();
            PacienteSexo = pacienteSexo.ToUpper();
            MedicoNome = medicoNome.ToUpper();
            MedicoCRM = medicoCRM.ToUpper();
            Medicamentos = medicamentos;
        }

        public string ConsultaCodigo { get; set; }
        public string PacienteNome { get; set; }
        public string PacienteDataNascimento { get; set; }
        public string PacienteNomeMae { get; set; }
        public string PacienteSexo { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoCRM { get; set; }
        public string Medicamentos { get; set; }
    }
}
