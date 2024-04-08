

namespace Doctor.API.Doctors.CreateDoctor;


    public record CreateDoctorCommand(string Name, string Email, string Mobile, string Address, List<string> Speciality, string Qualification)

        : ICommand<CreateDoctorResult>;

public record CreateDoctorResult(Guid Id);

internal class CreateDoctorCommandHandler(IDocumentSession session)

    : ICommandHandler<CreateDoctorCommand, CreateDoctorResult>
{
    public async Task<CreateDoctorResult> Handle(CreateDoctorCommand command, CancellationToken cancellationToken)
    {

        //Business logic to create a doctor

        var doctor = new Models.DoctorModel
        {
            Name = command.Name,
            Email = command.Email,
            Mobile = command.Mobile,
            Address = command.Address,
            Speciality = command.Speciality,
            Qualification = command.Qualification

        };

       
        // save to database

        session.Store(doctor);
        await session.SaveChangesAsync(cancellationToken);
        
        var result = new CreateDoctorResult(doctor.Id);
        return result;



    }
}


