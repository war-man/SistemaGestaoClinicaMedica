using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo
{
    public class ConsultaEvento
    {
        private DateTime _data;

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public DateTime Data
        {
            get => _data.TimeOfDay != TimeSpan.Zero ? _data.AddHours(-3) : _data;
            set => _data = value;
        }
        public string PacienteNome { get; set; }
        public string EspecialidadeId { get; set; }
        public string EspecialidadeNome { get; set; }
        public string MedicoId { get; set; }
        public string MedicoNome { get; set; }
        public string StatusId { get; set; }
        public string StatusNome { get; set; }
    }
}
