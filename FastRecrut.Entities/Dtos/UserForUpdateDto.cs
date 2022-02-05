using FastRecrut.Core.Entities.Abstract;

namespace FastRecrut.Entities.Dtos
{
    public class UserForUpdateDto : UserForRegisterDto, IDto
    {
        public int AgentId { get; set; }
    }
}
