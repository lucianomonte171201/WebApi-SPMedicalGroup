using System;
using System.Collections.Generic;

namespace Senai.SpMedicalGroup.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            ProntuarioPaciente = new HashSet<ProntuarioPaciente>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdTipo { get; set; }

        public TipoUsuarios IdTipoNavigation { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<ProntuarioPaciente> ProntuarioPaciente { get; set; }
    }
}
