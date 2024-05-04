using FluentValidation;
using RequestPermission.Api.Dtos.Request;

namespace RequestPermission.Api.Validations;

public class RequestPermissionValidator : AbstractValidator<RequestPermissionDto>
{
    public RequestPermissionValidator()
    {
        RuleFor(x => x.EmployeeId).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
        RuleFor(x => x.Reason).MaximumLength(100).WithMessage("Reason can not be more than 100 characters.")
            .MinimumLength(10).WithMessage("Reason can not be less than 10 characters.")
            .NotEmpty().WithMessage("Reason can not be empty.");
    }

}
