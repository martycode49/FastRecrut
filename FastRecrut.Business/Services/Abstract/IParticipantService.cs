using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IParticipantService
    {
        IResult Add(Participant participant);
        IResult Delete(Participant participant);
        IResult Update(Participant participant);
        IDataResult<Participant> GetById(int id);
        IDataResult<List<Participant>> GetAll();
        IDataResult<List<ParticipantDetailDto>> GetCustomerDetails();
        IDataResult<List<ParticipantDetailDto>> GetCustomerDetailById(int customerId);
        IDataResult<ParticipantDetailDto> GetByEmail(string email);
    }
}
