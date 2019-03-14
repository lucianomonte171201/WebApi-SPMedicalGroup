using Senai.SpMedicalGroup.Domains;
using Senai.SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public Medicos BuscarPorIdUsuario(int idUsuario)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.Medicos.FirstOrDefault(x => x.IdUsuario == idUsuario);
            }
        }
    }
}
