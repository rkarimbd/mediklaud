
namespace Doctor.API.Doctors.UpdateDoctor;

public record UpdateDoctorCommand(Guid Id, string Name, string Email, string Mobile, string Address, List<string> Speciality, string Qualification)
    : ICommand<UpdateDoctorResult>;
public record UpdateDoctorResult(bool IsSuccess);

public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
{
    public UpdateDoctorCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty().WithMessage("Doctor ID is required");

        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

        
    }
}

internal class UpdateDoctorCommandHandler
    (IDocumentSession session)
    : ICommandHandler<UpdateDoctorCommand, UpdateDoctorResult>
{
    public async Task<UpdateDoctorResult> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
    {
        var Doctor = await session.LoadAsync<DoctorModel>(command.Id, cancellationToken);

        if (Doctor is null)
        {
            //throw new DoctorNotFoundException(command.Id);
        }

       

        Doctor.Name = command.Name;
        Doctor.Email = command.Email;
        Doctor.Mobile = command.Mobile;
        Doctor.Address = command.Address;
        Doctor.Speciality = command.Speciality;
        Doctor.Qualification = command.Qualification;

        session.Update(Doctor);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateDoctorResult(true);
    }
}
