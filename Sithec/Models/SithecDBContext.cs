using Microsoft.EntityFrameworkCore;

namespace Sithec.Models
{
    public class SithecDBContext: DbContext
    {

        public SithecDBContext() { }

        public SithecDBContext(DbContextOptions<SithecDBContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Human>().HasData(
                new Human
                {
                    Id= 3,
                    Nombre = "Gerardo",
                    Edad = 20,
                    Altura = 190,
                    Peso = 180,
                    Sexo = "Masculino"
                }
                );
        }

        public virtual DbSet<Human> Human { get; set; }
    }
}
