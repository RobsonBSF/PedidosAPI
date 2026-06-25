using Microsoft.EntityFrameworkCore;
using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Enums;

namespace PedidosAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NumeroPedido)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(e => e.ClienteNome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.ValorTotal)
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Status)
                      .IsRequired();

                entity.Property(e => e.CriadoEm)
                      .IsRequired();

                entity.Property(e => e.AtualizadoEm)
                      .IsRequired();
            });


            modelBuilder.Entity<Order>().HasData(
                new Order(Guid.Parse("10a0dd53-3759-4e51-a943-aee9194fca72"), "PED-0001", "Ana Silva", 250.00m, OrderStatus.ORDER_PLACED, new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc)),
                new Order(Guid.Parse("ac2ec4fc-cd6d-4952-bc8c-20e34314a3db"), "PED-0002", "Carlos Souza", 1340.00m, OrderStatus.PAYMENT_APPROVED, new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc)),
                new Order(Guid.Parse("6df72602-3a6e-4fb7-a597-6cd737c664a9"), "PED-0003", "Fernanda Lima", 89.90m, OrderStatus.HANDLING, new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc)),
                new Order(Guid.Parse("b1435725-ee0c-494c-af0e-8fe917b331b8"), "PED-0004", "Ricardo Mendes", 499.00m, OrderStatus.INVOICED, new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc)),
                new Order(Guid.Parse("e4677994-bb91-4d4e-a00a-62d7425df5ea"), "PED-0005", "Juliana Costa", 720.50m, OrderStatus.CANCELED, new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc))
            );

        }
    }
}