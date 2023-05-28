using CSVReader.Application.Models.RowRecord;
using FluentValidation;

namespace CSVReader.WebApi.Validation;

public class CreateRecordValidator : AbstractValidator<CreateRecordVM>
{
    public CreateRecordValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Married)
            .NotNull();

        RuleFor(x => x.Salary)
            .GreaterThan(0)
            .LessThanOrEqualTo(1000000);

        RuleFor(x => x.DateOfBirth)
            .Must(BeValidDate)
            .WithMessage("Invalid birthday date.");

        RuleFor(x => x.DateOfBirth)
            .Must(BePastDate)
            .WithMessage("Birthday must be in the past.");
    }

    private bool BeValidDate(DateTime birthday)
    {
        // Check if the date is a valid, non-default DateTime value
        return birthday != default(DateTime);
    }

    private bool BePastDate(DateTime birthday)
    {
        // Check if the date is in the past
        return birthday < DateTime.Today;
    }
}