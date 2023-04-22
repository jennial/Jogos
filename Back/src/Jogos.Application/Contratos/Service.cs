using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.Domain.Models;
using Jogos.Persistence;

namespace Jogos.Application.Contratos
{
    public class Service : IJogosService
    {
        private readonly IJogosPersistence persist;

        public Service(IJogosPersistence persist)
        {
            this.persist = persist;
            
        }
        public async Task<Jogo> AddJogos(Jogo model)
        {
           try
           {
                persist.Add<Jogo>(model);
                if(await persist.SaveChangesAsync()){
                    return await persist.GetJogoByIdAsync(model.Id, false); //retorna o ID do jg alterado 
            }
            return null;
           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }

          public async Task<Jogo> UpdateJogo(int jogoId, Jogo model)
        {
            try
            {var jogo = await persist.GetJogoByIdAsync(jogoId, false);
            if(jogo == null) return null;
            model.Id = jogo.Id;

            persist.Update(model);
            if(await persist.SaveChangesAsync()){
                return await persist.GetJogoByIdAsync(model.Id, false);
            }
            return null;}
            catch (Exception ex){
                throw new Exception(ex.Message);
            }

        }
        public async Task<bool> Delete(int jogoId)
        {
        try
            {var jogo = await persist.GetJogoByIdAsync(jogoId, false);
            if(jogo == null) throw new Exception("Não foi encontrado o Jogo para deletar");
    
            persist.Update(jogo);
            return await persist.SaveChangesAsync();
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }


        }

        public Task<Jogo[]> GetAllJogosByNomeAsync(bool includeGenero = true)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo[]> GetAllJogosAsync(string nome, bool includeGenero)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> GetJogoByIdAsync(int JogoId, bool includeGenero)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo[]> GetAllJogosByNomeAsync(string nome, bool includeGenero = true)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo[]> GetAllJogosAsync(bool includeGenero)
        {
            throw new NotImplementedException();
        }
    }

}