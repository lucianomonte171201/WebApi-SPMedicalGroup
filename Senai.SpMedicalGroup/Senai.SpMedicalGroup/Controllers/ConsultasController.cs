using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }
        private IMedicoRepository MedicoRepository { get; set; }
        private IProntuarioRepository ProntuarioRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
            ProntuarioRepository = new ProntuarioRepository();
            MedicoRepository = new MedicoRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ConsultaRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Erro: " + ex });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Consulta consulta)
        {
            try
            {
                ConsultaRepository.Cadastrar(consulta);
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
        [Authorize(Roles = "Administrador,Médico")]
        public IActionResult Atualizar(Consulta novaConsulta)
        {
            try
            {
                Consulta consultaASerAtualizada = ConsultaRepository.BuscarPorId(novaConsulta.Id);

                if (consultaASerAtualizada == null)
                {
                    return NotFound(new
                    {
                        mensagem = "A consulta não foi encontrada."
                    });
                }

                ConsultaRepository.Atualizar(novaConsulta, consultaASerAtualizada);

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

        [HttpGet("prontuario")]
        [Authorize(Roles = "Paciente")]
        public IActionResult ListarPorProntuario()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                ProntuarioPaciente pacienteProcurado = ProntuarioRepository.BuscarPorIdUsuario(usuarioId);

                if (pacienteProcurado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Paciente não encontrado."
                    });
                }

                return Ok(ConsultaRepository.ListarPorProntuario(pacienteProcurado.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpGet("medico")]
        [Authorize(Roles = "Médico")]
        public IActionResult ListarPorMedico()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Medicos medicoProcurado = MedicoRepository.BuscarPorIdUsuario(usuarioId);

                if (medicoProcurado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Médico não encontrado."
                    });
                }

                return Ok(ConsultaRepository.ListarPorMedico(medicoProcurado.Id));
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