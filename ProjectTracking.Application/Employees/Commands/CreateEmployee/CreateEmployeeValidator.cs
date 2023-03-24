using FluentValidation;

namespace ProjectTracking.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
        RuleFor(command =>
        command.Email).NotEmpty().MaximumLength(250);
        RuleFor(command =>
            command.Name).NotEmpty().MaximumLength(50);
        RuleFor(command => command.Surname).NotEmpty().MaximumLength(50);
        RuleFor(command => command.LastName).NotEmpty().MaximumLength(50);
    }
}