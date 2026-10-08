using CommerX.Domain.Clients.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommerX.Infrastructure.Data.Configurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> client)
    {
        client.ToTable("Clients");
        client.HasKey(c => c.Id);

        client.Property(c => c.CreatedOn).IsRequired();

        client.OwnsOne(c => c.FirstName, vo =>
        {
            vo.Property(x => x.Value).HasColumnName("FirstName").HasMaxLength(100).IsRequired();
        });

        client.OwnsOne(c => c.LastName, vo =>
        {
            vo.Property(x => x.Value).HasColumnName("LastName").HasMaxLength(100).IsRequired();
        });

        client.OwnsOne(c => c.DocumentNumber, vo =>
        {
            vo.Property(x => x.Value).HasColumnName("DocumentNumber").HasMaxLength(8).IsRequired();
        });

        client.OwnsOne(c => c.Email, vo =>
        {
            vo.Property(x => x.Value).HasColumnName("Email").HasMaxLength(254).IsRequired();
        });

        client.OwnsOne(c => c.Phone, vo =>
        {
            vo.Property(x => x.Value).HasColumnName("Phone").HasMaxLength(20).IsRequired();
        });

        client.OwnsOne(c => c.Address, vo =>
        {
            vo.Property(x => x.Value).HasColumnName("Address").HasMaxLength(200).IsRequired();
        });

        client.Property(c => c.BirthDate).IsRequired();

        client.Navigation(c => c.FirstName).IsRequired();
        client.Navigation(c => c.LastName).IsRequired();
        client.Navigation(c => c.DocumentNumber).IsRequired();
        client.Navigation(c => c.Email).IsRequired();
        client.Navigation(c => c.Phone).IsRequired();
        client.Navigation(c => c.Address).IsRequired();
    }
}