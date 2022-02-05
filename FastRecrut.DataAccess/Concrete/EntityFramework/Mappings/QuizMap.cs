using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRecrut.DataAccess.Concrete.EntityFramework.Mappings
{
    public class QuizMap : IEntityTypeConfiguration<Quiz>
    {
        /*
        public int Id { get; set; }
        public string Subject { get; set; }
        public string SubSubject { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public string Rep1 { get; set; }
        public string Rep2 { get; set; }
        public string Rep3 { get; set; }
        public string Rep4 { get; set; }
        public int Level { get; set; }
        public int ValidQuestion { get; set; }
        public string CommentFalse { get; set; }
         */

        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.ToTable("Quizzes");
        }
    }
}
