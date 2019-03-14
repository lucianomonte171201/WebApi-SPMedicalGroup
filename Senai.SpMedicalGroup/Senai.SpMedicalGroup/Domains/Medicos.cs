﻿using System;
using System.Collections.Generic;

namespace Senai.SpMedicalGroup.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdUsuario { get; set; }

        public Especialidades IdEspecialidadeNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
