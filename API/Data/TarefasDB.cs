using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Data
{
    public class TarefasDB : DbContext 
    {
        public TarefasDB(DbContextOptions<TarefasDB> options)
            : base(options)
        { 

        }
            public DbSet<UsuarioModel> Usuarios { get; set; }

            public DbSet<FuncoesModel> Funcoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
    }
