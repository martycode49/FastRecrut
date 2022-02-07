using FastRecrut.Api.Resources;
using FluentValidation;

namespace MyMusic.API.Validation
{
    public class SaveUserResourceValidation : AbstractValidator<AgentResource>
    {
        public SaveUserResourceValidation()
        {
            RuleFor(m => m.Firstname)
             .NotEmpty()
             .MaximumLength(50);
            RuleFor(m => m.Lastname)
          .NotEmpty()
          .MaximumLength(50);
            RuleFor(m => m.Email)
      .NotEmpty()
      .MaximumLength(50);
            RuleFor(m => m.Password)
       .NotEmpty()
        .MaximumLength(50);
        }
    }
}
