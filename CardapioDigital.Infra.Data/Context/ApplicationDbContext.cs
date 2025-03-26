using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<AtendimentoPedidoCliente> AtendimentoPedidoCliente { get; set; }
    public DbSet<AtendimentoPedidoClienteCompartilhado> AtendimentoPedidoClienteCompartilhado { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Restaurante> Restaurante { get; set; }
    public DbSet<RestauranteItemCardapio> RestauranteItemCardapio { get; set; }
    public DbSet<RestauranteMesa> RestauranteMesa { get; set; }
    public DbSet<RestauranteMesaAtendimento> RestauranteMesaAtendimento { get; set; }
    public DbSet<RestauranteMesaAtendimentoCliente> RestauranteMesaAtendimentoCliente { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<TagItemCardapio> TagItemCardapio { get; set; }
    public DbSet<RestauranteAbaCardapio> RestauranteAbaCardapio { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}