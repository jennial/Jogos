using jogos.Domain.Models;

namespace Jogos.Domain
{
    public class JogoGenero{
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }

    }
}