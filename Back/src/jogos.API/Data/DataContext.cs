using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jogos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace jogos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Jogo> jogos { get; set; }
    }
}