using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.Domain.Models;
using Jogos.Domain;

namespace Jogos.Persistence
{
    public interface IJogosPersistence //CRUDDML
    {
        void Add<T>(T entity) where T: class; 
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entityArray) where T: class;

        Task<bool> SaveChangesAsync();
        
        Task<Jogo[]> GetAllJogosByNomeAsync(string nome, bool includeGenero);
        Task<Jogo[]> GetAllJogosAsync(bool includeGenero);
        Task<Jogo> GetJogoByIdAsync(int JogoId, bool includeGenero);


        Task<Genero[]> GetAllGenerosByNomeAsync(string nome, bool includeJogo);
        Task<Genero[]> GetAllGenerosAsync(bool includeGenero);
        Task<Genero> GetGeneroByIdAsync(int GeneroId, bool includeGenero);
    }
}