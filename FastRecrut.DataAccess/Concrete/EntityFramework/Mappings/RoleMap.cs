using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRecrut.DataAccess.Concrete.EntityFramework.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.RoleName).HasMaxLength(50);
            builder.Property(a => a.RoleName).IsRequired();
            builder.ToTable("Roles");
            builder.HasData(
                new Role
                {
                    Id = 1,
                    UserId = 1,
                    RoleName = "Admin"
                });
        }
    }
}
