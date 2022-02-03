using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IAuthService
    {
        IDataResult<Agent> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Agent> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Agent agent);
        IDataResult<UserForUpdateDto> Update(UserForUpdateDto userForUpdate);
    }
}
