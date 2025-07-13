using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Database.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.ISBN).HasMaxLength(17).IsRequired();
            builder.Property(b => b.Title).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Author).HasMaxLength(30).IsRequired();
            builder.HasIndex(b => b.ISBN).IsUnique();
        }
    }
}
