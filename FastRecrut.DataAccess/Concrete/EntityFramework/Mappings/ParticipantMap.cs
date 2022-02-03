using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRecrut.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ParticipantMap : IEntityTypeConfiguration<Participant>
    {
        /*
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public System.DateTime LastLogin { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
         */
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Lastname).IsRequired();
            builder.Property(a => a.Lastname).HasMaxLength(50);
            builder.Property(a => a.Firstname).IsRequired();
            builder.Property(a => a.Firstname).HasMaxLength(50);
            builder.Property(a => a.Email).HasMaxLength(50);
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Phone).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(10);
            builder.Property(a => a.PasswordSalt).IsRequired();
            builder.Property(a => a.PasswordHash).IsRequired();
            builder.ToTable("Participants");
            builder.HasData(
                new Participant
                {
                    Id = 1,
                    Firstname = "Matt",
                    Lastname = "LeBlanc",
                    Phone = "0102030405",
                    Email = "m.leblanc@exemple.com",
                    Status = true,
                },
                new Participant
                {
                    Id = 2,
                    Firstname = "Matthew",
                    Lastname = "Perry",
                    Phone = "0102030405",
                    Email = "m.perry@exemple.com",
                    Status = true,
                },
                new Participant
                {
                    Id = 3,
                    Firstname = "Courteney",
                    Lastname = "Cox",
                    Phone = "0102030405",
                    Email = "c.cox@exemple.com",
                    Status = true,
                },
                new Participant
                {
                    Id = 4,
                    Firstname = "Neil Patrick",
                    Lastname = "Harris",
                    Phone = "0102030405",
                    Email = "np.harris@exemple.com",
                    Status = true,
                },
                new Participant
                {
                    Id = 5,
                    Firstname = "Wentworth",
                    Lastname = "Miller",
                    Phone = "0102030405",
                    Email = "w.miller@exemple.com",
                    Status = true,
                }
            );
        }
    }
}
