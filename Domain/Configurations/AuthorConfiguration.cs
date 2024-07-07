using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Age)
                .IsRequired();
        }
    }
}
