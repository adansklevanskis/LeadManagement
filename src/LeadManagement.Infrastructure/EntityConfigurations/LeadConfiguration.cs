using LeadManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManagement.Infrastructure.EntityConfigurations;
public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        // Set the primary key
        builder.HasKey(l => l.Id);

        // Configure properties with their constraints
        builder.Property(l => l.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(l => l.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(l => l.DateCreated)
               .IsRequired();

        builder.Property(l => l.Suburb)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(l => l.Category)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(l => l.Description)
               .HasMaxLength(500);

        builder.Property(l => l.Price)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        // The enum will be stored as an int by default, and it's required
        builder.Property(l => l.Status)
               .IsRequired();

        builder.Property(l => l.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(l => l.PhoneNumber)
               .HasMaxLength(50);

        // Optionally, set the table name explicitly
        builder.ToTable("Leads");
    }
}
