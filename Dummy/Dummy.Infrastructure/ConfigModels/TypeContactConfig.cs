using Dummy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dummy.Infrastructure.ConfigModels
{
    public class TypeContactConfig : IEntityTypeConfiguration<TypeContact>
    {
        public void Configure(EntityTypeBuilder<TypeContact> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

        }
    }
}
