using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleTodoAPI.Domain.Entities;

namespace SimpleTodoAPI.Infrastructure.Configuration
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title)
                .HasMaxLength(100);
            builder.Property(t => t.BodyText)
                .HasMaxLength(1000);
        }
    }
}
