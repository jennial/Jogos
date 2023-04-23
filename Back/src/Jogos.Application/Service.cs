using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.Domain.Models;
using Jogos.Application.Contratos;
using Jogos.Persistence;

namespace Jogos.Applicatio
{
    public class Service : IService
    {
        private readonly IJogosPersistence persist;

        public Service(IJogosPersistence persist)
        {
            this.persist = persist;
            
        }
        public async Task<Jogo> AddJogo(Jogo model)
        {
            try
            {
                persist.Add<Jogo>(model);
                if(await persist.SaveChangesAsync()){
                    return await persist.GetJogoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Jogo> UpdateJogo(int JogoId, Jogo model)
        {
            try
            {
                var jogo = await persist.GetJogoByIdAsync(JogoId, false);
                if (jogo == null) return null;

                model.Id = jogo.Id;

                persist.Update(model);
                if(await persist.SaveChangesAsync()){
                    return await persist.GetJogoByIdAsync(model.Id, false);
                }return null;
                
                }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
   

        public async Task<bool> DeleteJogo(int JogoId)
        {
            try
            {
                var jogo = await persist.GetJogoByIdAsync(JogoId, false);
                if (jogo == null) throw new Exception("Erro ao Deletar");
       
                persist.Delete<Jogo>(jogo);
                return await persist.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Jogo> GetJogoByIdAsync(int JogoId, bool includeGenero = false)
        {
            try
            {
                var jogo =  await persist.GetJogoByIdAsync(JogoId, includeGenero);
                if (jogo == null) return null;

                return jogo;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Jogo[]> GetAllJogosAsync(bool includeGenero = false)
        {
            try
            {
                var jogo =  await persist.GetAllJogosAsync(includeGenero);
                if (jogo == null) return null;

                return jogo;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Jogo[]> GetAllJogosByNomeAsync(string nome, bool includeGenero = false)
        {
            try
            {
                var jogo =  await persist.GetAllJogosByNomeAsync(nome, includeGenero);
                if (jogo == null) return null;

                return jogo;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }    
}