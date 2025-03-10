using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioDigital.Infra.Data.EntitiesConfiguration
{
    internal class TagItemCardapioConfiguration : IEntityTypeConfiguration<TagItemCardapio>
    {
        public void Configure(EntityTypeBuilder<TagItemCardapio> builder) { }
    }
}
