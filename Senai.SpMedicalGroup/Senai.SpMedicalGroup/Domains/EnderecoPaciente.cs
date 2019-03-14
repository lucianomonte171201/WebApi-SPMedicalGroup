using System;
using System.Collections.Generic;

namespace Senai.SpMedicalGroup.Domains
{
    public partial class EnderecoPaciente
    {
        public EnderecoPaciente()
        {
            ProntuarioPaciente = new HashSet<ProntuarioPaciente>();
        }

        public int Id { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }

        public ICollection<ProntuarioPaciente> ProntuarioPaciente { get; set; }
    }
}
