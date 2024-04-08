
namespace Doctor.API.Doctors.DeleteDoctor;

public record DeleteDoctorCommand(Guid Id) : ICommand<DeleteDoctorResult>;
public record DeleteDoctorResult(bool IsSuccess);

public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
{
    public DeleteDoctorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Doctor ID is required");
    }
}

internal class DeleteDoctorCommandHandler
    (IDocumentSession session)
    : ICommandHandler<DeleteDoctorCommand, DeleteDoctorResult>
{
    public async Task<DeleteDoctorResult> Handle(DeleteDoctorCommand command, CancellationToken cancellationToken)
    {
        session.Delete<DoctorModel>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteDoctorResult(true);
    }
}
