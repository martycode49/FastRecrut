using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRecrut.DataAccess.Concrete.EntityFramework.Mappings
{
    public class AgentMap : IEntityTypeConfiguration<Agent>
    {
        /* 
        public int Id { get; set; }
        public string Civility { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Status { get; set; }

         */
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(a => a.AgentId);
            builder.Property(a => a.AgentId).UseIdentityColumn();
            builder.Property(a => a.Civility).IsRequired();
            builder.Property(a => a.Civility).HasMaxLength(5);
            builder.Property(a => a.Lastname).IsRequired();
            builder.Property(a => a.Lastname).HasMaxLength(50);
            builder.Property(a => a.Firstname).IsRequired();
            builder.Property(a => a.Firstname).HasMaxLength(50);
            builder.Property(a => a.Email).HasMaxLength(50);
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Phone).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(10);
            builder.ToTable("Agents");
            builder.HasData(
                new Agent
                {
                    AgentId = 1,
                    Civility = "M.",
                    Firstname = "Matt",
                    Lastname = "LeBlanc",
                    Phone = "0102030405",
                    Email = "m.leblanc@exemple.com",
                    IsActive = true,
                    IsAdmin = true,
                    CreatedAt = System.DateTime.Now,
                    LastLogin = System.DateTime.Now,
                    Status = "Agent"
                },
                new Agent
                {
                    AgentId = 2,
                    Civility = "M.",
                    Firstname = "Matthew",
                    Lastname = "Perry",
                    Phone = "0102030405",
                    Email = "m.perry@exemple.com",
                    IsActive = true,
                    IsAdmin = true,
                    CreatedAt = System.DateTime.Now,
                    LastLogin = System.DateTime.Now,
                    Status = "Agent"
                },
                new Agent
                {
                    AgentId = 3,
                    Civility = "M.",
                    Firstname = "Courteney",
                    Lastname = "Cox",
                    Phone = "0102030405",
                    Email = "c.cox@exemple.com",
                    IsActive = true,
                    IsAdmin = false,
                    CreatedAt = System.DateTime.Now,
                    LastLogin = System.DateTime.Now,
                    Status = "Agent"
                },
                new Agent
                {
                    AgentId = 4,
                    Civility = "M.",
                    Firstname = "Neil Patrick",
                    Lastname = "Harris",
                    Phone = "0102030405",
                    Email = "np.harris@exemple.com",
                    IsActive = true,
                    IsAdmin = false,
                    CreatedAt = System.DateTime.Now,
                    LastLogin = System.DateTime.Now,
                    Status = "Agent"
                },
                new Agent
                {
                    AgentId = 5,
                    Civility = "M.",
                    Firstname = "Wentworth",
                    Lastname = "Miller",
                    Phone = "0102030405",
                    Email = "w.miller@exemple.com",
                    IsActive = true,
                    IsAdmin = false,
                    CreatedAt = System.DateTime.Now,
                    LastLogin = System.DateTime.Now,
                    Status = "Agent"
                }
            ) ;
        }
    }
}
