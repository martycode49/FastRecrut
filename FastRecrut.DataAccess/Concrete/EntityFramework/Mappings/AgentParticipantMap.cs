using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRecrut.DataAccess.Concrete.EntityFramework.Mappings
{
    public class AgentParticipantMap : IEntityTypeConfiguration<AgentParticipant>
    {
        /*
         public int Id { get; set; }
        public int IdAgent { get; set; }
        public Nullable<System.DateTime> datecreate { get; set; }
        public int QuestionQty { get; set; }
        public string Status { get; set; }
         */
        public void Configure(EntityTypeBuilder<AgentParticipant> builder)
        {
            builder.HasKey(a => a.AgtPartId);
            builder.Property(a => a.AgtPartId).UseIdentityColumn();
            builder.ToTable("AgentParticipants");
        }
    }
}
