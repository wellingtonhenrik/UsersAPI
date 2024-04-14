using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApi.Domain.Models;

namespace UsersApi.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.id);
            builder.Property(a => a.Nome).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(40).IsRequired();
            builder.Property(a => a.DataCadastro).IsRequired();

            builder.HasIndex(a => a.Email).IsUnique();
        }
    }
}
