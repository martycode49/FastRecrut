using FastRecrut.Core.Entities.Abstract;

namespace FastRecrut.Entities.Dtos
{
    public class UserForUpdateDto : UserForRegisterDto, IDto
    {
        public int ParticipantId { get; set; }
        public int AgentId { get; set; }
    }
}
