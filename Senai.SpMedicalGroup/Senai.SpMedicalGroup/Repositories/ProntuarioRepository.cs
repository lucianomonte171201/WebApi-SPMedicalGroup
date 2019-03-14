using Senai.SpMedicalGroup.Domains;
using Senai.SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        public ProntuarioPaciente BuscarPorIdUsuario(int idUsuario)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.ProntuarioPaciente.FirstOrDefault(x => x.IdUsuario == idUsuario);
            }
        }
    }
}
