using Senai.SpMedicalGroup.Domains;
using Senai.SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void Atualizar(Consulta novaConsulta, Consulta consultaASerAtualizada)
        {
            if (novaConsulta.StatusConsulta != null)
            {
                consultaASerAtualizada.StatusConsulta = novaConsulta.StatusConsulta;
            }

            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                ctx.Consulta.Update(consultaASerAtualizada);
                ctx.SaveChanges();
            }
        }

        public Consulta BuscarPorId(int idConsulta)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.Consulta.Find(idConsulta);
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consulta> ListarPorMedico(int idMedico)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.Consulta.Where(x => x.IdMedico == idMedico).ToList();
            }
        }

        public List<Consulta> ListarPorProntuario(int idProntuario)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.Consulta.Where(x => x.IdProntuario == idProntuario).ToList();
            }
        }

        public List<Consulta> Listar()
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.Consulta.ToList();
            }
        }
    }
}
