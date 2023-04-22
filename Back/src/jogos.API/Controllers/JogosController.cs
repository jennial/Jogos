using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.Persistence;
using jogos.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jogos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace Jogos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogosController : ControllerBase
    {
        public IJogosService JogosSevice { get; }

        public JogosController(IJogosService jogosService)
        {           
            this.JogosSevice = jogosService;

        }     
       
        
        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome){
        {
         try
         {
            var jogos = await JogosSevice.GetAllJogosByNomeAsync(nome, true);
            if (jogos == null)return NotFound("Não foi encontrado nenhuma informação");

            return Ok(jogos);
         }
         catch (Exception ex)
         {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                    $"Erro ao tentar recuperar informações{ex.Message}");
         }
        }
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id){
        {
         try
         {
            var jogos = await JogosSevice.GetJogoByIdAsync(Id, true);
            if (jogos == null)return NotFound("Não foi encontrado nenhuma informação");

            return Ok(jogos);
         }
         catch (Exception ex)
         {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                    $"Erro ao tentar recuperar informações{ex.Message}");
         }
        }
        }


        [HttpPost]
        
        public async Task<IActionResult> Post(Jogo model){
        {
         try
         {
            var jogos = await JogosSevice.AddJogos(model);
            if (jogos == null)return BadRequest("Erro ao adicionar informações");

            return Ok(jogos);
         }
         catch (Exception ex)
         {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                    $"Erro ao tentar adicionar informações{ex.Message}");
         }
        }
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> Put(int Id, Jogo model){
        {
         try
         {
            var jogos = await JogosSevice.UpdateJogo(Id, model);
            if (jogos == null)return BadRequest("Erro ao adicionar informações");

            return Ok(jogos);
         }
         catch (Exception ex)
         {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                    $"Erro ao tentar atualizar informações{ex.Message}");
         }
        }
        }

    }
}
