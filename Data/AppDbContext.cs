using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data{
    public class AppDbContext : DbContext 
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder opcoes)
            => opcoes.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}