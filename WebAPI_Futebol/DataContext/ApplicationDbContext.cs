using Microsoft.EntityFrameworkCore;
using WebAPI_Futebol.Models;

namespace WebAPI_Futebol.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<JogadoresModel> Jogadores { get; set;}
    }
}
