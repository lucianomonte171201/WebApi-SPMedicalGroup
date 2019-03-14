using System;
using System.Collections.Generic;

namespace Senai.SpMedicalGroup.Domains
{
    public partial class ProntuarioPaciente
    {
        public ProntuarioPaciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Tel { get; set; }
        public int IdUsuario { get; set; }
        public int IdEndereco { get; set; }

        public EnderecoPaciente IdEnderecoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
