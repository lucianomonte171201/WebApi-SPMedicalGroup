using Senai.SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Interfaces
{
    public interface IConsultaRepository
    {
        List<Consulta> Listar();

       
        void Atualizar(Consulta novaConsulta, Consulta consultaASerAtualizada);

        
        void Cadastrar(Consulta consulta);

        
        List<Consulta> ListarPorMedico(int idMedico);

       
        List<Consulta> ListarPorProntuario(int idProntuario);

        
        Consulta BuscarPorId(int id);
    }
}
