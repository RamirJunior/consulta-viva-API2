using consulta_viva_API2.Models;
using Microsoft.EntityFrameworkCore;

namespace consulta_viva_API2.Data {
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var builder = WebApplication.CreateBuilder();
            string? connectionString = builder.Configuration.GetConnectionString("Database");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Medico>(medico => {
                medico.Property(m => m.MedicoId).ValueGeneratedOnAdd();
                medico.Property(m => m.Nome).IsRequired();
            });

            modelBuilder.Entity<Paciente>(paciente => {
                paciente.Property(p => p.PacienteId).ValueGeneratedOnAdd();
                paciente.Property(p => p.Nome) .IsRequired();
            });
                
            modelBuilder.Entity<Consulta>(consulta => {
                consulta.Property(c => c.ConsultaId).ValueGeneratedOnAdd();
                consulta.Property(c => c.PacienteId).IsRequired();
                consulta.Property(c => c.DataConsulta).IsRequired();
                consulta.Property(c => c.Status).IsRequired();

                consulta.HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .IsRequired();

                consulta.HasOne(c => c.Medico)
                .WithMany(m => m.Consultas);
            });
        }
    }
}
