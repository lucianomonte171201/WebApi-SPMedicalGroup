﻿using Senai.SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);

        void Atualizar(Clinica novaClinica, Clinica clinicaASerAtualizada);

        Clinica BuscarPorId(int idClinica);
    }
}
