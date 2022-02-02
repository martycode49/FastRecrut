using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRecrut.DataAccess.Concrete.EntityFramework.Mappings
{
    public class AgentMap : IEntityTypeConfiguration<Agent>
    {
        /* 
         Civility { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
         */
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Civility).IsRequired();
            builder.Property(a => a.Civility).HasMaxLength(5);
            builder.Property(a => a.Lastname).IsRequired();
            builder.Property(a => a.Lastname).HasMaxLength(50);
            builder.Property(a => a.Firstname).IsRequired();
            builder.Property(a => a.Firstname).HasMaxLength(50);
            builder.Property(a => a.Phone).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(10);
            builder.HasData(
                new Agent
                {
                    Id = 1,
                    Civility = "M.",
                    Firstname = "Matt",
                    Lastname = "LeBlanc",
                    Phone = "0102030405",
                    IsActive = true,
                    IsAdmin = true,
                    Password = "123"
                },
                new Agent
                {
                    Id = 2,
                    Civility = "M.",
                    Firstname = "Matthew",
                    Lastname = "Perry",
                    Phone = "0102030405",
                    IsActive = true,
                    IsAdmin = true,
                    Password = "123"
                },
                new Agent
                {
                    Id = 3,
                    Civility = "M.",
                    Firstname = "Courteney",
                    Lastname = "Cox",
                    Phone = "0102030405",
                    IsActive = true,
                    IsAdmin = false,
                    Password = "123"
                },
                new Agent
                {
                    Id = 4,
                    Civility = "M.",
                    Firstname = "Neil Patrick",
                    Lastname = "Harris",
                    Phone = "0102030405",
                    IsActive = true,
                    IsAdmin = false,
                    Password = "123"
                },
                new Agent
                {
                    Id = 5,
                    Civility = "M.",
                    Firstname = "Wentworth",
                    Lastname = "Miller",
                    Phone = "0102030405",
                    IsActive = true,
                    IsAdmin = false,
                    Password = "123"
                }
            );
        }
    }
}
