using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftwareControle.Models;

namespace SoftwareControle.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {

        }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<OrdensFeitas> OrdensFeita { get; set; }
        public DbSet<CriarOrdem> CriarOrdens { get; set; }
        public DbSet<Ferramenta> Ferramentas { get; set; }


      




    }




}
