using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class AppDataContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<IMC> IMCs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Joao_Morgado.db");
        }
    }
}