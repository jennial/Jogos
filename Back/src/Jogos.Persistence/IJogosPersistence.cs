using System.Threading.Tasks;
using jogos.Domain.Models;
using Jogos.Domain;

namespace Jogos.Persistence
{
    public interface IJogosPersistence //CRUDDML
    {
        public void Add<T>(T entity) where T: class; 
        public void Update<T>(T entity) where T: class;
        public void Delete<T>(T entity) where T: class;
       // public void DeleteRange<T>(T[] entityArray) where T: class;

        public Task<bool> SaveChangesAsync();
        
        public Task<Jogo[]> GetAllJogosByNomeAsync(string nome, bool includeGenero = false);
        public Task<Jogo[]> GetAllJogosAsync(bool includeGenero = false);
        public Task<Jogo> GetJogoByIdAsync(int JogoId, bool includeGenero = false);


        public Task<Genero[]> GetAllGenerosByNomeAsync(string nome, bool includeJogo = false);
        public Task<Genero[]> GetAllGenerosAsync(bool includeJogo = false);
        public Task<Genero> GetGeneroByIdAsync(int GeneroId, bool includeJogo = false);
    }
}