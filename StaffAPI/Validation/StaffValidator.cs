using FluentValidation;
using StaffAPI.Core.Entities;

namespace StaffAPI.Validation
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(user => user.Id).NotEmpty();
            RuleFor(user => user.FirstName).NotEmpty().Length(1, 50);
            RuleFor(user => user.LastName).NotEmpty().Length(1, 50);
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
        }
    }
}
