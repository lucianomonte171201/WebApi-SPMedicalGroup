using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedicalGroup.Domains;
using Senai.SpMedicalGroup.Interfaces;
using Senai.SpMedicalGroup.Repositories;

namespace Senai.SpMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase 
    {
        private IClinicaRepository ClinicaRepository { get; set; }

        public ClinicasController()
        {
            ClinicaRepository = new ClinicaRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Clinica clinica)
        {
            try
            {
                ClinicaRepository.Cadastrar(clinica);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Clinica novaClinica)
        {
            try
            {
                Clinica clinicaASerAtualizada = ClinicaRepository.BuscarPorId(novaClinica.Id);

                if (clinicaASerAtualizada == null)
                {
                    return NotFound(new
                    {
                        mensagem = "A clínica não foi encontrada."
                    });
                }

                ClinicaRepository.Atualizar(novaClinica, clinicaASerAtualizada);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}