using System.Collections.Generic;
using jogos.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using jogos.Persistence.Contexto;
using Jogos.Application.Contratos;
using System.Threading.Tasks;
using Jogos.Applicatio;
using System;
using Microsoft.AspNetCore.Http;

namespace Jogos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogosController : ControllerBase
    {
        //public IJogosService JogosService { get; }
        private readonly IService service;

        public JogosController(IService service)
        {           
            this.service = service;

        }            
        
        [HttpGet]
        public async Task<IActionResult> Get(){
        {
         try
         {
            var jogos = await service.GetAllJogosAsync(true);
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
        public async Task<IActionResult> GetById(int id){
        {
         try
         {
            var jogos = await service.GetJogoByIdAsync(id, true);
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

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome){
        {
         try
         {
            var jogos = await service.GetAllJogosByNomeAsync(nome, true);
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
            var jogos = await service.AddJogo(model);
            if (jogos == null)return BadRequest("Não foi encontrado nenhuma informação");

            return Ok(jogos);
         }
         catch (Exception ex)
         {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                    $"Erro ao tentar recuperar informações{ex.Message}");
         }
        }
        } 

        [HttpPut]
        public async Task<IActionResult> Put(int id, Jogo model){
        {
         try
         {
            var jogos = await service.UpdateJogo(id, model);
            if (jogos == null)return BadRequest("Não foi encontrado nenhuma informação");

            return Ok(jogos);
         }
         catch (Exception ex)
         {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                    $"Erro ao tentar recuperar informações{ex.Message}");
         }
        }
        } 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
        {
         try
         {
           if(await service.DeleteJogo(id))

            return Ok("Deletado");
            else
            return BadRequest("Não foi encontrado nenhuma informação");

         }
         catch (Exception ex)
         {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                    $"Erro ao tentar recuperar informações{ex.Message}");
         }
        }
        } 
    }
}