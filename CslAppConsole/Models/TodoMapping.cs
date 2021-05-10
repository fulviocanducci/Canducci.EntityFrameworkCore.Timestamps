using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CslAppConsole.Models
{
    public class TodoMapping : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("todos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id");
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Done)
                .HasColumnName("done")
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
        }
    }
}
