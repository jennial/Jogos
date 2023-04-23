using System.Linq;
using System.Threading.Tasks;
using jogos.Domain.Models;
using jogos.Persistence.Contexto;
using Jogos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jogos.Persistence
{
    public class JogosPersistence : IJogosPersistence
    {
        private readonly JogosContext context;
        public JogosPersistence(JogosContext context)
        {
            this.context = context;
            
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

       public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        // public void DeleteRange<T>(T[] entityArray) where T : class
        // {
        //     context.RemoveRange(entityArray);
        // }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
        public async Task<Jogo[]> GetAllJogosByNomeAsync(string nome, bool includeGenero = false)
        {
            IQueryable<Jogo> query= context.Jogos;

            query = query.OrderBy(e => e.Id).Where(e=> e.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Jogo[]> GetAllJogosAsync(bool includeGenero = false)
        {
            IQueryable<Jogo> query= context.Jogos;

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }


        public async Task<Jogo> GetJogoByIdAsync(int JogoId, bool includeGenero = false)
        {
            IQueryable<Jogo> query= context.Jogos;

            query = query.OrderBy(e => e.Id).Where(e=> e.Id == JogoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Genero[]> GetAllGenerosByNomeAsync(string nome, bool includeJogo = false)
        {
            IQueryable<Genero> query= context.Generos;

            query = query.OrderBy(e => e.Id).Where(e=> e.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        } 

        public async Task<Genero[]> GetAllGenerosAsync(bool includeJogo = false)
        {
            IQueryable<Genero> query= context.Generos;

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }       

        

        public async Task<Genero> GetGeneroByIdAsync(int GeneroId, bool includeJogo = false)
        {
            IQueryable<Genero> query= context.Generos;

            query = query.OrderBy(e => e.Id).Where(e=> e.Id == GeneroId);
            return await query.FirstOrDefaultAsync();
        }

       


    }
}