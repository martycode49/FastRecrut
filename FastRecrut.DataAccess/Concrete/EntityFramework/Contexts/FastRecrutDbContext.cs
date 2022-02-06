using FastRecrut.DataAccess.Concrete.EntityFramework.Mappings;
using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FastRecrut.DataAccess.Concrete.EntityFramework.Contexts
{
    public class FastRecrutDbContext : DbContext
    {
        public FastRecrutDbContext(DbContextOptions<FastRecrutDbContext> options) : base(options)
        {
        }


        public DbSet<Agent> Agents { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<AgentParticipant> AgentParticipants { get; set; }
        public DbSet<ParticipantData> ParticipantDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgentMap());
            modelBuilder.ApplyConfiguration(new ParticipantDataMap());
            modelBuilder.ApplyConfiguration(new AgentParticipantMap());
            modelBuilder.ApplyConfiguration(new QuizMap());
        }
    }
}
