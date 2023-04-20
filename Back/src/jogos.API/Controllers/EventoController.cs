using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace jogos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[] {
                new Evento() {
                    EventoId = 1,
                    Tema ="ANgular",
                    Local = "Belo Horizonte",
                    Lote = "primeiro lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString()
                },
                new Evento(){
                    EventoId = 2,
                    Tema ="xzxzANgular",
                    Local = "Belo",
                    Lote = "primeiro",
                    QtdPessoas = 24,
                    DataEvento = DateTime.Now.AddDays(3).ToString()
                }
            };
        public EventoController()
        {
    
        }

        [HttpGet]
        public IEnumerable<Evento> Get(){
        {
           return _evento;
        }
      } 
    }
}
