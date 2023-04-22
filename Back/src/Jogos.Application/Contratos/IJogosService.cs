using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.Domain.Models;

namespace Jogos.Application.Contratos
{
    public interface IJogosService
    {
        Task<Jogo> AddJogos(Jogo model);
        Task<Jogo> UpdateJogo(int jogoId, Jogo model);
        Task<bool> Delete(int jogoId);

        Task<Jogo[]> GetAllJogosByNomeAsync(string nome, bool includeGenero = true);
        Task<Jogo[]> GetAllJogosAsync(bool includeGenero);
        Task<Jogo> GetJogoByIdAsync(int JogoId, bool includeGenero);
    }
}