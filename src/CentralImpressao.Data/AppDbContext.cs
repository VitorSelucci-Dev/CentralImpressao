using CentralImpressao.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentralImpressao.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<UnidadeMedida> UnidadesMedida { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Produto>()
        .HasOne(p => p.UnidadeMedida)
        .WithMany(u => u.Produtos)
        .HasForeignKey(p => p.UnidadeMedidaId);
    }
  }
}