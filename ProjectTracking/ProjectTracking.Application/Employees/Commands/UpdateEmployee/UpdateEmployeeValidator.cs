using FluentValidation;

namespace ProjectTracking.Application.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(command =>
            command.Id).NotEqual(Guid.Empty);
        RuleFor(command =>
            command.Email).NotEmpty().MaximumLength(250);
        RuleFor(command =>
            command.Name).NotEmpty().MaximumLength(50);
        RuleFor(command => command.Surname).NotEmpty().MaximumLength(50);
        RuleFor(command => command.LastName).NotEmpty().MaximumLength(50);
    }

}