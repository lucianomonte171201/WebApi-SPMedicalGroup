﻿using System;
using System.Collections.Generic;

namespace Senai.SpMedicalGroup.Domains
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
