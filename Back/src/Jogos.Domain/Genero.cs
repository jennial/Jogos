using System.Collections.Generic;

namespace Jogos.Domain
{
    public class Genero{  
        public int Id { get; set; }
        
        public string Nome { get; set; }

         public IEnumerable<JogoGenero> JogosGeneros { get; set; }

    }
}