using Senai.SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Interfaces
{
    public interface IMedicoRepository
    {
        Medicos BuscarPorIdUsuario(int idUsuario);
    }
}
