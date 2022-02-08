using System.ComponentModel.DataAnnotations.Schema;

namespace FastRecrut.Entities.Concrete
{
    public class Role
    {
        public int Id { get; set; }

        [ForeignKey("Agent")]
        public int UserId { get; set; }
        public string RoleName { get; set; }

        public virtual Agent Agents { get; set; }
    }
}
