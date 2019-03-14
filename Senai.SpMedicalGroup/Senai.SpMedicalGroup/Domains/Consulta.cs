using Senai.SpMedicalGroup.Enums;
using System;
using System.Collections.Generic;

namespace Senai.SpMedicalGroup.Domains
{
    public partial class Consulta
    {
        public int Id { get; set; }
        public int IdProntuario { get; set; }
        public int IdMedico { get; set; }
        public DateTime DataConsulta { get; set; }
        public string StatusConsulta { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public ProntuarioPaciente IdProntuarioNavigation { get; set; }
    }
}
