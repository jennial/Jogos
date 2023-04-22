using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.Domain.Models;
using jogos.Persistence;
using Jogos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jogos.Persistence
{
    public class p : IJogosPersistence
    {  
        public JogosContext Context { get; }
        
         public p(JogosContext context)
         {
            this.Context = context;
            
         }
        void IJogosPersistence.Add<T>(T entity)
        {
            Context.Add(entity);
        }

        void IJogosPersistence.Delete<T>(T entity)
        {
            Context.Remove(entity);
        }

        void IJogosPersistence.DeleteRange<T>(T[] entityArray)
        {
            Context.RemoveRange(entityArray);
        }
        async Task<bool> IJogosPersistence.SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync()) > 0;
        }

        void IJogosPersistence.Update<T>(T entity)
        {
            Context.Update(entity);
        }

         async Task<Genero[]> IJogosPersistence.GetAllGenerosAsync(bool includeGenero)
        {
            IQueryable<Genero> query= Context.Generos;

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        async Task<Genero[]> IJogosPersistence.GetAllGenerosByNomeAsync(string nome, bool includeJogo)
        {
              IQueryable<Genero> query= Context.Generos;

            query = query.OrderBy(e => e.Id).Where(e=> e.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        async Task<Jogo[]> IJogosPersistence.GetAllJogosAsync(bool includeGenero)
        {
            IQueryable<Jogo> query= Context.Jogos;

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        async Task<Jogo[]> IJogosPersistence.GetAllJogosByNomeAsync(string nome, bool includeGenero)
        {
            IQueryable<Jogo> query= Context.Jogos;

            query = query.OrderBy(e => e.Id).Where(e=> e.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        async Task<Genero> IJogosPersistence.GetGeneroByIdAsync(int GeneroId, bool includeGenero)
        {
            IQueryable<Genero> query= Context.Generos;

            query = query.OrderBy(e => e.Id).Where(e=> e.Id == GeneroId);
            return await query.FirstOrDefaultAsync();
        }

        async Task<Jogo> IJogosPersistence.GetJogoByIdAsync(int JogoId, bool includeGenero)
        {
            IQueryable<Jogo> query= Context.Jogos;

            query = query.OrderBy(e => e.Id).Where(e=> e.Id == JogoId);

            return await query.FirstOrDefaultAsync();
        }


    }
}