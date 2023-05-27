using CSVReader.Application.Models;
using FluentValidation;

namespace CSVReader.WebApi.Validation;

public class CreateFileValidator : AbstractValidator<CreateFileVM>
{
    public CreateFileValidator()
    {
        RuleFor(vm => vm.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(vm => vm.HasHeaderRecord)
            .NotNull().WithMessage("HasHeaderRecord is required.");

        RuleFor(vm => vm.Delimiter)
            .NotEmpty().WithMessage("Delimiter is required.");

        /*RuleFor(vm => vm.File)
            .NotNull().WithMessage("File is required.")
            .Must(BeValidFile).WithMessage("Invalid file format.");*/
    }

    private  bool BeValidFile(IFormFile? file)
    {
        if (file == null)
        {
            return false;
        }
        var fileExtension = Path.GetExtension(file.FileName);

        // Check if the file extension is ".csv"
        return string.Equals(fileExtension, ".csv", System.StringComparison.OrdinalIgnoreCase);
    }
}