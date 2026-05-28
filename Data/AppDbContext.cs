using Microsoft.EntityFrameworkCore;
using SentinelEye.Models;

namespace SentinelEye.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Tabelas
    public DbSet<Alerta> Alertas { get; set; }

    public DbSet<Ocorrencia> Ocorrencias { get; set; }

    public DbSet<Regiao> Regioes { get; set; }

    public DbSet<Agente> Agentes { get; set; }

    public DbSet<ImagemSatelite> ImagensSatelite { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relacionamento Regiao -> Ocorrencias
        modelBuilder.Entity<Ocorrencia>()
            .HasOne(o => o.Regiao)
            .WithMany(r => r.Ocorrencias)
            .HasForeignKey(o => o.RegiaoId);

        // Relacionamento Ocorrencia -> Alertas
        modelBuilder.Entity<Alerta>()
            .HasOne(a => a.Ocorrencia)
            .WithMany(o => o.Alertas)
            .HasForeignKey(a => a.OcorrenciaId);

        // Relacionamento Ocorrencia -> Imagens
        modelBuilder.Entity<ImagemSatelite>()
            .HasOne(i => i.Ocorrencia)
            .WithMany(o => o.Imagens)
            .HasForeignKey(i => i.OcorrenciaId);

        // Relacionamento Regiao -> Agentes
        modelBuilder.Entity<Agente>()
            .HasOne(a => a.Regiao)
            .WithMany(r => r.Agentes)
            .HasForeignKey(a => a.RegiaoId);
    }
}