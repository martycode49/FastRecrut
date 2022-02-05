using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRecrut.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ParticipantDataMap : IEntityTypeConfiguration<ParticipantData>
    {
        /*
        public int Id { get; set; }
        public int IdAgent { get; set; }
        public Nullable<System.DateTime> datecreate { get; set; }
        public int QuestionQty { get; set; }
        public string Status { get; set; }
         */
        public void Configure(EntityTypeBuilder<ParticipantData> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.ToTable("ParticipantDatas");
        }
    }
}
