using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.Domain;
using jogos.Domain.Models;
using Jogos.Domain;
using Microsoft.EntityFrameworkCore;

namespace jogos.Persistence
{
    public class JogosContext : DbContext
    {
        public JogosContext(DbContextOptions<JogosContext> options) : base(options) {}
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<JogoGenero> JogosGeneros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<JogoGenero>()
                .HasKey(JG => new{JG.JogoId, JG.GeneroId});
        }

    }
}