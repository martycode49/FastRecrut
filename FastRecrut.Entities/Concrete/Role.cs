using System.ComponentModel.DataAnnotations.Schema;

namespace FastRecrut.Entities.Concrete
{
    public class Role
    {
        public int Id { get; set; }

        [ForeignKey("AgentId")]
        public int Agent_Id { get; set; }
        public string RoleName { get; set; }

        public virtual Agent Agents { get; set; }
    }
}
