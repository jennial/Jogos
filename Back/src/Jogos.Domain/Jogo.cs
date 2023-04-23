using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogos.Domain;

namespace jogos.Domain.Models
{  
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataLancamento { get; set; }
        public string Descricao { get; set; }
        public Genero Genero { get; set; }
        public string Desenvolvedora { get; set; }

        public IEnumerable<JogoGenero> JogosGeneros { get; set; }
    }


}