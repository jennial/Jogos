using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace jogos.API.Models
{  [Keyless]
    public class Jogo
    {
        public int IdJogo { get; set; }
        public string Nome { get; set; }
        public string DataLancamento { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public string Desenvolvedora { get; set; }
    }


}