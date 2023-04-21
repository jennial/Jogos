using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.API.Data;
using jogos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jogos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogosController : ControllerBase
    {
        private readonly DataContext _context;
        public JogosController(DataContext context)
        {           
            _context = context;    
        }     
       
        
        [HttpGet]
        public IEnumerable<Jogo> Get(){
        {
           return _context.jogos;
        }
      } 
    }
}
