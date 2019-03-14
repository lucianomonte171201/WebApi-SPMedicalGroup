using Senai.SpMedicalGroup.Domains;
using Senai.SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void Atualizar(Clinica novaClinica, Clinica clinicaASerAtualizada)
        {
            clinicaASerAtualizada.Endereco = novaClinica.Endereco ?? clinicaASerAtualizada.Endereco;

            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                ctx.Clinica.Update(clinicaASerAtualizada);
                ctx.SaveChanges();
            }
        }

        public Clinica BuscarPorId(int idClinica)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.Clinica.Find(idClinica);
            }
        }

        public void Cadastrar(Clinica clinica)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
        }
    }
}
