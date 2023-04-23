using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.Domain.Models;

namespace Jogos.Application.Contratos
{
    public interface IService
    {
        Task<Jogo> AddJogo(Jogo model);
        Task<Jogo> UpdateJogo(int JogoId, Jogo model);
        Task<bool> DeleteJogo(int JogoId);

        Task<Jogo[]> GetAllJogosAsync(bool includeGenero = false);
        Task<Jogo[]> GetAllJogosByNomeAsync(string nome, bool includeGenero = false);
        Task<Jogo> GetJogoByIdAsync(int JogoId, bool includeGenero = false);

        
    }
}