using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAgentService _agentService;
        private ITokenHelper _tokenHelper;
        private IParticipantService _participantService;

        public AuthManager(IAgentService userService, ITokenHelper tokenHelper, IParticipantService customerService)
        {
            _agentService = userService;
            _tokenHelper = tokenHelper;
            _participantService = customerService;
        }

        public IDataResult<AccessToken> CreateAccessToken(Agent agent)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Agent> Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Agent> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var agent = new Agent
            {
                Email = userForRegisterDto.Email,
                Firstname = userForRegisterDto.FirstName,
                Lastname = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            _agentService.Add(agent);
            var lastUser = _agentService.GetLastUser();

            var agent = new Agent
            {
                Id = lastUser.Data.Id
            };

            _agentService.Add(agent);
            return new SuccessDataResult<Agent>(agent, Messages.UserRegistered);
        }

        public IDataResult<UserForUpdateDto> Update(UserForUpdateDto userForUpdate)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
