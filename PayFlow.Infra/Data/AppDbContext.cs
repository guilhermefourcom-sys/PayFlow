using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Models;

namespace PayFlow.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payment { get; set; }
        public DbSet<FastPay> FastPay { get; set; }
        public DbSet<SecurePay> SecurePay { get; set; }
        //public DbSet<PedidoLocacao> Solicitacoes { get; set; }
        //public DbSet<Proposta> Propostas { get; set; }
        //public DbSet<Locacao> Locacoes { get; set; }
        //public DbSet<Conteiner> Conteineres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>(b =>
            {
                b.Property(p => p.GrossAmount).HasPrecision(18, 2);
                b.Property(p => p.Fee).HasPrecision(18, 2);
                b.Property(p => p.NetAmount).HasPrecision(18, 2);

                // Store enums as strings instead of numeric values
                b.Property(p => p.Provider).HasConversion<string>().HasMaxLength(50);
                b.Property(p => p.Status).HasConversion<string>().HasMaxLength(50);
            });

           modelBuilder.Entity<FastPay>(b =>
           {
               // Store enums as strings instead of numeric values
               b.Property(p => p.Status).HasConversion<string>().HasMaxLength(50);
           });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
